using System.Windows;
using SimpleGraphCalculatorAndPlotter.Properties;

namespace SimpleGraphCalculatorAndPlotter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void OnExit(object sender, ExitEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}