using System.Windows.Media.Imaging;

namespace SimpleGraphCalculatorAndPlotter.Models
{
    public class SGCPRenderer : ISGCPRenderer
    {
        public BitmapImage Render((double X, double Y)[] coordinates)
        {
            return new BitmapImage();
        }
    }
}