using System.Windows.Media.Imaging;

namespace SimpleGraphCalculatorAndPlotter.Models
{
    /// <summary>
    /// An interface to render the functions defined in the <see cref="ISGCPModel"/>.
    /// </summary>
    public interface ISGCPRenderer
    {
        /// <summary>
        /// Renders the given coordinates to a bitmap image.
        /// </summary>
        /// <param name="coordinates">The coordinates to render.</param>
        /// <param name="defaultFunctionCoordinates">The coordinates of the default function.</param>
        BitmapSource Render((double X, double Y)[] coordinates, (double X, double Y)[] defaultFunctionCoordinates);
    }
}