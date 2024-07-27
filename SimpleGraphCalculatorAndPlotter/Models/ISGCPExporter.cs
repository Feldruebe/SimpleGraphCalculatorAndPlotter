namespace SimpleGraphCalculatorAndPlotter.Models
{
    /// <summary>
    /// An interface for the export of functions defined in the <see cref="SGCPModel"/>.
    /// </summary>
    public interface ISGCPExporter
    {
        void Export(string filePath, (double X, double Y)[] coordinates);
    }
}