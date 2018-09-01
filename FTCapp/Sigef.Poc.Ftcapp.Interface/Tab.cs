using Dragablz;
using System.Windows;
using System.Windows.Controls;

namespace Sigef.Poc.Ftcapp.Interface
{
    public class Tab : IInterTabClient
    {
        public INewTabHost<Window> GetNewHost(IInterTabClient interTabClient, object partition, TabablzControl source)
        {
            ChildWindow childWindow = new ChildWindow();

            var us = (UserControl)source.SelectedContent;
            var sz = new Size(us.ActualWidth + 10, us.ActualHeight + 80);
            childWindow = new ChildWindow(sz);


            //if (source.SelectedContent.GetType().Name == typeof(ScrappView).Name) {
            //     sz = new Size(280, 120);
            //    childWindow = new ChildWindow(sz);
            //}else
            //    if (source.SelectedContent.GetType().Name == typeof(PainelElementoView).Name)
            //    {
            //        sz = new Size(650, 500);
            //        childWindow = new ChildWindow(sz);
            //    }else
            //if (source.SelectedContent.GetType().Name == typeof(ConsultaCaso).Name)
            //{
            //     sz = new Size(250, 500);
            //    childWindow = new ChildWindow(sz);
            //}else
            //if (source.SelectedContent.GetType().Name == typeof(PainelElementoInfo).Name)
            //{
            //     sz = new Size(500, 300);
            //    childWindow = new ChildWindow(sz);
            //}


            var nw = new NewTabHost<Window>(childWindow, childWindow.ChildWindowTabablzControl);

            return nw;
        }

        public TabEmptiedResponse TabEmptiedHandler(TabablzControl tabControl, Window window)
        {
            return window is MainWindow ? TabEmptiedResponse.DoNothing : TabEmptiedResponse.CloseWindowOrLayoutBranch;
        }
    }
}
