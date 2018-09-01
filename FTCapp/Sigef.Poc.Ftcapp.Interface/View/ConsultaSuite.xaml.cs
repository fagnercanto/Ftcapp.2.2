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
using Sigef.Poc.Ftcapp.Interface.ViewModelBase;
using System.IO;
using System.Drawing.Imaging;
namespace Sigef.Poc.Ftcapp.Interface.View
{
    /// <summary>
    /// Interaction logic for ConsultaSuite.xaml
    /// </summary>
    public partial class ConsultaSuite : UserControl
    {
        public ConsultaSuite()
        {
            InitializeComponent();
        }

        private void ButtonCmd_Click(object sender, RoutedEventArgs e)
        {
            if (this.BaseViewModel == null)
            {
                this.BaseViewModel = (BaseViewModel)FindResource("MVBaseViewModel");
            }
            var image = BaseViewModel.SelectedSuite.SelectedCaso.ScreanShot;
            Image2.Source = ToImageSource(image, ImageFormat.Png);
            Infowindow iw = new Infowindow();
            DataGrid dti = (DataGrid)iw.FindName("infoDT");
            dti.ItemsSource = BaseViewModel.SelectedSuite.SelectedCaso.Comandos;
            iw.Show();
        }

        

        public ImageSource ToImageSource(System.Drawing.Image image, ImageFormat imageFormat)
        {
            BitmapImage bitmap = new BitmapImage();

            using (MemoryStream stream = new MemoryStream())
            {
                // Save to the stream
                image.Save(stream, imageFormat);

                // Rewind the stream
                stream.Seek(0, SeekOrigin.Begin);

                // Tell the WPF BitmapImage to use this stream
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
            }

            return bitmap;
        }

        private BaseViewModel _BaseViewModel;
        public BaseViewModel BaseViewModel
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
    }
}
