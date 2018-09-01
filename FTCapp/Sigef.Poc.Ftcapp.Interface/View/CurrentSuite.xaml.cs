using Sigef.Poc.Ftcapp.Interface.Model;
using Sigef.Poc.Ftcapp.Interface.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Sigef.Poc.Ftcapp.Interface.View
{
    /// <summary>
    /// Interaction logic for CurrentSuite.xaml
    /// </summary>
    public partial class CurrentSuite : UserControl
    {
        public CurrentSuite()
        {
            InitializeComponent();
        }

        private void FtcOneDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            this.BaseViewModel = (BaseViewModel)FindResource("MVBaseViewModel");
            if (FtcOneDataGrid.Items.Count > 0
                
                ) {
                foreach (var item in FtcOneDataGrid.Items)
                {
                    if (this.BaseViewModel.SelectedSuiteCurrent != null 
                        && this.BaseViewModel.SelectedSuiteCurrent.SelectedCaso != null 
                        && this.BaseViewModel.SelectedSuiteCurrent.SelectedCaso.SelectedComand != null
                        ) {
                        if (((Sigef.Poc.Ftcapp.Interface.Model.ComandoModel)item).Codigo != this.BaseViewModel.SelectedSuiteCurrent.SelectedCaso.SelectedComand.Codigo)
                        {
                            FtcOneDataGrid.Items.Remove(item);
                        }
                    }

                    
                }
            
            }
            

        }

        public BaseViewModel BaseViewModel { get; set; }
    }
    

}
