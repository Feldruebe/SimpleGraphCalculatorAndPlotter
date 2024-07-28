using System;
using System.Collections.Generic;

namespace SimpleGraphCalculatorAndPlotter.Models
{
    /// <summary>
    /// A simple plotter implementation.
    /// </summary>
    public class SGCPPlotter : ISGCPPlotter
    {
        /// <inheritdoc />
        public int Resolution { get; set; } = 100;

        /// <inheritdoc />
        public (double X, double Y)[] Plot(FunctionType functionType, double a, double b, double c, double d, double range)
        {
            var result = new List<(double X, double Y)>();
            var step = 2 * range / this.Resolution;
            
            void CalculateCoordinates(Func<double, double> function)
            {
                for (double i = -range; i <= range; i += step)
                {
                    var x = i;
                    var y = function(i);
                    result.Add((x, y));
                }
            }

            switch (functionType)
            {
                case FunctionType.Sin:
                    CalculateCoordinates(x => a * Math.Sin(b * (x - c)) + d);
                    break;
                
                case FunctionType.Cos:
                    CalculateCoordinates(x => a * Math.Cos(b * (x - c)) + d);
                    break;
                
                case FunctionType.Sinc:
                    CalculateCoordinates(x => a * Math.Sin(b * (Math.PI * x - c)) / (b * (Math.PI * x - c)) + d);
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(functionType), functionType, null);
            }
            
            return result.ToArray();
        }

    }
}