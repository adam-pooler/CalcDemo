using System.Collections.Generic;
using System;

namespace CalcEngine
{
    public class SimpleCalculator
    {
        public SimpleCalculator()
        {
            CommandParser = new CommandParser();
            Evaluator = new SimpleCalcEngine();
        }

        public SimpleCalculator(CommandParser commandParser, Evaluator evaluator)
        {
            CommandParser = commandParser ?? throw new ArgumentNullException(nameof(commandParser));
            Evaluator = evaluator ?? throw new ArgumentNullException(nameof(evaluator));
        }

        public CommandParser CommandParser { get; set; }

        public Evaluator Evaluator { get; set; }

        public virtual object Calculate(string command)
        {
            var nodes = CommandParser.Parse(command);
            return Evaluator.Evaluate(nodes);
        }
    }
}