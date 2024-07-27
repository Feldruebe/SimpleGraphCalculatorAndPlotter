using System;
using System.Windows.Input;
using SimpleGraphCalculatorAndPlotter.Models;

namespace SimpleGraphCalculatorAndPlotter.ViewModels
{
    /// <summary>
    /// The view model for <see cref="MainWindow"/>.
    /// </summary>
    public class SGCPViewModel : BindableBase
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
            this.SaveCommand =  new RelayCommand(this.Save);
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

        private void Save()
        {
            this.Model.SaveImage();
        }
    }
}