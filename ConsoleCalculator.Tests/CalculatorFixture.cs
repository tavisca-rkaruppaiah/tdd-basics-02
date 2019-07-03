using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
         Calculator calculator;

        public CalculatorFixture()
        {
            calculator = new Calculator();
        }


        [Fact]
        public void Single_KeyPress_With_Value_0_Should_Return_0()
        {
            string pressedKeys = "0";
            Assert.Equal("0", OriginalResult(pressedKeys));
        }

        [Fact]
        public void Multiple_KeyPress_With_Value_123_Should_Return_123()
        {
            string pressedKeys = "123";
            Assert.Equal("123", OriginalResult(pressedKeys));
        }

        [Fact]
        public void Multiple_KeyPress_With_Value_000_Should_Return_0()
        {
            string pressedKeys = "0000";
            Assert.Equal("0", OriginalResult(pressedKeys));
        }


        [Fact]
        public void Error_Calculator_Should_Return_E()
        {
            string pressedKeys = "10/0=";
            Assert.Equal("-E-", OriginalResult(pressedKeys));
        }

        [Fact]
        public void PerformAdditionOperation()
        {
            string pressedKeys = "10+2=";
            Assert.Equal("12", OriginalResult(pressedKeys));
        }


        [Fact]
        public void PerformDecimalAdditionOperation()
        {
            string pressedKeys = "1..1+2..1=";
            Assert.Equal("3.2", OriginalResult(pressedKeys));
        }

        

        [Fact]
        public void PerformSignChangeOperation()
        {
            string pressedKeys = "1s";
            Assert.Equal("-1", OriginalResult(pressedKeys));
        }

        [Fact]
        public void PerformClearCalculator_ShouldReturnWith_0()
        {
            string pressedKeys = "1+2+3c";
            Assert.Equal("0", OriginalResult(pressedKeys));
        }





        private string OriginalResult(string expression)
        {   
            string result = null;

            foreach (char keys in expression)
            {
                result = calculator.SendKeyPress(keys);
            }
            return result;
        }
    }
}
