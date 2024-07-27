namespace SimpleGraphCalculatorAndPlotter.Models
{
    /// <summary>
    /// A class that exports a number of coordinates to a svg format.
    /// </summary>
    public class SGCPExporter : ISGCPExporter
    {
        /// <summary>
        /// Exports the image.
        /// </summary>
        /// <param name="filePath">The file path where the image should be saved.</param>
        /// <param name="coordinates">The coordinates to be exported.</param>
        public void Export(string filePath, (double X, double Y)[] coordinates)
        {
            // TODO Not implemented.
        }
    }
}