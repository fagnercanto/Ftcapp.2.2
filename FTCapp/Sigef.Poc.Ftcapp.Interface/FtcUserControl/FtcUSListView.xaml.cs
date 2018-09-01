using Sigef.Poc.Ftcapp.Interface.CustomControl;
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

namespace Sigef.Poc.Ftcapp.Interface.FtcUserControl
{
    /// <summary>
    /// Interaction logic for FtcUSListView.xaml
    /// </summary>
    public partial class FtcUSListView : UserControl
    {
        public FtcUSListView()
        {
            InitializeComponent();
            
        }

        private int _Tipo;
        public int Tipo
        {
            get{
                return _Tipo;
            
            }
            set {
                _Tipo = value;
                CCListView.Children.Add(Lview);
                
            }
        }


        public FtcCCListView Lview
        {
            
            get {
                EnumTipo eTipo = EnumTipo.CASO;
                try
                {
                    eTipo = (EnumTipo)Enum.ToObject(typeof(EnumTipo), Tipo);
                }
                catch {
                    var lvs = new FtcCCListView(eTipo);
                }

                var lv = new FtcCCListView(eTipo);
                   
                return lv;
            }
            
          
        }

        

        
    }
}
