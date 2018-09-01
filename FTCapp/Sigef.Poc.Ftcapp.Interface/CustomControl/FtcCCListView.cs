using Sigef.Poc.Ftcapp.Interface.ViewModelBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Sigef.Poc.Ftcapp.Interface.CustomControl
{
    public class FtcCCListView : ListView
    {


        
        public FtcCCListView(EnumTipo tipo)
        {
            SetBinding(tipo);
            View = GetGV(tipo);
        }

        

        private GridView GetGV(EnumTipo tipo){
            GridView gv = new GridView();
            
            switch (tipo)
            {

                case EnumTipo.SUITE:
                    gv.Columns.Add(GetGridViewColumn("Nome", "Nome"));
                    break;
                case EnumTipo.CASO:
                    gv.Columns.Add(GetGridViewColumn("Order", "Order"));
                    gv.Columns.Add(GetGridViewColumn("Nome", "Nome"));
                    break;
                case EnumTipo.COMANDO:
                    gv.Columns.Add(GetGridViewColumn("Order", "Order"));
	   gv.Columns.Add(GetGridViewColumn("Comando", "Valor"));
	   gv.Columns.Add(GetGridViewColumn("Valor Comando", "ValueText"));
	   gv.Columns.Add(GetGridViewColumn("Conteudoelemento", "ValueElemento"));
                    break;
                default:
                    break;
            }
            return gv;
        }
       

        private GridViewColumn GetGridViewColumn(string header, string display){
        GridViewColumn gvc = new GridViewColumn();
            gvc.Header = header;
            gvc.DisplayMemberBinding = new Binding { Path = new PropertyPath(display) };
            return gvc;
        }

        private string _ListViewName;

        private ViewBase _vb;

        private Binding _List;
        public void SetBinding(EnumTipo tipo)
        {
            
               var bv =  (BaseViewModel)FindResource("MVBaseViewModel");
               switch (tipo)
                {
                    
                    case EnumTipo.SUITE:
                         SetItemsSourceBinding(bv, "SelectedsSuites");
                         SetSelectedItemBinding(bv, "SelectedSuite"); 
                        _ListViewName = "LTSuite";
                        
                        break;
                    case EnumTipo.CASO:
                        SetItemsSourceBinding(bv,"SelectedSuite.Casos"); // new Binding { Source = bv, Path = new PropertyPath("SelectedSuite.Casos") };
                        SetSelectedItemBinding(bv,"SelectedSuite.SelectedCaso");// new Binding { Source = bv, Path = new PropertyPath("SelectedSuite.SelectedCaso") };
                        
                        _ListViewName = "LTCaso";
                        break;
                    case EnumTipo.COMANDO:
                        SetItemsSourceBinding(bv,"SelectedSuite.SelectedCaso.Comandos");// new Binding { Source = bv, Path = new PropertyPath("SelectedSuite.SelectedCaso.Comandos") };
                        SetSelectedItemBinding(bv,"SelectedSuite.SelectedCaso.SelectedComand");// new Binding { Source = bv, Path = new PropertyPath("SelectedSuite.SelectedCaso.SelectedComand") };

                        _ListViewName = "LTComando";
                        break;
                    default:
                        break;
                
        }}

        private object _SelectedObj;
        private string eTipo;
        private EnumTipo eTipo1;
        private Grid CCListView;

        public void SetItemsSourceBinding(object pSource, string path)
        {
            Binding myBinding = new Binding();
            myBinding.Source = pSource;
            myBinding.Path = new PropertyPath(path);
            myBinding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(this, ItemsSourceProperty, myBinding);
            
        }

        public void SetSelectedItemBinding(object pSource, string path)
        {
            Binding myBinding = new Binding();
            myBinding.Source = pSource;
            myBinding.Path = new PropertyPath(path);
            myBinding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(this, SelectedItemProperty, myBinding);

        }
    }
}
