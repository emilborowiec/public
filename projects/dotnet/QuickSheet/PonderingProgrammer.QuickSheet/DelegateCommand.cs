﻿using System;
using System.Windows.Input;

namespace PonderingProgrammer.QuickSheet
{

    public class DelegateCommand<T> : ICommand where T : class
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;
 
        public DelegateCommand(Action<T> execute)
            : this(execute, null)
        {
        }
 
        public DelegateCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
 
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }
 
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
 
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}