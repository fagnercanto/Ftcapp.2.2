using Sigef.Poc.Ftcapp.Interface.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sigef.Poc.Ftcapp.Interface
{
    public class BaseWindow
    {
        public static MainWindow GetMainWindow()
        {
            foreach (MainWindow window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    return window;
                }
            }
            return null;
        }


        
    }
}
