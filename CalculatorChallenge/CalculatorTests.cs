using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorChallenge
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator;
        [TestInitialize]
        public void Initialize()
        {
            _calculator = new Calculator();
        }
        [DataTestMethod]
        [DataRow(2,2,4)]
        [DataRow(3,4,7)]
        public void Addition_ShouldGiveCorrectNumber(double a, double b, double c)
        {
           Assert.AreEqual(c,_calculator.Add(a, b));
            _calculator.Div(2d, 3d);
            Console.WriteLine(_calculator.Percent(a,b));
        }

        [TestMethod]
        public void Fraction_ShouldReturnAFraction()
        {
            Console.WriteLine(_calculator.Fraction(1000,90));
            Console.WriteLine(_calculator.Fraction(3000,18238));
            Console.WriteLine(_calculator.Fraction(584000,19));
            Console.WriteLine(_calculator.Fraction(120,37));
           
        }
    }
}
