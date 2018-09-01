

using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Configuracoes;
using Sigef.Poc.Ftcapp.Entidade.Const;
using Sigef.Poc.Ftcapp.Service;
using Sigef.Poc.Ftcapp.Service.Interfaces;
using Sigef.Poc.Ftcapp.Util.Byte;
using Sigef.Poc.Ftcapp.Util.LOG;
using Sigef.Poc.Ftcapp.Util.ValidateEnums;
using Sigef.Poc.Ftcapp.WebDriver;
using Sigef.Poc.FTCapp.Util.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Sigef.Poc.Ftcapp.Crl
{
    public class FTCappCrl
    {

        public ISuiteService suiteService{get{return _suiteService;}}
        public ICasoService casoService { get { return _casoService; } }
        public ITransacaoService transacaoService { get { return _transacaoService; } }

        ISuiteService _suiteService;
        ICasoService _casoService;
        ITransacaoService _transacaoService;
        IComandoService _comandoService;
        IElementoService _elementoService;

        public FTCappCrl() {
            _suiteService = new SuiteService();
            _casoService = new CasoService();
            _transacaoService = new TransacaoService();
            _comandoService = new ComandoService();
            _elementoService = new ElementoService();
        }

        private LogUtil _log;

        public LogUtil log{
            get
            {
                if (_log == null) { _log = new LogUtil(); }
        return _log;
        }
        set{ _log =value;}
        }
        //public Suite NewSuite() {
        //    return DBManager.NewSuite();
        //}

        //private DBManager DBManager;

        //private DBManager _DBManager
        //{
        //    get
        //    {
        //        if (DBManager == null)
        //        {
        //            DBManager = new DBManager();
        //        }

        //        return DBManager;
        //    }

        //}

        //public  object List(EnumEntidade etd){
        //   var result =  _DBManager.List(etd);
        //   return result;
        //}

        //public List<Suite> ListSuites()
        //{
        //    var lt = (List<Suite>)List(EnumEntidade.Suite);
        //    return lt;
        //}

        public List<Elemento> Scrapp(Suite suite)
        {
           
            WebDriverInstance wbInstance = new WebDriverInstance();
            string Xpath = GetXpath();
            
            RunSuite(suite, wbInstance);
            var ruleList = GetXpathByLastCaso(suite);
            SetScrenShotTela(suite, wbInstance);
            if(ruleList.Count()==0){
                ruleList.Add(new Rule{Nome="GENERICO",XPath= Xpath});
            }
            
             List<Elemento> list = Scrapp(wbInstance, ruleList);
#if DEBUG
            foreach (var item in list) {
            

                            log.TraceInicioFim();
                            log.TraceWriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name, Sigef.Poc.Ftcapp.Util.CONST.ConstTraceException.METODO);
                            log.TraceWriteLine(suite.Nome, Sigef.Poc.Ftcapp.Util.CONST.ConstTraceField.SUITE);
                            log.TraceIdentAndUniIdent(item.Nome, Sigef.Poc.Ftcapp.Util.CONST.ConstTraceField.ELEMENTO);
                            log.TraceInicioFim();

           
                
            }
            #endif
            wbInstance.DisposeInstance();
            
            return list;
        }




        public void TestWebDriver()
        {

            WebDriverInstance wbInstance = new WebDriverInstance();
            

           
        }

        private static List<Elemento> Scrapp(WebDriverInstance wbInstance, ICollection<Rule> ruleList)
        {
            ElementoBuilder _ElementoBuilder = new ElementoBuilder();

            List<Elemento> list = new List<Elemento>();

            List<ElementoScrap> esps = wbInstance._scrapInstance.GetSharedElements(ruleList);

            foreach (var esp in esps) {
                Elemento elemento = new Elemento();
                _ElementoBuilder.BuildElemento(
                    elemento,
                    esp.Selected,
                    esp.TagName,
                    esp.Enable ,
                    esp.Displayed ,
                    esp.Text ,
                    esp.Type ,
                    esp.Height ,
                    esp.Width ,
                    esp.X ,
                    esp.Y ,
                    esp.ClassName ,
                    esp.UICodigo ,
                    esp.Label ,
                    esp.OnClick ,
                    esp.IsGrid ,
                    esp.IsCampoPesquisa,
                    esp.TabIndex
                    );
                if (elemento.TipoControle == ConstControlTypeUI.TYPE_COMBOBOX)
                {
                    elemento.OptionValues = wbInstance._scrapInstance.GetComboboxOptions(elemento.CodigoUi);
                }

                list.Add(elemento);
            }

           
            

                    

                    
                
            return list;
        }

        private static ICollection<Rule> GetXpathByLastCaso(Suite suite)
        {
            List<Rule> result = null;
            Caso lastCaso = null;
            if (suite.CasoLista.Count > 0) {
                lastCaso = suite.CasoLista.Last();

                if (lastCaso.Config != null) {
                    result = lastCaso.Config.RuleLista.ToList();
                }
                return result;
            }

            return lastCaso.Config.RuleLista;
        }

        private static void SetScrenShotTela(Suite suite,WebDriverInstance wbInstance)
        {
            
            Caso lastCaso = null;
            if (suite.CasoLista.Count > 0)
            {
                lastCaso = suite.CasoLista.Last();
            }
            
            lastCaso.ScrenShotBytes =  wbInstance.GetScreanShot(lastCaso.Nome);
           
        }

        public Suite RunTeste(Suite suite)
        {
            WebDriverInstance wbInstance = new WebDriverInstance();
            RunSuite(suite, wbInstance);
            wbInstance.DisposeInstance();
            return suite;
        }

        private void RunSuite(Suite suite, WebDriverInstance wbInstance)
        {

            wbInstance._runComandoInstance.SetVariaveis(suite.VariavelLista.ToList());
#if DEBUG

            log.TraceInicioFim();
            log.TraceWriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name, Sigef.Poc.Ftcapp.Util.CONST.ConstTraceException.METODO);
            log.TraceWriteLine(suite.Nome, Sigef.Poc.Ftcapp.Util.CONST.ConstTraceField.SUITE);
            log.TraceInicioFim();

#endif
           
            bool isPassou = true;
            //bool isAlert = false;
            
                foreach (var caso in suite.CasoLista) {
                    //if (caso.ComandoLista.Count > 0) {
                    //    if (!isAlert) {
                    //isPassou = 
                    System.Diagnostics.Debug.Indent();
                    RunCaso(caso, wbInstance);
                    System.Diagnostics.Debug.Unindent();
                    //}
                    //isPassou = ConfigCasoStatus(isPassou, caso, isAlert);
                    //if (!isPassou) {
                    //    isAlert = true;
                    //}
                    // }
                }

                suite.VariavelLista = new List<Variavel>(wbInstance._runComandoInstance.GetVariaveis());
                
        }

        private static bool ConfigCasoStatus(bool isPassou, Caso caso, bool isAlert)
                    {

                        if (isAlert)
                        {
                            caso.status = ConstCasoStatus.STATUS_ALERT;
                        }
                        else {
                            switch (caso.RunTipo)
                            {
                                case ConstRunTipo.RUN_ACCESS:
                                    isPassou = caso.UrlAccess == caso.LastUrl;
                                    break;
                            }
                            caso.status = isPassou ? ConstCasoStatus.STATUS_PASSOU : ConstCasoStatus.STATUS_NAO_PASSOU;

                        }
                                                                        
                    return isPassou;
                    }


        private bool RunCaso(Caso caso,WebDriverInstance i)
        {
            caso.ComandoLista = caso.ComandoLista.OrderBy(e => e.Order).ToList();
            int qtdNpassou = 0;
#if DEBUG
            if (caso.Nome.Contains("Pesquisar")) {
                log.TraceWriteLine(caso.Nome, Sigef.Poc.Ftcapp.Util.CONST.ConstTraceField.CASO);
            }
            log.TraceInicioFim();
            log.TraceWriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name, Sigef.Poc.Ftcapp.Util.CONST.ConstTraceException.METODO);
            log.TraceWriteLine(caso.Nome, Sigef.Poc.Ftcapp.Util.CONST.ConstTraceField.CASO);
            log.TraceInicioFim();

