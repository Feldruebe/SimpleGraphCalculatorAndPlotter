namespace SimpleGraphCalculatorAndPlotter.Models
{
    /// <summary>
    /// An interface for the plotting of functions.
    /// Used by the <see cref="ISGCPModel"/>.
    /// </summary>
    public interface ISGCPPlotter
    {
        /// <summary>
        /// Gets or sets the resolution of the plotter.
        /// </summary>
        int Resolution { get; set; }
        
        /// <summary>
        /// Calculates the coordinates for the given function tyo and parameters inside the axis ranges.
        /// </summary>
        /// <param name="functionType">The selected function type.</param>
        /// <param name="a">The parameter a.</param>
        /// <param name="b">The parameter b.</param>
        /// <param name="c">The parameter c.</param>
        /// <param name="d">The parameter d.</param>
        /// <param name="range">The range of the x-axis.</param>
        /// <returns>The calculated coordinates.</returns>
        (double X, double Y)[] Plot(FunctionType functionType, double a, double b, double c, double d, double range);
    }
}