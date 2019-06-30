using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void TestCaseOne()
        {
            string pressedKeys = "0";
            Assert.Equal("0", OriginalResult(pressedKeys));
        }

        [Fact]
        public void TestCaseTwo()
        {
            string pressedKeys = "000";
            Assert.Equal("0", OriginalResult(pressedKeys));
        }

        [Fact]
        public void TestCaseThree()
        {
            string pressedKeys = "c10/0=";
            Assert.Equal("-E-", OriginalResult(pressedKeys));
        }

        [Fact]
        public void TestCaseFour()
        {
            string pressedKeys = "c3+4";
            Assert.Equal("4", OriginalResult(pressedKeys));
        }


        [Fact]
        public void TestCaseFive()
        {
            string pressedKeys = "c3..5+4..5=";
            Assert.Equal("8", OriginalResult(pressedKeys));
        }

        [Fact]
        public void TestCaseSix()
        {
            string pressedKeys = "c3..5+4..5+2+1..5+0.5=";
            Assert.Equal("12", OriginalResult(pressedKeys));
        }

        [Fact]
        public void TestCaseSeven()
        {
            string pressedKeys = "3..5+4.c";
            Assert.Equal("0", OriginalResult(pressedKeys));
        }






        private string OriginalResult(string expression)
        {
            Calculator calculator = new Calculator();
            string result = null;
            foreach (char keys in expression)
            {
                result = calculator.SendKeyPress(keys);
            }
            return result;
        }
    }
}
