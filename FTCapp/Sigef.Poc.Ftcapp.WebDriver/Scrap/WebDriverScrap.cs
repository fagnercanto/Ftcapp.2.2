using OpenQA.Selenium;
using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Const;
using System.Collections.Generic;
using System.Linq;


namespace Sigef.Poc.Ftcapp.WebDriver
{
    public class WebDriverScrap : WebDriverBase
    {

        //public DBObj rVM { get; set; }
        //public WebDriverScrap(DBObj VM)
        //    : base(VM)
        //{
        //    var uriConceito = new ConceitoBuilder().MontaUriConceito(VM.SelectedCaso.Transacao.NMPAGINA, VM.SelectedCaso.Transacao.CDTRANSACAO, ProjetoUtil._baseUri);
        //    AcessaConceito(uriConceito);
           
        //        VM.SelectedCaso.ScrapConfig.RuleLista.ToList().ForEach(e =>
        //        {
        //            VM = AddComandos(ScraapElements(e.XPath), VM);
        //        });
            
            
        //    AddComandos(ScraapElements(VM.SelectedCaso.ScrapConfig.XPathGenerico), VM);

        //    VM.SelectedCaso.Comandos = new System.Collections.ObjectModel.ObservableCollection<Comando>(new  ComandoBuilder().ConfigComandos(VM.SelectedCaso.Comandos.ToList(), VM));

        //    rVM = VM;

        //}

        //private DBObj AddComandos(List<Comando> list, DBObj VM)
        //{
        //    list.ForEach(e =>
        //    {
        //        //if (!VM.SelectedCaso.Comandos.Any(a => a.Elemento.Cod == e.Elemento.Cod) || e.Elemento.TagName == "td")
        //        //{
        //        VM.SelectedCaso.Comandos.Add(e);
        //        // }
        //    });
        //    return VM;
        //}


        //#region GetElements

        //private List<Comando> ScraapElements(string xPathExpression)
        //{
        //    List<Comando> ComandoLista = new List<Comando>();
        //    var defaultXpath = "//*[@id][not( contains(@id,'__VIEWSTATE') or contains(@id,'tooltip') or contains(@id,'hdn') or contains(@id,'hidden') or contains(@id,'tb') or contains(@id,'TD') or contains(@id,'lbl') or contains(@id,'div') or contains(@id,'Form1')  or contains(@id,'msg')   )]";


        //    if (string.IsNullOrEmpty(xPathExpression))
        //    {
        //        xPathExpression = defaultXpath;
        //    }
        //    var listWElements = _driver.FindElements(By.XPath(xPathExpression));

        //    listWElements.ToList().ForEach(e =>
        //    {
        //        if (e.TagName != "span" && e.TagName != "img")
        //        {
        //            Comando cmd = GetCommand(e, _VM);
        //            ComandoLista.Add(cmd);
        //        }

        //    });
        //    List<Comando> msgsComand = GetMsgs();
        //    ComandoLista.AddRange(msgsComand);
        //    return ComandoLista.Where(e => e.TipoControle != "").ToList();
        //}

        //private List<Comando> GetMsgs()
        //{
        //    Comando cmd = null;
        //    List<Comando> msgs = new List<Comando>();
        //    var els = _driver.FindElements(By.ClassName(ConstClassName.SIGEFMensagemErro));
        //    if (els.Count > 0)
        //    {
        //        var el = els[0];
        //        cmd = GetCommand(el, _VM);

        //    }

        //    if (cmd != null)
        //    {

        //        var success = (Comando)cmd.Clone();
        //        success = new Comando();
        //        success.Elemento.ClassName = ConstClassName.SIGEFMensagemSucesso;
        //        success.Elemento.Nome = "MSG Sucesso";
        //        cmd.Elemento.Nome = "MSG Erro";
        //        msgs.Add(cmd);
        //        msgs.Add(success);
        //    }

        //    return msgs;

        //}



        //#endregion


























    }
}
