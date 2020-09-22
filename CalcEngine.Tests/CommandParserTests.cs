using System.Linq;
using System;
using Xunit;
using System.Collections.Generic;

namespace CalcEngine.Tests
{
    public class CommandParserTests
    {
        //TODO: should mock out the CommandTextTokenizer property on these methods so the unit tests are testing 1 class in isolation.

        [Fact]
        public void CommandParser_Parse_With5Elements_Returns5ParsedNodes()
        {
            var commandParser = new CommandParser();
            IEnumerable<INode> parsedNodes = commandParser.Parse("5+5-5");

            Assert.Equal(5, parsedNodes.Count());
        }


        [Fact]
        public void CommandParser_Parse_With5Elements_AndWhitespace_Returns5ParsedNodes()
        {
            var commandParser = new CommandParser();
            IEnumerable<INode> parsedNodes = commandParser.Parse("5 + 5 - 5");

            Assert.Equal(5, parsedNodes.Count());
        }

        [Fact]
        public void CommandParser_Parse_With5Elements_AndDecimalValue_Returns5ParsedNodes()
        {
            var commandParser = new CommandParser();
            INode[] parsedNodes = commandParser.Parse("5+5.25-5").ToArray();

            Assert.Equal(5, parsedNodes.Count());
            Assert.Equal(5.25m, (decimal)parsedNodes[2].Value);
        }

        [Fact]
        public void CommandParser_Parse_With5Elements_AndNegativeDecimalValue_Returns5ParsedNodes()
        {
            var commandParser = new CommandParser();
            INode[] parsedNodes = commandParser.Parse("5+-5.25-5").ToArray();

            Assert.Equal(5, parsedNodes.Count());
            Assert.Equal(-5.25m, (decimal)parsedNodes[2].Value);
        }

        [Fact]
        public void CommandParser_Parse_With3Elements_AndRedundantPositiveNumberSymbol_Returns3ParsedNodes()
        {
            var commandParser = new CommandParser();
            INode[] parsedNodes = commandParser.Parse("5++5").ToArray();

            Assert.Equal(3, parsedNodes.Count());
            Assert.Equal(5, (int)parsedNodes[2].Value);
        }

                [Fact]
        public void CommandParser_Parse_With3Elements_AndRedundantPositiveNumberSymbolAndWhitespace_Returns3ParsedNodes()
        {
            var commandParser = new CommandParser();
            INode[] parsedNodes = commandParser.Parse("5+ +5").ToArray();

            Assert.Equal(3, parsedNodes.Count());
            Assert.Equal(5, (int)parsedNodes[2].Value);
        }

        [Fact]
        public void CommandParser_Parse_WithTrailingOperator_ThrowsException()
        {
            var commandParser = new CommandParser();

            Assert.Throws<CommandParsingFailedException>(() =>
            {
                INode[] parsedNodes = commandParser.Parse("5+-5.25-").ToArray();
            });
        }

        [Fact]
        public void CommandParser_Parse_WithInvalidOperator_ThrowsException()
        {
            var commandParser = new CommandParser();

            Assert.Throws<CommandParsingFailedException>(() =>
            {
                INode[] parsedNodes = commandParser.Parse("5+--5.25").ToArray();
            });
        }
    }
}