#endif

            foreach (var cmd in caso.ComandoLista)
            {
                if (cmd != null)
                {
                    System.Diagnostics.Debug.Indent();
                    if (!i._runComandoInstance.Run(cmd))
                    {
                        qtdNpassou++;
                    }
                    System.Diagnostics.Debug.Unindent();
                }

            }
           
           
            return true;
        }



        

        public string GetXpath() {
            return "//*[tr[contains(@class,'GridCabecalho')]/ancestor::table[@id] or  (contains(name(),'a') and contains(@id,'btn')) or ((contains(name(),'textarea')) or (contains(name(),'input') and (contains(@type,'image') or contains(@type,'text') or contains(@type,'password') or contains(@type,'checkbox'))) or (contains(name(),'table')[@id and .//*[contains(@class,'Grid')]]) or (contains(name(),'img') and (contains(@id,'btnManutencao') or contains(@id,'Pesquisa') or contains(@id,'SIGEFBotoes'))) ) and not(contains(@style,'display:none'))]";
        
        
        }

        public void SuiteADD(Suite suite){

            
            foreach(var caso in suite.CasoLista){
                if (caso.Transacao == null) {
                    caso.Transacao = new Transacao();
                    caso.Transacao.NMTRANSACAO = caso.Nome;
                    
                }
                
                foreach (var cmd in caso.ComandoLista) {
                    cmd.Elemento.OptionValues = new List<ValorSugestao>(cmd.Elemento.OptionValues);
                }
                caso.ComandoLista = new List<Comando>(caso.ComandoLista);
                caso.Config.RuleLista = new List<Rule>(caso.Config.RuleLista);
            }
            
            suite.CasoLista = new List<Caso>(suite.CasoLista);
            _suiteService.AddSuite(suite);
            
        }

        public Suite SuiteFind(int  id)
        {
           return  _suiteService.Find(id);

        }

        public List<EnumValidateModel> SuiteValidate(Suite suite)
        {
           return _suiteService.Validate(suite);

        }

        public void Remove(Suite suite)
        {
            _suiteService.Remove(suite);

        }

        public IQueryable<Suite> SuiteIQueryable()
        {

            var suitesIQuerable = _suiteService.List();

            return suitesIQuerable;


            

        }

        public List<Suite> SuiteListByContais(List<string> contains,int count)
        {
            List<Suite> rs = null;
            
            var suitesIQuerable = _suiteService.List();
                
            if (suitesIQuerable == null || suitesIQuerable.Count() == 0)
            {
                rs = new List<Suite>();
            }
            else
            {
                List<Suite> rsList = null;
                rs = suitesIQuerable.ToList();
                if(count==1){
                    rsList = rs.Where(e =>
                        Constains1(contains, e)
                        ).ToList();
                }else if(count==2){
                    rsList = rs.Where(e =>
                        Constains2(contains, e)
                        ).ToList();
                }else if(count==3){
                    rsList = rs.Where(e =>
                        Constains3(contains, e)
                        ).ToList();
                    
                    
                }
                if (rsList.Count > 0) {
                    rs = rsList;
                }
                
            }
            return rs;

        }

        

        private static bool Constains1(List<string> contains, Suite e)
        {
            return e.Nome.Contains(contains[0]);
        }

        private static bool Constains2(List<string> contains, Suite e)
        {
            return e.Nome.Contains(contains[0]) &&
                            e.Nome.Contains(contains[1]) ;
        }

        private static bool Constains3(List<string> contains, Suite e)
        {
            bool result =  e.Nome.Contains(contains[0]) &&
                            e.Nome.Contains(contains[1]) &&
                            e.Nome.Contains(contains[2]);
            return result;
        }

        public List<Suite> SuiteList(string nome)
        {
            List<Suite> rs = null;
            var suitesIQuerable = _suiteService.List().Where(e => e.Nome.Contains(nome));
            if (suitesIQuerable == null || suitesIQuerable.Count() == 0)
            {
                rs = new List<Suite>();
            }
            else
            {
                rs = suitesIQuerable.ToList();
            }
            return rs;

        }

        public List<Suite> SuiteList()
        {
            List<Suite> rs = null;
            var suitesIQuerable = _suiteService.List();
            if (suitesIQuerable == null || suitesIQuerable.Count() == 0)
            {
                rs =  new List<Suite>();
            }
            else
            {
                rs = suitesIQuerable.ToList();
            }
            return rs;

        }





        public Caso FindCasoByName(string p)
        {
           return _casoService.FindCasoByName(p).FirstOrDefault();
        }

        public Transacao FindTransacaoByName(string p)
        {
            return  transacaoService.FindTransacaoByName(p).FirstOrDefault();
        }

        public Suite FindSuiteByName(string p)
        {
            return suiteService.FindSuiteByName(p).FirstOrDefault();
        }

        public Comando FindComando(int id)
        {
            return _comandoService.Find(id);
        }
        public Elemento FindElemento(int id)
        {
            return _elementoService.Find(id);
        }

        public void ADDComando(Comando id)
        {
            _comandoService.Add(id);
        }
        public void ADDElemento(Elemento id)
        {
            _elementoService.Add(id);
        }
    }
}

