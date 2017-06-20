using System;
using NUnit.Framework;

namespace Fake.Build.Demo.Core.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_TwoValidNumbers_ShouldReturnSum()
        {
            var sum = _calculator.Add(3, 5);
            Assert.AreEqual(8, sum);
        }


		[Test]
		public void Multiply_TwoValidNumbers_ShouldReturnMultiplication()
		{
            var times = _calculator.Multiply(3, 5);
			Assert.AreEqual(15, times);
		}

    }
}
