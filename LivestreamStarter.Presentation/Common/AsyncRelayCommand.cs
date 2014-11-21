using System;
using System.ComponentModel;
using System.Windows.Input;

using GalaSoft.MvvmLight.Helpers;

namespace LivestreamStarter.Presentation.Common
{
    public class AsyncRelayCommand : ICommand
    {
        private readonly BackgroundWorker canExecuteworker;

        private readonly WeakAction execute;

        private readonly WeakFunc<bool> canExecute;

        private bool canExecuteResult;

        public AsyncRelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.canExecuteResult = false;

            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = new WeakAction(execute);

            if (canExecute == null)
            {
                return;
            }

            this.canExecute = new WeakFunc<bool>(canExecute);

            this.canExecuteworker = new BackgroundWorker();
            this.canExecuteworker.DoWork += (sender, args) => this.RunCanExecute(args);
            this.canExecuteworker.RunWorkerCompleted += (sender, args) => this.RaiseCanExecuteChanged(args);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this.canExecute == null)
                {
                    return;
                }

                CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (this.canExecute == null)
                {
                    return;
                }

                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (!this.canExecuteworker.IsBusy)
            {
                this.canExecuteworker.RunWorkerAsync();
            }

            return this.canExecuteResult;
        }

        public void Execute(object parameter)
        {
            if (!this.CanExecute(parameter) || this.execute == null || !this.execute.IsStatic && !this.execute.IsAlive)
            {
                return;
            }

            this.execute.Execute();
        }

        private void RaiseCanExecuteChanged(RunWorkerCompletedEventArgs args)
        {
            if ((bool)args.Result == this.canExecuteResult)
            {
                return;
            }

            this.canExecuteResult = (bool)args.Result;
            CommandManager.InvalidateRequerySuggested();
        }

        private void RunCanExecute(DoWorkEventArgs args)
        {
            if (this.canExecute == null)
            {
                args.Result = true;
                return;
            }

            if (this.canExecute.IsStatic || this.canExecute.IsAlive)
            {
                args.Result = this.canExecute.Execute();
                return;
            }

            args.Result = false;
        }
    }
}