using System.Linq;
using System;
using Xunit;
using System.Collections.Generic;

namespace CalcEngine.Tests
{
    public class SimpleCalcEngineTests
    {

        [Fact]
        public void SimpleCalcEngine_Calculate_Add3Ints_ReturnsCorrectResult()
        {
            var calc = new SimpleCalcEngine();

            IEnumerable<INode> nodes = new INode[]
            {
                new Number(4),
                new Operator(OperatorType.Add),
                new Number(9),
                new Operator(OperatorType.Add),
                new Number(16)
            };

            object result = calc.Evaluate(nodes);
            Assert.IsType<int>(result);
            Assert.Equal(29, (int)result);
        }


        [Fact]
        public void SimpleCalcEngine_Calculate_Add3Decimals_ReturnsCorrectResult()
        {
            var calc = new SimpleCalcEngine();

            IEnumerable<INode> nodes = new INode[]
            {
                new Number(10.5m),
                new Operator(OperatorType.Add),
                new Number(20.25m),
                new Operator(OperatorType.Add),
                new Number(30.1m)
            };

            object result = calc.Evaluate(nodes);
            Assert.IsType<decimal>(result);
            Assert.Equal(60.85m, (decimal)result);
        }

        [Fact]
        public void SimpleCalcEngine_Calculate_Multiply3Numbers_ReturnsCorrectResult()
        {
            var calc = new SimpleCalcEngine();

            IEnumerable<INode> nodes = new INode[]
            {
                new Number(10.1m),
                new Operator(OperatorType.Multiply),
                new Number(3),
                new Operator(OperatorType.Multiply),
                new Number(2.5m)
            };

            object result = calc.Evaluate(nodes);
            Assert.IsType<decimal>(result);
            Assert.Equal((10.1m * 3 * 2.5m), (decimal)result);
        }

        [Fact]
        public void SimpleCalcEngine_Calculate_MixedOperators_ReturnsCorrectResult()
        {
            var calc = new SimpleCalcEngine();

            IEnumerable<INode> nodes = new INode[]
            {
                new Number(10.1m),
                new Operator(OperatorType.Subtract),
                new Number(3),
                new Operator(OperatorType.Multiply),
                new Number(2.5m)
            };

            object result = calc.Evaluate(nodes);
            Assert.IsType<decimal>(result);
            Assert.Equal(((10.1m - 3) * 2.5m), (decimal)result);
        }

        [Fact]
        public void SimpleCalcEngine_Calculate_WithNullNodes_ThrowsException()
        {
            var calc = new SimpleCalcEngine();

            Assert.Throws<ArgumentNullException>(() => calc.Evaluate(null));
        }

    }
}