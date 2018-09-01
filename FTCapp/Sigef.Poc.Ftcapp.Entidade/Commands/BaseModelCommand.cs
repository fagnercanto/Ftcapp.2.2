
using System;
namespace Sigef.Poc.Ftcapp.Entidade.Commands
{
    public abstract class BaseModelCommand : System.Windows.Input.ICommand
    {

        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);


        public event System.EventHandler CanExecuteChanged;

        public bool RaiseCanExecuteChanged()
        {
            bool result = false;
            if (CanExecuteChanged != null)
            {
                result = true;
                CanExecuteChanged.Invoke(this, EventArgs.Empty);
            }

            return result;

        }


    }


}
