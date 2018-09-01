
using System.Linq;
using System.Windows.Controls;
namespace Sigef.Poc.Ftcapp.Interface
{
    /// <summary>
    /// Interaction logic for Elemento.xaml
    /// </summary>
    public partial class ComandoValueView : UserControl
    {
        public ComandoValueView()
        {
            InitializeComponent();
        }

        private void txtComando_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            System.Windows.Controls.ComboBox cbx = null;

            if (e.OriginalSource != null && e.OriginalSource.GetType().Name.Contains("ComboBox"))
            {
                cbx = (System.Windows.Controls.ComboBox)e.OriginalSource;

            }
            //if (cbx != null && cbx.SelectedItem != null && cbx.SelectedItem.ToString() == "Caso Uso" && System.Windows.Application.Current != null && ((FtcViewModel)((MainWindow)System.Windows.Application.Current.MainWindow).FtcViewModel) != null)
            //{
            //    //var vm = ((MainWindow)System.Windows.Application.Current.MainWindow).FtcViewModel.VM;
            //    //var list = vm.BVMCasos.Select(a => a.Nome);

            //    //vm.SelectedCaso.SelectedComand.Values = new System.Collections.ObjectModel.ObservableCollection<string>(list);
            //}
        }









    }
}
