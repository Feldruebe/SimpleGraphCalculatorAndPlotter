using System.ComponentModel;
using System.Windows.Media.Imaging;
using SimpleGraphCalculatorAndPlotter.ViewModels;

namespace SimpleGraphCalculatorAndPlotter.Models
{
    /// <summary>
    /// An interface for the model class for the <see cref="SGCPViewModel"/>.
    /// </summary>
    public interface ISGCPModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the selected function type.
        /// </summary>
        FunctionType FunctionType { get; set; }

        /// <summary>
        /// Gets or sets the A parameter.
        /// </summary>
        double A { get; set; }

        /// <summary>
        /// Gets or sets the B parameter.
        /// </summary>
        double B { get; set; }

        /// <summary>
        /// Gets or sets the C parameter.
        /// </summary>
        double C { get; set; }

        /// <summary>
        /// Gets or sets the D parameter.
        /// </summary>
        double D { get; set; }

        /// <summary>
        /// Gets or sets the range.
        /// </summary>
        double Range { get; set; }

        /// <summary>
        /// Gets or sets the rendered image.
        /// </summary>
        BitmapSource Image { get; set; }

        /// <summary>
        /// Saves the image of the currently parametrized function.
        /// </summary>
        void SaveImage();
    }
}