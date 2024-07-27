using System;
using System.Windows.Media.Imaging;
using SimpleGraphCalculatorAndPlotter.ViewModels;

namespace SimpleGraphCalculatorAndPlotter.Models
{
    /// <summary>
    /// The main model for the simple graph calculator and plotter.
    /// </summary>
    public class SGCPModel : BindableBase, ISGCPModel
    {
        private ISGCPPlotter plotter;
        private ISGCPExporter exporter;
        private Func<string> getFileName;
        private double a = 1;
        private double b = 1;
        private double c = 0;
        private double d = 0;
        private double minX = -4;
        private double maxX = 4;
        private double minY = -1;
        private double maxY = 1;
        private ISGCPRenderer renderer;
        private FunctionType functionType;

        /// <summary>
        /// Initializes a new instance of the <see cref="SGCPModel"/> class.
        /// </summary>
        public SGCPModel(ISGCPPlotter plotter, ISGCPRenderer renderer, ISGCPExporter exporter, Func<string> getFileName)
        {
            this.renderer = renderer;
            this.getFileName = getFileName;
            this.exporter = exporter;
            this.plotter = plotter;
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
                    this.UpdateImage();
                }
            }
        }

        /// <inheritdoc />
        public double MinX
        {
            get => this.minX;
            set
            {
                if (this.SetField(ref this.minX, value))
                {
                    this.UpdateImage();
                }
            }
        }

        /// <inheritdoc />
        public double MaxX
        {
            get => this.maxX;
            set
            {
                if (this.SetField(ref this.maxX, value))
                {
                    this.UpdateImage();
                }
            }
        }

        /// <inheritdoc />
        public double MinY
        {
            get => this.minY;
            set
            {
                if (this.SetField(ref this.minY, value))
                {
                    this.UpdateImage();
                }
            }
        }

        /// <inheritdoc />
        public double MaxY
        {
            get => this.maxY;
            set
            {
                if (this.SetField(ref this.maxY, value))
                {
                    this.UpdateImage();
                }
            }
        }

        /// <inheritdoc />
        public BitmapImage Image { get; set; }

        /// <inheritdoc />
        public void SaveImage()
        {
            var coordinates = this.plotter.Plot(this.FunctionType, this.A, this.B, this.C, this.D, this.MinX, this.MaxX, this.MinY, this.MaxY);
            var fileName = this.getFileName();
            this.exporter.Export(fileName, coordinates);
        }

        private void UpdateImage()
        {
            var coordinates = this.plotter.Plot(this.FunctionType, this.A, this.B, this.C, this.D, this.MinX, this.MaxX, this.MinY, this.MaxY);
            var image = this.renderer.Render(coordinates);
            this.Image = image;
        }
    }
}