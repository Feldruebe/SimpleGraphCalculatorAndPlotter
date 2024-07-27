using System;
using Moq;
using NUnit.Framework;
using SimpleGraphCalculatorAndPlotter.Models;
using SimpleGraphCalculatorAndPlotter.ViewModels;

namespace SimpleGraphCalculatorAndPlotterTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SaveCallsModel()
        {
            // Arrange
            var modelMock = new Mock<ISGCPModel>();
            var sut = new SGCPViewModel(modelMock.Object);
            
            // Act
            sut.SaveCommand.Execute(null);
            
            // Assert
            modelMock.Verify(mock => mock.SaveImage());
        }
        
        [Test]
        [TestCase(FunctionType.Sin, SGCPViewModel.SinString)]
        [TestCase(FunctionType.Cos, SGCPViewModel.CosString)]
        [TestCase(FunctionType.Sinc, SGCPViewModel.SincString)]
        public void FunctionString(FunctionType functionType, string expectedOutput)
        {
            // Arrange
            var modelMock = new Mock<ISGCPModel>();
            modelMock.Setup(mock => mock.FunctionType).Returns(functionType);
            var sut = new SGCPViewModel(modelMock.Object);
            
            // Assert
            Assert.That(sut.FunctionString == expectedOutput, $"Wrong {nameof(FunctionType)} {sut.FunctionString} expected to be {expectedOutput}");
        }
    }
}