using System;
using System.Collections.Generic;

namespace SimpleGraphCalculatorAndPlotter.Models
{
    public class SGCPPlotter : ISGCPPlotter
    {
        public int Resolution { get; set; } = 100;
        
        public (double X, double Y)[] Plot(FunctionType functionType, double a, double b, double c, double d, double minX, double maxX)
        {
            var result = new List<(double X, double Y)>();
            var step = (maxX - minX) / this.Resolution;
            
            void CalculateCoordinates(Func<double, double> function)
            {
                for (double i = minX; i < maxX; i += step)
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