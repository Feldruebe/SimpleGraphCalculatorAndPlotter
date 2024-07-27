using SimpleGraphCalculatorAndPlotter.ViewModels;

namespace SimpleGraphCalculatorAndPlotter.Models
{
    /// <summary>
    /// An interface for the model class for the <see cref="SGCPViewModel"/>.
    /// </summary>
    public interface ISGCPModel
    {
        /// <summary>
        /// Saves the image of the defined function.
        /// </summary>
        void SaveImage();

        /// <summary>
        /// Gets or sets the function type that should be used.
        /// </summary>
        FunctionType FunctionType { get; set; }
    }
}