using MahApps.Metro.Controls;
using System.Windows;

namespace Sigef.Poc.Ftcapp.Interface
{
    /// <summary>
    /// Interaction logic for ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : MetroWindow
    {
        private Size sz;

        public ChildWindow()
        {

            InitializeComponent();

        }

        public ChildWindow(Size sz)
        {
            InitializeComponent();
            this.sz = sz;
        }




        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.SizeToContent = SizeToContent.Manual;

            this.Width = this.sz.Width;
            this.Height = this.sz.Height;
            Point p = new Point(0, 0);
            this.PointFromScreen(p);

        }

    }
}
