using Sigef.Poc.Ftcapp.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sigef.Poc.Ftcapp.Interface
{
    /// <summary>
    /// Interaction logic for Command2View.xaml
    /// </summary>
    public partial class CommandsView : UserControl
    {

        public CommandsView()
        {
          InitializeComponent();
          ConfigTxtResult();
        }

        private void txtResult_TextChanged(object sender, TextChangedEventArgs e)
        {
            ConfigTxtResult();
        }

        private void ConfigTxtResult()
        {
            if (string.IsNullOrEmpty(txtResult.Text))
            {
                txtResult.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                txtResult.Visibility = System.Windows.Visibility.Visible;
            }
        }



    }
    }

