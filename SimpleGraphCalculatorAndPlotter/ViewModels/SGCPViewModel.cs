using System;
using System.ComponentModel;
using System.Windows.Input;
using SimpleGraphCalculatorAndPlotter.Models;

namespace SimpleGraphCalculatorAndPlotter.ViewModels
{
    /// <summary>
    /// The view model for <see cref="MainWindow"/>.
    /// </summary>
    public class SGCPViewModel : BindableBase, IDisposable
    {
        /// <summary>
        /// The string that represents the sin function.
        /// </summary>
        public const string SinString = "sin(x): a * sin(b * (x - c)) + d";

        /// <summary>
        /// The string that represents the cos function.
        /// </summary>
        public const string CosString = "cos(x): a * cos(b * (x - c)) + d";

        /// <summary>
        /// The string that represents the sinc function.
        /// </summary>
        public const string SincString = "sinc(x) = si(pi * x) = sin(pi * x) / x";

        /// <summary>
        /// Initializes a new instance of the <see cref="SGCPViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public SGCPViewModel(ISGCPModel model)
        {
            this.Model = model;
            this.Model.PropertyChanged += this.ModelPropertyChanged;
            this.SaveCommand = new RelayCommand(this.Save);
        }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        public ISGCPModel Model { get; set; }

        /// <summary>
        /// Gets or sets the save command to save the function as an image.
        /// </summary>
        public ICommand SaveCommand { get; }

        /// <summary>
        /// Gets the corresponding function string for the <see cref="ISGCPModel.FunctionType"/>
        /// </summary>
        public string FunctionString
        {
            get
            {
                switch (this.Model.FunctionType)
                {
                    case FunctionType.Sin:
                        return SinString;

                    case FunctionType.Cos:
                        return CosString;

                    case FunctionType.Sinc:
                        return SincString;

                    default:
                        throw new Exception("Unknown function type");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the selected function type is sin.
        /// </summary>
        public bool FunctionTypeIsSin
        {
            get => this.Model.FunctionType == FunctionType.Sin;
            set => this.Model.FunctionType = value ? FunctionType.Sin : this.Model.FunctionType;
        }

        /// <summary>
        /// Gets or sets a value indicating if the selected function type is cos.
        /// </summary>
        public bool FunctionTypeIsCos
        {
            get => this.Model.FunctionType == FunctionType.Cos;
            set => this.Model.FunctionType = value ? FunctionType.Cos : this.Model.FunctionType;
        }

        /// <summary>
        /// Gets or sets a value indicating if the selected function type is sinc.
        /// </summary>
        public bool FunctionTypeIsSinc
        {
            get => this.Model.FunctionType == FunctionType.Sinc;
            set => this.Model.FunctionType = value ? FunctionType.Sinc : this.Model.FunctionType;
        }

        private void Save()
        {
            this.Model.SaveImage();
        }

        private void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SGCPModel.FunctionType):
                    this.OnPropertyChanged(nameof(this.FunctionTypeIsSin));
                    this.OnPropertyChanged(nameof(this.FunctionTypeIsCos));
                    this.OnPropertyChanged(nameof(this.FunctionTypeIsSinc));
                    this.OnPropertyChanged(nameof(this.FunctionString));
                    break;
            }
        }

        public void Dispose()
        {
            this.Model.PropertyChanged -= this.ModelPropertyChanged;
        }
    }
}