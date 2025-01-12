using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalculatorService;


namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private CalculatorService.Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new CalculatorService.Calculator();
        }

        [TestMethod]
        public void Add_And_Return_20()
        {
            string input = "20";

            var result = _calculator.Add(input);
            int answer = 20;

            Assert.AreEqual(answer, result);
        }

        [TestMethod]
        public void Add_1_And_500_Return_501()
        {
            string input = "1,500";

            var result = _calculator.Add(input);
            int answer = 501;

            Assert.AreEqual(answer, result);
        }

        [TestMethod]
        public void Add_4_Minuss_3_Return_1()
        {
            string input = "4,-3";

            var result = _calculator.Add(input);
            int answer = 1;

            Assert.AreEqual(answer, result);
        }

        [TestMethod]
        public void ThrowExceptionMoreThanTwoNumbers()
        {
            string input = "4,3,7";

            Assert.ThrowsException<Exception>(() => _calculator.Add(input));

        }

        [TestMethod]
        public void Add_Empty_Convert_Zero()
        {
            string input = "";

            var result = _calculator.Add(input);
            int answer = 0;

            Assert.AreEqual(answer, result);
        }

        [TestMethod]
        public void Add_MissingNumbers_ConvertZero()
        {
            string input = "100,";

            var result = _calculator.Add(input);
            int answer = 100;

            Assert.AreEqual(answer, result);
        }

        [TestMethod]
        public void Add_InvalidNumbers_Convert_Zero()
        {
            string input = "5,tyty";

            var result = _calculator.Add(input);
            int answer = 5;

            Assert.AreEqual(answer, result);
        }
    }
}