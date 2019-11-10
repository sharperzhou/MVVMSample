using System;
using System.Windows.Input;

namespace MVVM1.Commands
{
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action<object> executeAction, Func<object,bool> canExecuteFunc = null)
        {
            _executeAction = executeAction;
            _canExecuteFunc = canExecuteFunc;
        }
        
        public bool CanExecute(object parameter)
        {
            return _canExecuteFunc == null || _canExecuteFunc.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _executeAction?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private readonly Func<object, bool> _canExecuteFunc;
        private readonly Action<object> _executeAction;
    }
}