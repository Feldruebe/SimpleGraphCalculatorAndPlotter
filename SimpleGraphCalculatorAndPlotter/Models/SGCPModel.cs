using System;
using System.Windows.Media.Imaging;
using SimpleGraphCalculatorAndPlotter.Properties;
using SimpleGraphCalculatorAndPlotter.ViewModels;

namespace SimpleGraphCalculatorAndPlotter.Models
{
    /// <summary>
    /// The main model for the simple graph calculator and plotter.
    /// </summary>
    public class SGCPModel : BindableBase, ISGCPModel
    {
        private readonly ISGCPPlotter plotter;
        private readonly ISGCPExporter exporter;
        private readonly Func<string> getFileName;
        private readonly ISGCPRenderer renderer;
        
        private double a = 1;
        private double b = 1;
        private double c = 0;
        private double d = 0;
        private double range = 4;
        private FunctionType functionType;
        private BitmapSource image;

        /// <summary>
        /// Initializes a new instance of the <see cref="SGCPModel"/> class.
        /// </summary>
        public SGCPModel(ISGCPPlotter plotter, ISGCPRenderer renderer, ISGCPExporter exporter, Func<string> getFileName)
        {
            this.renderer = renderer;
            this.getFileName = getFileName;
            this.exporter = exporter;
            this.plotter = plotter;
            
            this.UpdateImage();
        }

        /// <summary>
        /// Gets or sets the selected function type.
        /// </summary>
        public FunctionType FunctionType
        {
            get => this.functionType;
            set
            {
                if (this.SetField(ref this.functionType, value))
                {
                    this.SetSettings();
                    this.UpdateImage();
                }
            }
        }

        /// <inheritdoc />
        public double A
        {
            get => this.a;
            set
            {
                if (this.SetField(ref this.a, value))
                {
                    this.SetSettings();
                    this.UpdateImage();
                }
            }
        }

        /// <inheritdoc />
        public double B
        {
            get => this.b;
            set
            {
                if (this.SetField(ref this.b, value))
                {
                    this.SetSettings();
                    this.UpdateImage();
                }
            }
        }

        /// <inheritdoc />
        public double C
        {
            get => this.c;
            set
            {
                if (this.SetField(ref this.c, value))
                {
                    this.SetSettings();
                    this.UpdateImage();
                }
            }
        }

        /// <inheritdoc />
        public double D
        {
            get => this.d;
            set
            {
                if (this.SetField(ref this.d, value))
                {
                    this.SetSettings();
                    this.UpdateImage();
                }
            }
        }

        /// <inheritdoc />
        public double Range
        {
            get => this.range;
            set
            {
                if (this.SetField(ref this.range, value))
                {
                    this.UpdateImage();
                }
            }
        }

        /// <inheritdoc />
        public BitmapSource Image
        {
            get => this.image;
            set => this.SetField(ref this.image, value);
        }

        /// <inheritdoc />
        public void SaveImage()
        {
            var coordinates = this.plotter.Plot(this.FunctionType, this.A, this.B, this.C, this.D, this.Range);
            var fileName = this.getFileName();
            this.exporter.Export(fileName, coordinates);
        }

        /// <summary>
        /// Initialized the model with the given parameters.
        /// Does not trigger property changes and should be called only once directly after creatinon.
        /// </summary>
        /// <param name="functionType">The function type.</param>
        /// <param name="a">The parameter a.</param>
        /// <param name="b">The parameter b.</param>
        /// <param name="c">The parameter c.</param>
        /// <param name="d">The parameter d.</param>
        public void InitializeSettings(FunctionType functionType, double a, double b, double c, double d)
        {
            this.functionType = functionType;
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            
            this.UpdateImage();
        }

        private void UpdateImage()
        {
            var coordinates = this.plotter.Plot(this.FunctionType, this.A, this.B, this.C, this.D, this.Range);
            var coordinatesDefault = this.plotter.Plot(this.FunctionType, 1, 1, 0, 0, this.Range);
            var renderedImage = this.renderer.Render(coordinates, coordinatesDefault);
            this.Image = renderedImage;
        }

        private void SetSettings()
        {
            Settings.Default.FunctionType = (int)this.FunctionType;
            Settings.Default.A = this.A;
            Settings.Default.B = this.B;
            Settings.Default.C = this.C;
            Settings.Default.D = this.D;
        }
    }
}