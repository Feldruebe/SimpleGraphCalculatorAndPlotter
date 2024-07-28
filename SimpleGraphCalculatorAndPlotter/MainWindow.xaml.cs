using SimpleGraphCalculatorAndPlotter.Models;
using SimpleGraphCalculatorAndPlotter.Properties;
using SimpleGraphCalculatorAndPlotter.ViewModels;

namespace SimpleGraphCalculatorAndPlotter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            var model = new SGCPModel(new SGCPPlotter(), new SGCPRenderer(), new SGCPExporter(), null);
            model.InitializeSettings((FunctionType)Settings.Default.FunctionType, Settings.Default.A, Settings.Default.B, Settings.Default.C, Settings.Default.D);
            
            this.DataContext = new SGCPViewModel(model);
        }
    }
}