using System;
using System.Collections.Generic;
using System.Linq;

namespace CalcEngine
{
    public class CommandParser
    {
        public CommandParser()
        {
            CommandTextTokenizer = new StringTokenizer();
            OperatorDefinitions = new OperatorDefinitions();
        }

        public CommandParser(OperatorDefinitions operatorDefinitions, StringTokenizer commandTokenizer)
        {
            OperatorDefinitions = operatorDefinitions ?? throw new ArgumentNullException(nameof(operatorDefinitions));
            CommandTextTokenizer = commandTokenizer ?? throw new ArgumentNullException(nameof(commandTokenizer));
        }

        public StringTokenizer CommandTextTokenizer { get; set; }

        public OperatorDefinitions OperatorDefinitions { get; set; }

        public virtual IEnumerable<INode> Parse(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                throw new ArgumentOutOfRangeException(nameof(command));
            
            command = PreProcessCommandText(command);

            Queue<string> tokens = new Queue<string>(CommandTextTokenizer.Tokenize(command,
                OperatorDefinitions.Select(item => item.Key)));

            string token;
            while (tokens.Count > 0)
            {
                //expecting a numeric token first

                token = tokens.Dequeue();
                if (OperatorDefinitions.IsOperator(token))
                {
                    if (tokens.Count == 0)
                        throw new CommandParsingFailedException($"Invalid command format. Failed to parse value '{token}' as numeric");
                    
                    //HACK: handle negative/positive number symbol. This is not ideal - would be better to have a tokenizer able to extract tokens from the command more meaningfully
                    token += tokens.Dequeue();
                }

                int intValue;
                decimal decValue;

                if (int.TryParse(token, out intValue))
                    yield return new Number(intValue);
                else if (decimal.TryParse(token, out decValue))
                    yield return new Number(decValue);
                else 
                    throw new CommandParsingFailedException($"Invalid command format. Failed to parse value '{token}' as numeric");
                
                //optionally expecting an operator - unless this is the final term

                if (tokens.Count > 0)
                {
                    token = tokens.Dequeue();

                    if (tokens.Count == 0)
                        throw new CommandParsingFailedException("Invalid command format: command must terminate with a numeric value");

                    yield return new Operator(OperatorDefinitions.GetOperatorType(token));
                }
            }
        }

        protected virtual string PreProcessCommandText(string value)
        {
            //strips all whitespace from the input text
            return new string(value.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}