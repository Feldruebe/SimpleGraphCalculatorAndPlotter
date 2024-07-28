using System.Linq;
using System.Windows.Media.Imaging;
using SkiaSharp;
using SkiaSharp.Views.WPF;

namespace SimpleGraphCalculatorAndPlotter.Models
{
    /// <summary>
    /// A class that implements a renderer for given coordinates using skia.
    /// </summary>
    public class SGCPRenderer : ISGCPRenderer
    {
        /// <inheritdoc />
        public BitmapSource Render((double X, double Y)[] coordinates, (double X, double Y)[] defaultFunctionCoordinates)
        {
            var width = 600;
            var info = new SKImageInfo(width, 400);
            var startX = coordinates[0].X;
            var endX = coordinates.Last().X;
            var scaling = width / (endX - startX);
            
            using (var surface = SKSurface.Create(info))
            {
                var canvas = surface.Canvas;
                canvas.Clear(SKColors.White);
                this.DrawCoordinateSystem(canvas);

                using (var defaultFunctionPaint = new SKPaint())
                {
                    defaultFunctionPaint.Color = SKColors.Black;
                    this.DrawCoordinatesCanvas(canvas, coordinates, defaultFunctionPaint, scaling);
                }

                using (var parameterFunctionPaint = new SKPaint())
                {
                    parameterFunctionPaint.Color = SKColors.Red;
                    this.DrawCoordinatesCanvas(canvas, defaultFunctionCoordinates, parameterFunctionPaint, scaling);
                }

                var image = surface.Snapshot();
                return image.ToWriteableBitmap();
            }
        }

        private void DrawCoordinateSystem(SKCanvas canvas)
        {
            using (var axisPaint = new SKPaint())
            {
                axisPaint.Color = SKColors.Black;
                canvas.Translate(300, 200);
                canvas.DrawLine(-300, 0, 300, 0, axisPaint);
                canvas.DrawLine(0, 200, 0, -200, axisPaint);
                
                canvas.DrawText("x", 290, 15, axisPaint);
                canvas.DrawText("y", 10, -190, axisPaint);
            }
        }

        private void DrawCoordinatesCanvas(SKCanvas canvas, (double X, double Y)[] coordinates, SKPaint paint, double scaling)
        {
            for (var index = 0; index < coordinates.Length - 1; index++)
            {
                var coordinate = coordinates[index];
                var coordinate1 = coordinates[index + 1];
                canvas.DrawLine((float)(coordinate.X * scaling), 
                    (float)(-coordinate.Y * scaling),
                    (float)(coordinate1.X * scaling),
                    (float)(-coordinate1.Y * scaling), 
                    paint);
            }
        }
    }
}