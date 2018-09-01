
using Sigef.Poc.Ftcapp.Interface.Model;
using Sigef.Poc.Ftcapp.Interface.ViewModelBase;
using System;

namespace Sigef.Poc.Ftcapp.Interface.Commands
{
    public abstract class BaseViewCommand : System.Windows.Input.ICommand
    {

        public BaseViewModel _selected;
        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);

        public bool RaiseCanExecuteChanged()
        {
            bool result = false;
            if (CanExecuteChanged != null)
            {
                result = true;
                CanExecuteChanged.Invoke(this, EventArgs.Empty);
            }
            Save();
            return result;

        }

        //public DBObj AddCadsoCopy(DBObj VM, Caso caso)
        //{
        //    return _selected.ADDCasoCopy(VM, caso);
        //}

        public void Save()
        {
            //_selected.Save();
        }

        //public void SetVM(DBObj VM)
        //{
        //    _selected.SetVM(VM);
        //}

        //public DBObj Rodar(DBObj dB)
        //{
        //    return _selected.RodarVM(dB);
        //}

        public void ExcluirCaso(CasoModel caso)
        {
            //return _selected.ExcluirCaso(caso);
        }

        //public DBObj Scrap(DBObj pVM)
        //{

        //    return _selected.Scrap(pVM);
        //}

        //public DBObj ADDComando(DBObj pVM, Comando cmd)
        //{
        //    return _selected.ADDComando(pVM, cmd);
        //}

        //public DBObj ExcluirComando(DBObj pVM, Comando cmd)
        //{
        //    return _selected.ExcluirComando(pVM, cmd);
        //}



    }


}
