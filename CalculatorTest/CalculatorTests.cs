using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalculatorService;
using System.Net.NetworkInformation;


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

            Assert.ThrowsException<Exception>(() => _calculator.Add(input));
        }


        [TestMethod]
        public void Add_Numbers_Return_78()
        {
            string input = "1,2,3,4,5,6,7,8,9,10,11,12";

            var result = _calculator.Add(input);
            int answer = 78;

            Assert.AreEqual(answer, result);
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

        [TestMethod]
        public void Add_LineDelim_Return_6()
        {
            string input = "1\n2,3";

            var result = _calculator.Add(input);
            int answer = 6;

            Assert.AreEqual(answer, result);
        }

        [TestMethod]
        public void Add_LineDelim_Return_7()
        {
            string input = "1,1\n2,3";

            var result = _calculator.Add(input);
            int answer = 7;

            Assert.AreEqual(answer, result);
        }


        [TestMethod]
        public void ThrownException_NegativeNumbers()
        {
            string input = "-1,-3,5";
            var expectedExceptionMessage = "These negative numbers are not allowed:-1,-3";

            var result = Assert.ThrowsException<Exception>(() => _calculator.Add(input));

            Assert.AreEqual(expectedExceptionMessage, result.Message);
        }

        [TestMethod]
        public void Add_Over_1000_Return_8()
        {
            string input = "2,1001,6";

            var result = _calculator.Add(input);
            int expect = 8;

            Assert.AreEqual(expect, result);
        }
    }
}