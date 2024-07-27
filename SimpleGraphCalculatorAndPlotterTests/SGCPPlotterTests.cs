using NUnit.Framework;
using SimpleGraphCalculatorAndPlotter.Models;

namespace SimpleGraphCalculatorAndPlotterTests
{
    [TestFixture]
    public class SGCPPlotterTests
    {
        [Test]
        [TestCase(FunctionType.Sin, 1, 2, 3, 4, 5, 6, 7, 8)]
        public void Plot(FunctionType functionType, double a, double b, double c, double d, double minX, double maxX)
        {
            // Arrange
            var sut = new SGCPPlotter();

            // Act
            var coordinates = sut.Plot(functionType, a, b, c, d, minX, maxX);

            // Assert
        }
    }
}