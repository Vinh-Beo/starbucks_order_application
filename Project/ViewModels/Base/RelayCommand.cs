using System;
using System.Windows.Input;

namespace Common
{
    public class RelayCommand : ICommand
    {
        private Action commandTask;
        public RelayCommand(Action workToDo)
        {
            commandTask = workToDo;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            commandTask();
        }
    }
    public class RelayParamCommand : ICommand
    {
        private Action<object> commandParamTask;
        public RelayParamCommand(Action<object> workToDo)
        {
            commandParamTask = workToDo;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            commandParamTask(parameter);
        }
    }
}
