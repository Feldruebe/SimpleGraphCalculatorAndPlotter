using NUnit.Framework;
using SimpleGraphCalculatorAndPlotter.Models;

namespace SimpleGraphCalculatorAndPlotterTests
{
    [TestFixture]
    public class SGCPPlotterTests
    {
        [Test]
        [TestCaseSource(nameof(PlotTestCases))]
        public void Plot(FunctionType functionType, double a, double b, double c, double d, double range, (double, double)[] coordinatesExpected)
        {
            // Arrange
            var sut = new SGCPPlotter() { Resolution = 5 };

            // Act
            var coordinates = sut.Plot(functionType, a, b, c, d, range);

            // Assert
            for (var index = 0; index < coordinatesExpected.Length; index++)
            {
                Assert.That(coordinates[index] == coordinatesExpected[index]);
            }
        }

        public static object[] PlotTestCases =
        {
            new object[]
            {
                FunctionType.Sin, 1, 1, 0, 0, 3,
                new[]
                {
                    (-3.0, -0.14112000805986721), (-1.8, -0.97384763087819515), (-0.60000000000000009, -0.56464247339503548), (0.59999999999999987, 0.56464247339503526), (1.7999999999999998, 0.97384763087819526),
                    (3.0, 0.14112000805986721)
                }
            },
            new object[]
            {
                FunctionType.Sin, 1, 1, 0, 0, 5,
                new[] { (-5.0, 0.95892427466313845), (-3.0, -0.14112000805986721), (-1.0, -0.8414709848078965), (1.0, 0.8414709848078965), (3.0, 0.14112000805986721), (5.0, -0.95892427466313845) }
            },
            new object[]
            {
                FunctionType.Sin, 1, 1, 0, 0, 7,
                new[]
                {
                    (-7.0, -0.65698659871878906), (-4.2000000000000002, 0.87157577241358819), (-1.4000000000000004, -0.98544972998846025), (1.3999999999999995, 0.98544972998846014),
                    (4.1999999999999993, -0.87157577241358775), (6.9999999999999991, 0.65698659871878839)
                }
            },
        };
    }
}