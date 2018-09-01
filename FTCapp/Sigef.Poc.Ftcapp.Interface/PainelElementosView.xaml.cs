using Sigef.Poc.Ftcapp.Entidade;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PainelElementos2.xaml
    /// </summary>
    public partial class PainelElementoView : UserControl
    {
        public PainelElementoView()
        {
            InitializeComponent();
            
        }

        private Window GetMainWindow(){
        return ((MainWindow)System.Windows.Application.Current.MainWindow);
        }

        public double WidthPanelElemento
        {
            get { return PanelElementos.Width; }
            set
            {
                ColumnDefinition c =  (ColumnDefinition)GetMainWindow().FindName("LetfColumn");
                PanelElementos.Width = c.Width.Value;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ListBoxElements_Drop(object sender, DragEventArgs e)
        {
            var rs = Application.Current.Resources;
            var aa = rs["MVBaseViewModel"];
            //var vm = ((Sigef.Poc.Ftcapp.Interface.ViewModelBase.FtcViewModel)aa).VM;
            //vm.SelectedCaso.Comandos = (ObservableCollection<Comando>)((ListBox)sender).ItemsSource;
            Save();
        }

        private static void Save()
        {
            var rs = Application.Current.Resources;
            var aa = rs["MVBaseViewModel"];
           
            if (aa != null)
            {
                //vm.SelectedCaso.Comandos 
                
                //((Sigef.Poc.Ftcapp.Interface.ViewModelBase.FtcViewModel)aa).Save();
            }
        }

        private void ListBoxElements_Loaded(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void ListBoxElements_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            Save();
        }





        
    }
}
