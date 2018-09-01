using MahApps.Metro.Controls;
using Sigef.Poc.Ftcapp.Interface.ViewModelBase;
using System.Windows;
namespace Sigef.Poc.Ftcapp.Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {

            InitializeComponent();
            if (this.FtcViewModel == null)
            {
                this.FtcViewModel = (BaseViewModel)FindResource("MVBaseViewModel");
            }


        }

       

        public GridLength WidthLeftColumnLength {
            get{return  LetfColumn.Width;}
            set{
                LetfColumn.Width = value;
            } 
        }

        

        private void LeftPanelTabControl_OnIsEmptyChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            if (e.NewValue)
            {
                //LeftPanelColumnDefinition.Width = GridLength.Auto;
                //TopPanelColumnDefinition.Height = GridLength.Auto;
            }

        }

        private void TopPanelTabControl_IsDraggingWindowChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            if (e.NewValue)
            {
                //LeftPanelColumnDefinition.Width = GridLength.Auto;
                //TopPanelColumnDefinition.Height = GridLength.Auto;
            }
        }

        

        private BaseViewModel _BaseViewModel;



        public BaseViewModel FtcViewModel
        {
            get
            {
                _BaseViewModel = null;
                var obj = FindResource("MVBaseViewModel");
                if (obj != null)
                {
                    _BaseViewModel = (BaseViewModel)obj;
                }
                return _BaseViewModel;

            }

            set
            {
                _BaseViewModel = value;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChildWindow childWindow = new ChildWindow();

            var us = new PainelElementoInfo();

            var sz = new Size(us.ActualWidth + 10, us.ActualHeight + 80);
            childWindow = new ChildWindow(sz);
            childWindow.Show();
        }
    }
}
