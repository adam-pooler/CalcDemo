using System.Linq;
using System;
using Xunit;

namespace CalcEngine.Tests
{
    public class SimpleCalcEngineIntegrationTests
    {

        [Fact]
        public void SimpleCalculator_Calculate_WithInts_ReturnsIntResult()
        {
            var calc = new SimpleCalculator(new CommandParser(), new SimpleCalcEngine());
            var result = calc.Calculate("21+21");
            Assert.IsType<int>(result);
            Assert.Equal(42, (int)result);
        }

        [Fact]
        public void SimpleCalculator_Calculate_WithDecimals_ReturnsDecimalResult()
        {
            var calc = new SimpleCalculator(new CommandParser(), new SimpleCalcEngine());
            var result = calc.Calculate("20.5+21.5");
            Assert.IsType<decimal>(result);
            Assert.Equal(42.0m, (decimal)result);
        }

        [Fact]
        public void SimpleCalculator_Calculate_WithNegativeNumbers_ReturnsNegativeResult()
        {
            var calc = new SimpleCalculator(new CommandParser(), new SimpleCalcEngine());
            var result = calc.Calculate("-21-21");
            Assert.IsType<int>(result);
            Assert.Equal(-42, (int)result);
        }

        [Fact]
        public void SimpleCalculator_Calculate_MultiplyWithNegativeNumbers_ReturnsPositiveResult()
        {
            var calc = new SimpleCalculator(new CommandParser(), new SimpleCalcEngine());
            var result = calc.Calculate("-20*-5");
            Assert.IsType<int>(result);
            Assert.Equal(100, (int)result);
        }
    }
}