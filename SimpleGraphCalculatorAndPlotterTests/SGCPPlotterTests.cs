using NUnit.Framework;
using SimpleGraphCalculatorAndPlotter.Models;

namespace SimpleGraphCalculatorAndPlotterTests
{
    [TestFixture]
    public class SGCPPlotterTests
    {
        [Test]
        [TestCaseSource(nameof(PlotTestCases))]
        public void Plot(FunctionType functionType, double a, double b, double c, double d, double minX, double maxX, (double, double)[] coordinatesExpected)
        {
            // Arrange
            var sut = new SGCPPlotter() { Resolution = 5 };

            // Act
            var coordinates = sut.Plot(functionType, a, b, c, d, minX, maxX);

            // Assert
            for (var index = 0; index < coordinatesExpected.Length; index++)
            {
                Assert.That(coordinates[index] == coordinatesExpected[index]);
            }
        }

        public static object[] PlotTestCases =
        {
            new object[] {FunctionType.Sin, 1, 1, 0, 0, -5, 5, new[] { (-5.0, 0.95892427466313845), (-3.0, -0.14112000805986721), (-1.0, -0.8414709848078965), (1.0, 0.8414709848078965), (3, 0.14112000805986721) }},
            new object[] {FunctionType.Sin, 1, 1, 0, 0, 0, 5, new[] { (0.0, 0.0), (1.0, 0.8414709848078965), (2.0, 0.90929742682568171), (3.0, 0.14112000805986721), (4, -0.7568024953079282) }},
            new object[] {FunctionType.Sin, 1, 1, 0, 0, -5, 0, new[] { (-5.0, 0.95892427466313845), (-4.0, 0.7568024953079282), (-3.0, -0.14112000805986721), (-2.0, -0.90929742682568171), (-1, -0.8414709848078965) }},
        };
    }
}