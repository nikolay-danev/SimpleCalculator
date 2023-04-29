using Calculator;

namespace CalculatorTests
{
    public class Tests
    {
        private readonly CalculatorHelper _calculatorHelper = new CalculatorHelper();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AssertIfMethodIsOperatorReturnsTrue()
        {
            var result = _calculatorHelper.IsOperator('+');

            Assert.IsTrue(result);
        }

        [Test]
        public void AssertIfMethodIsOperatorReturnsFalse()
        {
            var result = _calculatorHelper.IsOperator(')');

            Assert.IsFalse(result);
        }

        [Test]
        public void AssertIfMethodOperationOrderReturns1()
        {
            var result = _calculatorHelper.OperationOrder('+');

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void AssertIfMethodOperationOrderReturns2()
        {
            var result = _calculatorHelper.OperationOrder('*');

            Assert.That(result, Is.EqualTo(2));
        }
    }
}