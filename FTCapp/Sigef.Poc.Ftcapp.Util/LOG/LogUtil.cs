using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigef.Poc.Ftcapp.Util.LOG
{
    public class LogUtil
    {
        public void FormaTLogException(string Metodo, string Ex, string statck)
        {
            if (statck.Contains("//h4[contains(text(),'Carregando')]")) { return; }
            TraceInicioFim();
            TraceWriteLine(Ex, CONST.ConstTraceException.EXCEPTION);
            TraceWriteLine(Metodo, CONST.ConstTraceException.METODO);
            TraceWriteLine(statck, CONST.ConstTraceException.MSG);
            TraceInicioFim();
        }

        public void FormaTLogException(string Metodo, string Ex, string statck,string field, string MensagemPersonalisada)
        {
            TraceInicioFim();
            TraceWriteLine(Ex, CONST.ConstTraceException.EXCEPTION);
            TraceWriteLine(Metodo, CONST.ConstTraceException.METODO);
            TraceIdentAndUniIdent(MensagemPersonalisada, field);
            TraceWriteLine(statck, CONST.ConstTraceException.MSG);
            TraceInicioFim();
        }


        public void FormatTrace(string path){

            TextWriterTraceListener tr1 = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(tr1);
           
            TextWriterTraceListener tr2 = new TextWriterTraceListener(System.IO.File.CreateText(path));
            Debug.Listeners.Add(tr2);

        }

        public void TraceWriteLine(string value, string field)
        {
            System.Diagnostics.Debug.WriteLine("");
            //System.Diagnostics.Debug.WriteLine(value,field);
            System.Diagnostics.Debug.WriteLine("");
        }

        public void TraceInicioFim()
        {
            System.Diagnostics.Debug.WriteLine("");

            //System.Diagnostics.Debug.WriteLine(" - - - - - - ");
            
        }
        public void TraceOpenIdent()
        {
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.Indent();
            
        }

        public void TraceCloseIdent()
        {

            System.Diagnostics.Debug.Unindent();
            System.Diagnostics.Debug.WriteLine("");

        }

        public void TraceIdentAndUniIdent(string value,string field) {

            System.Diagnostics.Debug.Indent();
            TraceWriteLine(value, field);
            System.Diagnostics.Debug.Unindent();
        
        }
    }
}
