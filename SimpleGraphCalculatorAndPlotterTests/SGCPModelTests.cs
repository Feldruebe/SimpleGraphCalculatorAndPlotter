using System.Windows.Media.Imaging;
using Moq;
using NUnit.Framework;
using SimpleGraphCalculatorAndPlotter.Models;

namespace SimpleGraphCalculatorAndPlotterTests
{
    [TestFixture]
    public class SGCPModelTests
    {
        [Test]
        public void ParameterChangesCallPlotterAndRendererWithParameters()
        {
            // Arrange
            var plotterMock = new Mock<ISGCPPlotter>();
            var coordinates = new[] { (1.0, 1.0), (2.0, 2.0), (3.0, 3.0) };
            plotterMock.Setup(mock => mock.Plot(It.IsAny<FunctionType>(),
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<double>())).Returns(coordinates);

            var rendererMock = new Mock<ISGCPRenderer>();
            var bitmapImage = new BitmapImage();
            rendererMock.Setup(mock => mock.Render(coordinates)).Returns(bitmapImage);

            var sut = new SGCPModel(plotterMock.Object, rendererMock.Object, null, null);

            // Act
            sut.FunctionType = FunctionType.Cos;
            sut.A = 1;
            sut.B = 2;
            sut.C = 3;
            sut.D = 4;
            sut.MinX = 5;
            sut.MaxX = 6;
            sut.MinY = 7;
            sut.MaxY = 8;

            // Assert
            plotterMock.Verify(mock => mock.Plot(It.IsAny<FunctionType>(),
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<double>()), Times.Exactly(9));
            rendererMock.Verify(mock => mock.Render(coordinates), Times.Exactly(9));
            Assert.That(sut.Image == bitmapImage);
        }

        [Test]
        [TestCase(FunctionType.Sin, 1, 2, 3, 4, 5, 6)]
        [TestCase(FunctionType.Cos, -1, -2, -3, -4, -5, -6)]
        [TestCase(FunctionType.Sinc, 0, 0, 0, 0, 0, 0)]
        public void SaveImageCallsPlotterAndExportWithParameters(FunctionType functionType, double a, double b, double c, double d, double minX, double maxX)
        {
            // Arrange
            var plotterMock = new Mock<ISGCPPlotter>();
            var coordinates = new[] { (1.0, 1.0), (2.0, 2.0), (3.0, 3.0) };
            plotterMock.Setup(mock => mock.Plot(functionType, a, b, c, d, minX, maxX)).Returns(coordinates);
            var exporterMock = new Mock<ISGCPExporter>();
            var testFileString = "TestFile";

            var rendererMock = new Mock<ISGCPRenderer>();
            
            var sut = new SGCPModel(plotterMock.Object, rendererMock.Object, exporterMock.Object, () => testFileString)
            {
                FunctionType = functionType,
                A = a,
                B = b,
                C = c,
                D = d,
                MinX = minX,
                MaxX = maxX,
            };

            plotterMock.Invocations.Clear();
            
            // Act
            sut.SaveImage();

            // Assert
            plotterMock.Verify(mock => mock.Plot(functionType, a, b, c, d, minX, maxX), Times.Once());
            exporterMock.Verify(mock => mock.Export(testFileString, coordinates), Times.Once());
        }
    }
}