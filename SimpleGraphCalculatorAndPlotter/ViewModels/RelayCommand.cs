using System;
using System.Windows.Input;

namespace SimpleGraphCalculatorAndPlotter.ViewModels
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action executeAction;

        public Func<bool> canExecuteFunc;

        public RelayCommand(Action toExecute, Func<bool> canExecute = null)
        {
            this.executeAction = toExecute;
            this.canExecuteFunc = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecuteFunc?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            this.executeAction();
        }
    }
}