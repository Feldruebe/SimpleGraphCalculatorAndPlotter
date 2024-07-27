using System;
using System.Collections.Generic;

namespace SimpleGraphCalculatorAndPlotter.Models
{
    public class SGCPPlotter : ISGCPPlotter
    {
        private int resolution = 100;
        
        public (double X, double Y)[] Plot(FunctionType functionType, double a, double b, double c, double d, double minX, double maxX)
        {
            var result = new List<(double X, double Y)>();
            //var step = maxX
            switch (functionType)
            {
                case FunctionType.Sin:
                    // for (int i = 0; i < UPPER; i++)
                    // {
                    //     
                    // }
                    break;
                case FunctionType.Cos:
                    break;
                case FunctionType.Sinc:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(functionType), functionType, null);
            }
            
            return result.ToArray();
        }
    }
}