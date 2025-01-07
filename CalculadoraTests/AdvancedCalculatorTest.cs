using Calculadora;
using Moq;

namespace CalculadoraTests
{
    internal class AdvancedCalculatorTest
    {

        [Test]
        public void Average_ReturnsCorrectAverage()
        {
           
            // Arrange
            double[] a = { 1, 2, 3, 4, 5 };
            double expected = 3;

            var calculatorMoq = new Mock<ICalculator>();

            calculatorMoq.Setup(x => x.Add(It.IsAny<double>(), It.IsAny<double>())).Returns<double, double>((a, b) => a + b);

            calculatorMoq.Setup(x => x.Divide(It.IsAny<double>(), It.IsAny<double>())).Returns<double, double>((a, b) => a / b);

            var _calculator = new AdvancedCalculator(calculatorMoq.Object);

            // Act
            var result = _calculator.Average(a);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
            calculatorMoq.Verify(x => x.Add(It.IsAny<double>(), It.IsAny<double>()), Times.Exactly(5));
            calculatorMoq.Verify(x => x.Divide(It.IsAny<double>(), It.IsAny<double>()), Times.Once);
        }
    }
}
