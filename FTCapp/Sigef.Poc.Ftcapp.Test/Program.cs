


using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Configuracoes;
using Sigef.Poc.Ftcapp.Entidade.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using Sigef.Poc.Ftcapp.Util;

using Sigef.Poc.Ftcapp.Crl;

using Sigef.Poc.Ftcapp.Util.Jason;
using Sigef.Poc.Ftcapp.WebDriver.Util;
using System.IO;
using Sigef.Poc.Ftcapp.Util.CONST;

namespace Test
{
    public class Program
    {
        /*
         
         * string xpathEstourouExcecaoNaTela = "//form[contains(@action,'Suporte/SIGEFErro.aspx')]";
            string XpathStackTrace = "//span[@id='lblDescricaoErro']";
            var xpathBtnvoltar = "//a[contains(@onclick,'history.back')]";
         * 
         *  //se voltar qualquer elLinkTransacao significa que estourou

            string xpathItensClicaveisGrid = "//TransacaoLogin[contains(@class,'Grid')]//td[@onclick]";
            string xpathGridItens = "//td[normalize-space(text())>3]";
            string xpathAbas = "//input[@type='image' and contains(@id,'Aba')]";
            string BotaoGridIrPRaProximaPagina = "pagFormulario_BtnAnterior";
         * 
         * itens cabecalho grid //TransacaoLogin[contains(@class,'GridCabecalho')]
            /*
           selection //select[contains(@class,'SIGEFComboBox')]/option
         * 
         *  ID quantidade de paginas pagFormulario_LblPaginacao
         */
        
        
        private static FTCappCrl _crl;
        
        private static List<Suite> _suites;
        
        private static Caso _CasoConceitoCurrent;
        private static Caso _CasoPesquisaCurrent;
        private static List<Elemento> _ElementosMenu;
        private static List<Elemento> _ElementosCurrent;
        private static string _XPATH_CONCEITO = "//*[tr[contains(@class,'GridCabecalho')]/ancestor::table[@id] or  (contains(name(),'a') and contains(@id,'btn')) or ((contains(name(),'textarea')) or (contains(name(),'input') and (contains(@type,'image') or contains(@type,'text') or contains(@type,'password') or contains(@type,'checkbox'))) or (contains(name(),'table')[@id and .//*[contains(@class,'Grid')]]) or (contains(name(),'img') and (contains(@id,'btnManutencao') or contains(@id,'Pesquisa') or contains(@id,'SIGEFBotoes'))) ) and not(contains(@style,'display:none'))]";
        private static string _XPATH_LOGIN = "//div[contains(@class,'login')]//following::*[(iux-button[@text='Acessar']/child::button) or name()='input']";
        private static string _XPATH_SUB_MENU = "//div[contains(@class,'transacao')]/child::a[string-length(@title)>2]";
        private static string _XPATH_TRANSACAO = "//div[contains(@class,'transacao')]/child::a[string-length(@title)>2]";
        private static string _XPATH_MENU_MODULO = "//div[contains(@class,'modulo')]/child::a[string-length(@title)>2]";
                                                  ////div[contains(@class,'modulo')]/child::a[string-length(@title)>2]
        private static JsonUtil _JsonUtil;
        private static FileUtil _FileUtil;
        private static Sigef.Poc.Ftcapp.Util.LOG.LogUtil _log;
        private static Transacao _currentTransacao;

        private static Caso _CasoMenu;
        private static Caso _CasoLogin;

        private const string CASO_LOGIN = "[1]";
        private const string CASO_MENU = "[2]";
        private const string CASO_MENU_MODULO = "[3]";
        private const string CASO_SUBMENU = "[4]";
        private const string CASO_TRANSACAO = "[5]";
        private const string CASO_INCLUIR = "[6]";
        private const string CASO_ALTERAR = "[7]";
        private const string CASO_CONSULTAR = "[8]";
        private const string CASO_PESQUISA = "[10]";

        private const string TRANSACAO_LOGIN = "[11]";
        private const string TRANSACAO_MENU = "[12]";
        private const string TRANSACAO_SUB_MENU = "[13]";
        private const string TRANSACAO_MANTER = "[14]";

        private const string SUITE_LOGIN = "[0][1]";
        private const string SUITE_MENU = "[0][2]";
        private const string SUITE_MENU_MODULO = "[0][3]";
        private const string SUITE_SUBMENU = "[0][4]";
        private const string SUITE_TRANSACAO = "[0][5]";
        private const string SUITE_TRANSACAO_PESQUISA_OBRIGATORIOS = "[0][6]";
        
        private const string SUITE_INCLUIR = "[1][7]";
        private const string SUITE_ALTERAR = "[2][8]";
        private const string SUITE_CONSULTAR = "[3][9]";
        private const string SUITE_TRANSACAO_PESQUISA = "[0][10]";

        private const string SUITE_LOGIN_NOME = "[Login]";
        private const string SUITE_MENU_NOME = "[Menu]";
        private const string CASO_LOGIN_NOME = "[Login]";
        private const string CASO_MENU_NOME = "[Menu]";

        static void Main(string[] args)
        {
            _log = new Sigef.Poc.Ftcapp.Util.LOG.LogUtil();
           string path =  LogStart("Teste1");
            _crl = new FTCappCrl();
            _FileUtil = new FileUtil();
            _JsonUtil = new JsonUtil();
            _crl.TestWebDriver();
            
            _suites = GetSuites();
            foreach (var item in _suites)
            {
                if (item.CasoLista == null)
                {
                    _crl.Remove(item);
                }
                foreach (var c in item.CasoLista)
                {
                    

                    foreach (var cm in c.ComandoLista) {
                        if (cm.Elemento == null) {
                            _crl.Remove(item);
                        }
                        
                    }

                    
                }

                
            }
                //else
            //        if (item.Nome == "[0][2][[Menu]]")
            //        {
            //            item.Nome = FormatNome(SUITE_MENU_NOME, SUITE_MENU);
            //            _crl.SuiteADD(item);
            //        }
            //        else {
            //            _crl.Remove(item);
            //        }

            //}

           ProcessUtil.KillProcess(CONST_PROCESS.MS_BUILD);
           

             Suite SuiteLogin = GetSuite(SUITE_LOGIN,SUITE_LOGIN_NOME);
             Suite SuiteMenu = GetSuite(SUITE_MENU, SUITE_MENU_NOME);

             _CasoLogin = GetCaso(CASO_LOGIN_NOME, CASO_LOGIN, 1);

             _CasoMenu = GetCaso(CASO_MENU_NOME, CASO_MENU, 2);

             #region Menu Modulo
             foreach (var el in _CasoMenu.Transacao.ElementoLista.Select(e=>ElementoToElementoTransacao(e)).ToList().Take(5)) {
                 
                  Suite suiteMenuModulo = GetSuite(el,null,SUITE_MENU_MODULO);
             }
             #endregion
             //3
             #region SUB MENU
              List<Suite> SuitesMenuModulo = SuiteList(SUITE_MENU_MODULO);

              foreach (var suite in SuitesMenuModulo.Take(3))
              {
                  Caso CasoMenuModulo = suite.CasoLista.Last();

                  foreach (var el in CasoMenuModulo.Transacao.ElementoLista.Select(e => ElementoToElementoTransacao(e)).ToList())
                  {
                      Suite suiteSubMenu = GetSuite(el, suite.CasoLista.ToList(), SUITE_SUBMENU);
                  }

              }
              #endregion
              //4

             #region TRANSACAO
              List<Suite> SuitesSubMenus = SuiteList(SUITE_SUBMENU);

              foreach (var suite in SuitesSubMenus)
             {
                 
                 Caso CasoSubMenu = suite.CasoLista.Last();
                 foreach (var el in CasoSubMenu.Transacao.ElementoLista.Select(e => ElementoToElementoTransacao(e)).ToList())
                 {
                     Suite SuiteTransacao = GetSuite(el, suite.CasoLista.ToList(), SUITE_TRANSACAO);

                     
                 }

                 

             }

              #endregion


            List<Suite> SuiteTransacoes = SuiteList(SUITE_TRANSACAO);


            #region OBRIGATORIOS E PESQUISA

            foreach (var suite in SuiteTransacoes)
            {

                Caso casoTransacao = suite.CasoLista.Last();
                _currentTransacao = casoTransacao.Transacao;
                casoTransacao.Transacao.NMPAGINA = casoTransacao.Nome;
                var ElementosTransacao = casoTransacao.Transacao.ElementoLista.Select(e => ElementoToElementoTransacao(e)).ToList();




                #region SUITE PESQUISA
                List<Suite> SuitesPesquisas = new System.Collections.Generic.List<Suite>();
                foreach (var el in casoTransacao.Transacao.ElementoLista.Select(e => ElementoToElementoTransacao(e)).ToList())
                {

                    if (el.TipoControle == ConstControlTypeUI.TYPE_PESQUISA)
                    {

                        Suite SuiTePesquisa = GetSuite(el, suite.CasoLista.ToList(), SUITE_TRANSACAO_PESQUISA);
                        SuitesPesquisas.Add(SuiTePesquisa);
                    }
                }
                #endregion
                Caso CasoIncluir = null;
                Caso CasoConsultar = null;
                Caso CasoAlterar = null;

                foreach (var el in casoTransacao.Transacao.ElementoLista.Select(e => ElementoToElementoTransacao(e)).ToList())
                {
                    if (el.TipoControle == ConstControlTypeUI.TYPE_BUTTON)
                    {
                        if (el.CodigoUi.Contains("BtnIncluir"))
                        {

                            CasoIncluir = GetCasoACAO(casoTransacao.Nome, "[INCLUIR]", CASO_INCLUIR, casoTransacao.Transacao, 1);
                            int order = CasoIncluir.ComandoLista.Max(e => e.Order) + 1;
                            Comando cmdClickIncluir = ADDCMD_CLICK(el, order);
                            CasoIncluir.ComandoLista.Add(cmdClickIncluir);
                        }
                        else if (el.CodigoUi.Contains("Consultar"))
                        {
                            CasoConsultar = GetCasoACAO(casoTransacao.Nome, "[CONSULTAR]", CASO_CONSULTAR, casoTransacao.Transacao, 1);
                            int order = CasoConsultar.ComandoLista.Max(e => e.Order) + 1;
                            Comando cmdClick = ADDCMD_CLICK(el, order);
                            CasoConsultar.ComandoLista.Add(cmdClick);
                        }
                        else if (el.CodigoUi.Contains("Alterar") != null)
                        {
                            CasoAlterar = GetCasoACAO(casoTransacao.Nome, "[ALTERAR]", CASO_CONSULTAR, casoTransacao.Transacao, 1);
                            int order = CasoAlterar.ComandoLista.Max(e => e.Order) + 1;
                            Comando cmdClick = ADDCMD_CLICK(el, order);
                            CasoAlterar.ComandoLista.Add(cmdClick);
                        }


                        Suite SuiteIncluir = NewSuiteACAO(casoTransacao.Nome, "[INCLUIR]", SUITE_INCLUIR, SuitesPesquisas, suite.CasoLista.ToList(), CasoIncluir);
                        Suite SuiteConsultar = NewSuiteACAO(casoTransacao.Nome, "[CONSULTAR]", SUITE_INCLUIR, SuitesPesquisas, suite.CasoLista.ToList(), CasoConsultar);
                        List<Caso> CasosMaisConsulta = new System.Collections.Generic.List<Caso>(suite.CasoLista);
                        CasosMaisConsulta.Add(CasoConsultar);
                        Suite SuiteAlterar = NewSuiteACAO(casoTransacao.Nome, "[ALTERAR]", SUITE_INCLUIR, SuitesPesquisas, CasosMaisConsulta, CasoConsultar);

                    }


                }
            }

            #endregion

                 
                 Console.Clear();

                 
                 Debug.Close();

        }

        private static Elemento ElementoToElementoTransacao(ElementoTransacao el)
        {
            Elemento elcopy = new Elemento();
            
            elcopy.TipoControle = el.TipoControle;
            elcopy.CodigoUi = el.CodigoUi;
            elcopy.ClassName = el.ClassName;
            elcopy.Nome = el.Nome;
            elcopy.Altura = el.Altura;
            elcopy.Largura = el.Largura;
            elcopy.X = el.X;
            elcopy.Y = el.Y;
            elcopy.Type = el.Type;
            elcopy.Displayed = el.Displayed;
            elcopy.Enabled = el.Enabled;
            elcopy.Selected = el.Selected;
            elcopy.TagName = el.TagName;
            elcopy.TabIndex = el.TabIndex;
            elcopy.Text = el.Text;
            elcopy.IsComposto = el.IsComposto;
            elcopy.IsObrigatorio = el.IsObrigatorio;
            elcopy.IsCampoPesquisa = el.IsCampoPesquisa;
            elcopy.CodigoComandoComposto = el.CodigoComandoComposto;
            elcopy.FindElementBy = el.FindElementBy;
            elcopy.onclick = el.onclick;
            elcopy.isGrid = el.isGrid;
            

            return elcopy;
        }


        private static ElementoTransacao ElementoToElementoTransacao2(Elemento el)
        {
            ElementoTransacao elcopy = new ElementoTransacao();

            elcopy.TipoControle = el.TipoControle;
            elcopy.CodigoUi = el.CodigoUi;
            elcopy.ClassName = el.ClassName;
            elcopy.Nome = el.Nome;
            elcopy.Altura = el.Altura;
            elcopy.Largura = el.Largura;
            elcopy.X = el.X;
            elcopy.Y = el.Y;
            elcopy.Type = el.Type;
            elcopy.Displayed = el.Displayed;
            elcopy.Enabled = el.Enabled;
            elcopy.Selected = el.Selected;
            elcopy.TagName = el.TagName;
            elcopy.TabIndex = el.TabIndex;
            elcopy.Text = el.Text;
            elcopy.IsComposto = el.IsComposto;
            elcopy.IsObrigatorio = el.IsObrigatorio;
            elcopy.IsCampoPesquisa = el.IsCampoPesquisa;
            elcopy.CodigoComandoComposto = el.CodigoComandoComposto;
            elcopy.FindElementBy = el.FindElementBy;
            elcopy.onclick = el.onclick;
            elcopy.isGrid = el.isGrid;


            return elcopy;
        }

        private static Suite NewSuiteACAO(string p1, string p2, string SuiteTIPO, System.Collections.Generic.List<Suite> SuitesPesquisas, List<Caso> casos,Caso CasoAcao)
        {
            Suite suiteACAO = new Suite();
            suiteACAO.Nome = FormatNome2(p1, p2, SuiteTIPO);
            suiteACAO.CasoLista = new List<Caso>(casos);
            foreach(var suite in SuitesPesquisas){
            suiteACAO.CasoLista.Add(suite.CasoLista.Last());
            }
            CasoAcao.Order = suiteACAO.CasoLista.Max(e => e.Order) + 1;
            suiteACAO.CasoLista.Add(CasoAcao);
            _crl.SuiteADD(suiteACAO); _suites = _crl.SuiteList();

            return suiteACAO;
        }


        
        private static Suite NewSuiteMenuModulo(Elemento el)
        {
           
            Suite suiteMenuModulo = NewSuite(el.Nome, SUITE_MENU_MODULO);

            //
            suiteMenuModulo.CasoLista = new System.Collections.Generic.List<Caso>();
            suiteMenuModulo.CasoLista.Add(_CasoLogin);
            suiteMenuModulo.CasoLista.Add(_CasoMenu);
            
            //
            #region CRIA CASO 
            
            Caso casoMenuModulo = GetCaso(el.Nome,CASO_MENU_MODULO, 3);
            
                Comando cmd = ADDCMD_CLICK(el, 1);
                casoMenuModulo.ComandoLista.Add(cmd);
                suiteMenuModulo.CasoLista.Add(casoMenuModulo);
            #endregion
                //

                #region SCRAP
                _ElementosCurrent = _crl.Scrapp(suiteMenuModulo);
                #endregion

            casoMenuModulo.Transacao.ElementoLista = _ElementosCurrent.Select(e => ElementoToElementoTransacao2(e)).ToList();
            
            #region CONFIG ELEMENTO BY XPATH
            foreach (var el1 in casoMenuModulo.Transacao.ElementoLista)
                {
                    el1.FindElementBy = ConstFindElementBy.BY_XPATH;
                    el1.CodigoUi = "//a[@title='" + el1.Nome.TrimStart().TrimEnd() + "']";
                }
            #endregion

            _crl.SuiteADD(suiteMenuModulo); _suites = _crl.SuiteList();
            return suiteMenuModulo;
        }

        private static string LogStart(string nome)
        {
            string path = "C:\\SIGEF\\SC\\Utilitarios\\FTCappPOC\\LOG\\LOG"+nome+".txt";

            new Sigef.Poc.Ftcapp.Util.LOG.LogUtil().FormatTrace(path);
            return path;
        }

       


        private static List<Suite> GetSuites()
        {
            var suitesIQuerable = _crl.SuiteIQueryable();


            if (suitesIQuerable == null || suitesIQuerable.Count() == 0)
            {
                _suites = new List<Suite>();
            }
            else
            {
                _suites = suitesIQuerable.ToList();
            }
            return _suites;
        }


        #region CASO MENU

        

        private static Caso NewCasoMenu( int order)
        {
            int ordercomando = 1;
            Suite SuiteScrapMenu = new Suite();
            SuiteScrapMenu.Nome = FormatNome(CASO_MENU_NOME, CASO_SUBMENU);
            Caso _CasoMenu = new Caso();

            _CasoMenu = NewCaso(CASO_MENU_NOME , CASO_MENU, order);

            _CasoMenu.Config.RuleLista.Add(new Rule { Nome = "xpathenerico", XPath = "//div[contains(@class,'modulo')]/child::a[string-length(@title)>2]" });
           
            _CasoMenu.ComandoLista.Add(ADDCMD_SWITCH_TO_IFRAME("//iframe", ordercomando++));
            Transacao tr = new Transacao();
            tr.NMPAGINA = "Menu";
            _CasoMenu.Transacao = tr;
            SuiteScrapMenu.CasoLista = new System.Collections.Generic.List<Caso>();
           

            
            SuiteScrapMenu.CasoLista.Add(_CasoLogin);
            SuiteScrapMenu.CasoLista.Add(_CasoMenu);
            _ElementosCurrent = _crl.Scrapp(SuiteScrapMenu);
            _CasoMenu.Transacao.ElementoLista = _ElementosCurrent.Select(e => ElementoToElementoTransacao2(e)).ToList();
           
            foreach (var el in _CasoMenu.Transacao.ElementoLista)
            {
                el.FindElementBy = ConstFindElementBy.BY_XPATH;
                el.CodigoUi = "//a[@title='" + el.Nome.TrimStart().TrimEnd() + "']";
            }
            _crl.SuiteADD(SuiteScrapMenu); _suites = _crl.SuiteList();
            ///SaveJsonCasoMenu(_CasoMenu);
            return _CasoMenu;
        }

        #endregion

        #region CASO LOGIN

        

        private static Caso NewCasoLogin(int orderCaso)
        {
            
            int ordercomando = 1;
            Suite SuiteLogin = new Suite();
            SuiteLogin.Nome = FormatNome(SUITE_LOGIN_NOME, SUITE_LOGIN);
            Caso casoLogin = NewCaso(CASO_LOGIN_NOME,CASO_LOGIN,orderCaso);
            casoLogin.Order = orderCaso;



            Comando ComandoAcessarLogin = ADDCMD_GO_TO("http://10.19.110.96/sigef/SIGEFPortal.html?p=1", ordercomando++);
                                                      
            Comando ComandoFrame = ADDCMD_SWITCH_TO_IFRAME("//iframe[1]", ordercomando++);
            casoLogin.ComandoLista.Add(ComandoAcessarLogin);
            casoLogin.ComandoLista.Add(ComandoFrame);
            
            SuiteLogin.CasoLista.Add(casoLogin);

            var xpathbutton = "//span[text()]/preceding::button[not(contains(@style,'display:none')) and not(contains(@style,'display:hidden')) and contains(@class,'btn-primary')]";
            var xpathsenha = "//input[@placeholder='Senha']";
            var xpathcpf = "//input[@placeholder='Usuário']";

            
            var rule1 = new Rule();
            var rule2 = new Rule();
            var rule3 = new Rule();
            rule1.Nome = "cpf";
            rule2.Nome = "password";
            rule3.Nome = "button";
            rule1.XPath = xpathcpf;
            rule2.XPath = xpathsenha;
            rule3.XPath = xpathbutton;
            casoLogin.Config.RuleLista.Add(rule1);
            casoLogin.Config.RuleLista.Add(rule2);
            casoLogin.Config.RuleLista.Add(rule3);

            List<Elemento> ElementosLoginScrap = _crl.Scrapp(SuiteLogin);
            
            //Comandos Login
            Elemento elementoCpf = ElementosLoginScrap[0];
            elementoCpf.FindElementBy = ConstFindElementBy.BY_XPATH;
            elementoCpf.CodigoUi = xpathcpf;
            Elemento elementoSenha = ElementosLoginScrap[1];
            elementoSenha.FindElementBy = ConstFindElementBy.BY_XPATH;
            elementoSenha.CodigoUi = xpathsenha;
            Elemento elementoBotao = ElementosLoginScrap[2];
            elementoBotao.FindElementBy = ConstFindElementBy.BY_XPATH;
            elementoBotao.CodigoUi = xpathbutton;
            Comando cmdInserirCpf = ADDCMD_INSERT(elementoCpf, "04088701925", ordercomando++);
            Comando cmdInserirSenha = ADDCMD_INSERT(elementoSenha, "sigef2018*", ordercomando++);
            Comando cmdClickBotao = ADDCMD_CLICK(elementoBotao, ordercomando++);

            casoLogin.ComandoLista.Add(cmdInserirCpf);
            casoLogin.ComandoLista.Add(cmdInserirSenha);
            casoLogin.ComandoLista.Add(cmdClickBotao);
            casoLogin.ComandoLista = new List<Comando>(casoLogin.ComandoLista);
            //casoLogin = InsereComandosScrapOnCasoLogin(ElementosLoginScrap, casoLogin, ordercomando++);
            //casoLogin.ComandoLista.Add(ADDCMD_GO_TO("http://10.19.110.96/sigef/SIGEFPortal.html?p=1", ordercomando++));
            SuiteLogin.CasoLista = new List<Caso>(SuiteLogin.CasoLista);
            casoLogin.Transacao = new Transacao();
            casoLogin.Transacao.NMTRANSACAO = FormatNome("LOGIN", TRANSACAO_LOGIN);
            casoLogin.Transacao.ElementoLista = ElementosLoginScrap.Select(e => ElementoToElementoTransacao2(e)).ToList();
            
            _crl.SuiteADD(SuiteLogin); _suites = _crl.SuiteList();
           
            
            
            return casoLogin;
        }

        private static void SaveJsonCasoLogin(string contentCasoLogin)
        {
            _FileUtil.FileWrite("C:\\SIGEF\\SC\\Utilitarios\\FTCappPOC\\BD\\CasoLogin.Json", contentCasoLogin);
        }

        private static Caso GetJsonCasoLogin()
        {
           Caso caso = new Caso();
           string content = _FileUtil.FileRead("C:\\SIGEF\\SC\\Utilitarios\\FTCappPOC\\BD\\CasoLogin.Json");
           return (Caso)_JsonUtil.StringToObjectConverter(content, caso);
        }

        private static void SaveJsonCasoMenu(Caso caso)
        {
            var contentCasoLogin = _JsonUtil.ObjectToStringConverter(caso);
            _FileUtil.FileWrite("C:\\SIGEF\\SC\\Utilitarios\\FTCappPOC\\BD\\CasoMenu.Json", contentCasoLogin);
        }

        private static Caso GetJsonCasoMenu()
        {
            Caso caso = new Caso();
            string content = _FileUtil.FileRead("C:\\SIGEF\\SC\\Utilitarios\\FTCappPOC\\BD\\CasoMenu.Json");
            return (Caso)_JsonUtil.StringToObjectConverter(content, caso);
        }

        private static void SaveJsonCasoMenuCategoria(Caso caso)
        {
            var contentCasoLogin = _JsonUtil.ObjectToStringConverter(caso);
            _FileUtil.FileWrite("C:\\SIGEF\\SC\\Utilitarios\\FTCappPOC\\BD\\MenuCategoria.Json", contentCasoLogin);
        }

        private static Caso GetJsonCasoMenuCategoria()
        {
            Caso caso = new Caso();
            string content = _FileUtil.FileRead("C:\\SIGEF\\SC\\Utilitarios\\FTCappPOC\\BD\\MenuCategoria.Json");
            return (Caso)_JsonUtil.StringToObjectConverter(content, caso);
        }

        #endregion

        #region CASO PESQUISA

        

        


        #endregion

        #region CASO CONCEITO



        

       

        #endregion

        #region Build Suite Generica Manter INCLUIR

       
        #endregion

        #region COMANDOS

        private static Comando ADDCMDCLICK(string id, int order)
        {

            return ADDCMD(id, id, ConstControlTypeUI.TYPE_BUTTON, ConstActionCommand.ACTION_CLICK, ConstTipoComando.TYPE_ACTION_ELEMENT, "acao", order);
        }

        private static Comando ADDCMDCLICK_BY_XPATH_ONCLICK(string Xpath, int order)
        {

            Comando el = ADDCMD(Xpath, Xpath, ConstControlTypeUI.TYPE_BUTTON, ConstActionCommand.ACTION_CLICK_ONCLIK, ConstTipoComando.TYPE_ACTION_ELEMENT, "acao", order);
            el.Elemento.FindElementBy = ConstFindElementBy.BY_XPATH;
            return el;
        }

        private static Comando ADDCMDCLICK_BY_XPATH(string Xpath, int order)
        {

            Comando el = ADDCMD(Xpath, Xpath, ConstControlTypeUI.TYPE_BUTTON, ConstActionCommand.ACTION_CLICK, ConstTipoComando.TYPE_ACTION_ELEMENT, "acao", order);
            el.Elemento.FindElementBy = ConstFindElementBy.BY_XPATH;
            return el;
        }

        private static Comando ADDCMDJS(string id, int order)
        {

            return ADDCMD(id, id, ConstControlTypeUI.TYPE_BUTTON, ConstActionCommand.ACTION_RUN_JS, ConstTipoComando.TYPE_ACTION_WEBDRIVER, id, order);
        }


        private static Comando ADDCMD_CLOSE_ALERT(int order)
        {
            return ADDCMD("Fechar Alerta", "WebManager", ConstControlTypeUI.TYPE_BUTTON, ConstActionCommand.ACTION_CLOSE_ALERT, ConstTipoComando.TYPE_ACTION_WEBDRIVER, "acao", order);
        }


        //SIGEFMensagemErro

        private static Comando ADDCMD_ISElementDisplayByClass(string className, int order)
        {
            string Xpaths = "//td[contains(@class,'className')]";
            Comando cmd = ADDCMD(className, Xpaths, ConstControlTypeUI.TYPE_CELL, ConstValidationCommand.IS_VISIBLE, ConstTipoComando.TYPE_VALIDATION_ELEMENT_STATE, "", order);
            cmd.Elemento.FindElementBy = ConstFindElementBy.BY_XPATH;
            return cmd;
        }
        private static Comando ADDCMD_CLICK(Elemento el, int order)
        {
            return ADDCMD(el, ConstActionCommand.ACTION_CLICK, ConstTipoComando.TYPE_ACTION_ELEMENT, "click", order);
           
        }
        private static Comando ADDCMD_INSERT_BY_VARIAVEL(Elemento el, string NomeVariavel, int order)
        {
            //string elNome, string elcodigo, string elTipocontrole, string valor, string tipocomando, string valorElemento, int order
            Comando cmd = ADDCMD(el, ConstActionCommand.ACTION_INSERT, ConstTipoComando.TYPE_ACTION_ELEMENT, NomeVariavel, order);
            
            return cmd;
        }
        


        private static Comando ADDCMD_INSERT_IF_EMPTY(Elemento el, string valorInserir ,int order)
        {
            return ADDCMD(el, ConstActionCommand.ACTION_INSERT_IF_EMPTY, ConstTipoComando.TYPE_ACTION_ELEMENT, valorInserir, order);      
        }

        private static Comando ADDCMD_INSERT(Elemento el, string valorInserir, int order)
        {
            return ADDCMD(el, ConstActionCommand.ACTION_INSERT, ConstTipoComando.TYPE_ACTION_ELEMENT, valorInserir, order);
        }

        private static Comando ADDCMD(string elNome, string elcodigo, string elTipocontrole, string valor, string tipocomando, string valorElemento, int order)
        {
                                     
            Elemento el = new Elemento();

            el.Nome = elNome;
            el.CodigoUi = elcodigo;
            el.TipoControle = elTipocontrole;
            el.FindElementBy = el.TipoControle==ConstControlTypeUI.TYPE_PAGINA?ConstFindElementBy.BY_NOT_FIND:ConstFindElementBy.BY_ID;
            return ADDCMD(el, valor, tipocomando, valorElemento, order); ;
        }


        private static Comando ADDCMD(Elemento el, string valor, string tipocomando, string valorElemento, int order)
        {

            Comando cmd = new Comando();
            
            cmd.TipoComando = tipocomando;
            cmd.Acao = valor;
            cmd.ValorElemento = valorElemento;
            cmd.Order = order;
            //ADD
            cmd.Elemento = ElementoToElementoTransacao(ElementoToElementoTransacao2(el));
            
            

            return cmd;
        }

        private static Comando ADDCMD_GO_BACK(int order)
        {
            return ADDCMD("LastPage", "WebManager", ConstControlTypeUI.TYPE_PAGINA, ConstActionCommand.ACTION_SWITCH_TO_BACK, ConstTipoComando.TYPE_ACTION_WEBDRIVER, "acao",order);
        }

        private static Comando ADDCMD_SWITCH_TO_LAST(int order)
        {
            return ADDCMD("SLastPage", "WebManager", ConstControlTypeUI.TYPE_PAGINA, ConstActionCommand.ACTION_SWITCH_TO_LAST, ConstTipoComando.TYPE_ACTION_WEBDRIVER, "acao", order);
        }

        private static Comando ADDCMD_SWITCH_TO_CONSTAIS(string valor, int order)
        {
            return ADDCMD("SWITCH_TO_LAST", "WebManager", ConstControlTypeUI.TYPE_PAGINA, ConstActionCommand.ACTION_SWITCH_TO_CONTAIS, ConstTipoComando.TYPE_ACTION_WEBDRIVER, valor, order);
        }

        
        private static Comando ADDCMD_SWITCH_TO_IFRAME(string xpath, int order)
        {

            return ADDCMD("SWITCH_TO_IFRAME", "WebManager", ConstControlTypeUI.TYPE_IFRAME, ConstActionCommand.ACTION_SWITCH_TO_FRAME, ConstTipoComando.TYPE_ACTION_WEBDRIVER, xpath, order); ;
        }


        private static Comando ADDCMD_SET_VARIAVEL(string nomeVariavel, int order,string findby)
        {
            Comando cmd = ADDCMD(nomeVariavel, "Variavel", ConstControlTypeUI.TYPE_CELL, ConstActionCommand.ACTION_SET_TEXT_VARIAVEL, ConstTipoComando.TYPE_VARIAVEL, nomeVariavel, order);
            cmd.Elemento.FindElementBy = findby;
            return cmd;
        }


        private static Comando ADDCMD_GO_TO(string url, int order)
        {

            return ADDCMD(url, "WebManager", ConstControlTypeUI.TYPE_PAGINA, ConstActionCommand.ACTION_GO_TO, ConstTipoComando.TYPE_ACTION_WEBDRIVER, url, order);

        }


        #endregion

        #region Uteis Genericos

        private static Caso NewCaso(string CasoNome, string CasoTipo, int order)
        {
            Caso caso = new Caso();
            caso.Nome = FormatNome(CasoNome,CasoTipo);
            caso.Order = order;
            return caso;
        }
        private static Caso GetCaso(string CasoNome, string CasoTipo, int order)
        {
            foreach(var suite in _suites){
                foreach (var caso in suite.CasoLista)
                {
                    if (caso.Nome == FormatNome(CasoNome, CasoTipo)) {
                        return caso;
                    }
                }
            }
            Caso obj = _crl.FindCasoByName(FormatNome(CasoNome,CasoTipo));
            if (obj == null) {
                if (CasoTipo == CASO_LOGIN || CasoTipo == "[Login]")
                {
                    obj = NewCasoLogin(order);
                    
                }else
                if (CasoTipo == CASO_MENU)
                {
                    obj = NewCasoMenu(order);
                }
                else
                    if (CasoTipo == CASO_MENU_MODULO)
                    {
                        obj = NewCasoMenuModulo(CasoNome, CasoTipo, order);
                    }
                    else
                        if (CasoTipo == CASO_SUBMENU || CasoTipo == "[x]")
                        {
                            obj = NewCasoSubMenu(CasoNome, CasoTipo, order);
                        }
                        else
                            if (CasoTipo == CASO_TRANSACAO)
                            {
                                obj = NewCasoTransacao(CasoNome, CasoTipo, order);
                            }
            }
            return obj;
        }

        private static Caso GetCasoACAO(string CasoNome, string acaoNome, string CasoTipo,Transacao transacao, int order)
        {
            foreach (var suite in _suites)
            {
                foreach (var caso in suite.CasoLista)
                {
                    if (caso.Nome == FormatNome2(CasoNome, acaoNome, CasoTipo))
                    {
                        return caso;
                    }
                }
            }
            Caso obj = _crl.FindCasoByName(FormatNome2(CasoNome,acaoNome,CasoTipo));
            if (obj == null) {
               
                    obj = NewCasoAcao(CasoNome,acaoNome,CasoTipo,transacao,order);
               
            }
            return obj;
        }

            private static Caso NewCasoAcao(string CasoNome,string acaoNome,string CasoTipo,Transacao transacao,int order)
            {
 	                    Caso CasoAcao = NewCaso(CasoNome,CasoTipo,order);

                        CasoAcao.Config.RuleLista.Add(new Rule { Nome = "xpathenerico", XPath = _XPATH_CONCEITO });
                        
                        CasoAcao.Transacao = transacao;
                        List<Comando> comandosInsertObrigatorio = ComandosInsertObrigatoriosIfEmpty(transacao.ElementoLista.Select(e=>ElementoToElementoTransacao(e)).ToList(), 1);
                        
                return CasoAcao;
            }

        private static Caso NewCasoTransacao(string CasoNome, string CasoTipo, int order)
        {
            Caso CasoTransacao = NewCaso(CasoNome,CasoNome,order, CASO_TRANSACAO,TRANSACAO_MANTER);
            CasoTransacao.Config.RuleLista.Add(new Rule { Nome = "xpathenerico", XPath = _XPATH_CONCEITO });
          
            
            return CasoTransacao;
        }

        private static Caso NewCasoSubMenu(string CasoNome, string CasoTipo, int order)
        {
            Caso casoSubMenu = NewCaso(CasoNome, CasoNome, order, CasoTipo, TRANSACAO_SUB_MENU);
            casoSubMenu.Config.RuleLista.Add(new Rule { Nome = "xpathenerico", XPath = _XPATH_SUB_MENU });

            return casoSubMenu;
        }

        private static Caso NewCasoMenuModulo(string CasoNome,string CasoTipo, int order)
        {

            //string CasoNome = FormatNome(el.Nome, CASO_MENU_MODULO);
            Caso casoMenuModulo = NewCaso(CasoNome,CasoNome,order, CasoTipo,TRANSACAO_MENU);
            casoMenuModulo.Config.RuleLista.Add(new Rule { Nome = "xpathenerico", XPath = _XPATH_MENU_MODULO });

            return casoMenuModulo;
            
        }


        private static Caso NewCaso(string CasoNome, string TransacaoNome, int order,string CASO_TIPO,string TRANSACAO_TIPO) {

            Caso caso = new Caso();

            caso.Nome = FormatNome(CasoNome, CASO_TIPO) ;
            caso.Order = order;
            Transacao tr = GetTransacao(TransacaoNome,TRANSACAO_TIPO);
            caso.Transacao = tr;
            
            return caso;
        }
        

        private static Suite GetSuite(Elemento el, List<Caso> casos,string SUITE_TIPO)
        {

            Suite obj = _crl.FindSuiteByName(FormatNome(el.Nome, SUITE_TIPO));
            if (obj == null)
            {
                if (SUITE_TIPO == "[X]")
                {
                    obj = NewSuiteSubMenu(el, casos,"[X]");
                }
                if (SUITE_TIPO == SUITE_MENU_MODULO)
                {
                    obj = NewSuiteMenuModulo(el);
                }
                if (SUITE_TIPO == SUITE_SUBMENU)
                {
                    obj = NewSuiteSubMenu(el, casos, SUITE_TIPO);
                }
                else if (SUITE_TIPO == SUITE_TRANSACAO)
                {
                    obj = NewSuiteTransacao(el, casos);
                }
                else if (SUITE_TIPO == SUITE_TRANSACAO)
                {
                    obj = NewSuitePesquisa(el,casos);
                }else if (SUITE_TIPO == SUITE_TRANSACAO_PESQUISA)
                {
                    obj = _crl.FindSuiteByName(FormatNome2(casos.Last().Nome,el.Nome, SUITE_TIPO));
                    if(obj==null){
                    obj = NewSuitePesquisa(el,casos);
                }
                 
                    }

                //else if (SUITE_TIPO == SUITE_CONSULTAR)
                //{
                //    obj = NewSuiteConsultar();
                //}
                //else if (SUITE_TIPO == SUITE_ALTERAR) { }
                //else
                //{
                //    obj = NewSuite(SuiteNome, SUITE_TIPO);
                //}

            }
            return obj;
        }

        private static Suite NewSuitePesquisa(Elemento el, System.Collections.Generic.List<Caso> casos)
        {

            Suite suitePesquisa = NewSuite(casos.Last().Nome + "[" + el.Nome + "]", SUITE_TRANSACAO_PESQUISA);
            suitePesquisa.CasoLista = new System.Collections.Generic.List<Caso>(casos);
               
                Caso casoPesquisa = new Caso();
                casoPesquisa.Nome = FormatNome2(casos.Last().Nome, el.Nome, SUITE_TRANSACAO_PESQUISA);
                Comando cmdClickpesquisar = ADDCMD_CLICK(el, 1);
                casoPesquisa.ComandoLista.Add(cmdClickpesquisar);
                casoPesquisa.ComandoLista.Add(ADDCMD_SWITCH_TO_LAST(2));
                casoPesquisa.Transacao = GetTransacao(FormatNome2(casos.Last().Nome, el.Nome, SUITE_TRANSACAO_PESQUISA), TRANSACAO_MANTER);
                Rule rule = new Rule { Nome = "GENERICO", XPath = _XPATH_CONCEITO };
                List<Rule> rules = new System.Collections.Generic.List<Rule>();
                rules.Add(rule);
                casoPesquisa.Config.RuleLista = new List<Rule>(rules);
                suitePesquisa.CasoLista.Add(casoPesquisa);
                var els = _crl.Scrapp(suitePesquisa);

                Comando cmdConfirmar = new Comando();
                Comando cmdFechar = new Comando();

                casoPesquisa.Transacao.ElementoLista = new List<Elemento>(els).Select(e=>ElementoToElementoTransacao2(e)).ToList();
                _crl.SuiteADD(suitePesquisa); _suites = _crl.SuiteList(); 
                List<Comando> comandosInsertObrigatorio = ComandosInsertObrigatorios(casoPesquisa.Transacao.ElementoLista.Select(e=>ElementoToElementoTransacao(e)).ToList(), 3);

                foreach (var cmd in comandosInsertObrigatorio)
                {
                    casoPesquisa.ComandoLista.Add(cmd);
                }

                foreach (var e in els.Select(e => e).ToList())
                {
                    if (e.CodigoUi == "btnConfirmar")
                    {
                        cmdConfirmar = ADDCMD_CLICK(e, 5);
                    }
                }
                casoPesquisa.ComandoLista.Add(cmdConfirmar);
                casoPesquisa.ComandoLista.Add(ADDCMDCLICK_BY_XPATH("//*[name()='td' and contains(@onclick,'SelecionarItem')][1]",6));
                casoPesquisa.ComandoLista = new List<Comando>(casoPesquisa.ComandoLista.OrderBy(e => e.Order).ToList());

                _crl.SuiteADD(suitePesquisa); _suites = _crl.SuiteList();
            return suitePesquisa;
        }

        private static Suite NewSuiteTransacao(Elemento el, List<Caso> casos)
        {
            
                Suite SuiteTransacao = NewSuite(el.Nome, SUITE_TRANSACAO);
                
                SuiteTransacao.CasoLista = new List<Caso>(casos);
                
                Caso CasoTransacao = GetCaso(el.Nome, CASO_TRANSACAO,5);
                CasoTransacao.ComandoLista.Add(ADDCMD_CLICK(el, 7));
                CasoTransacao.ComandoLista.Add(ADDCMD_SWITCH_TO_LAST(8));
                Rule rule = new Rule { Nome = "GENERICO", XPath = _XPATH_CONCEITO };
                List<Rule> rules = new System.Collections.Generic.List<Rule>();
                rules.Add(rule);
                CasoTransacao.Config.RuleLista = new List<Rule>(rules);
                SuiteTransacao.CasoLista = new List<Caso>(SuiteTransacao.CasoLista);
                SuiteTransacao.CasoLista.Add(CasoTransacao);
                CasoTransacao.Transacao.ElementoLista = _crl.Scrapp(SuiteTransacao).Select(e => ElementoToElementoTransacao2(e)).ToList();
                _crl.SuiteADD(SuiteTransacao); _suites = _crl.SuiteList();
                return SuiteTransacao;

        }

        private static Suite NewSuiteSubMenu(Elemento el, List<Caso> casos, string tipo)
        {
            //


            Suite suiteSubMenu = NewSuite(el.Nome, tipo);
            

            suiteSubMenu.CasoLista = new System.Collections.Generic.List<Caso>(casos);

            //int isTemCaso = 0;
            //foreach (var caso in casos)
            //{
            //    if (caso.Nome == FormatNome(el.Nome, CASO_MENU_MODULO))
            //    {
            //        isTemCaso++;
            //    }
            //}
            //if (isTemCaso == 0)
            //{
            //    Caso CasoSubMenuModulo = GetCaso(el.Nome, CASO_MENU_MODULO, 4);
            //    Comando cmd = ADDCMD_CLICK(el, 6);
            //    CasoSubMenuModulo.ComandoLista.Add(cmd);
            //    suiteSubMenu.CasoLista.Add(CasoSubMenuModulo);
            //}

            Caso CasoSubMenu = GetCaso(el.Nome, "[x]", 4);
            Rule rule = new Rule { Nome = "GENERICO", XPath = _XPATH_SUB_MENU };
            List<Rule> rules = new System.Collections.Generic.List<Rule>();
            rules.Add(rule);
            CasoSubMenu.Config.RuleLista = new List<Rule>(rules);
            CasoSubMenu.ComandoLista.Add(ADDCMD_CLICK(el, 1));
            suiteSubMenu.CasoLista.Add(CasoSubMenu);

            var ListElementos = _crl.Scrapp(suiteSubMenu).Select(e => ElementoToElementoTransacao2(e)).ToList();
                        CasoSubMenu.Transacao.ElementoLista = new List<ElementoTransacao>(ListElementos);

            foreach (var el1 in CasoSubMenu.Transacao.ElementoLista)
            {
                el1.FindElementBy = ConstFindElementBy.BY_XPATH;
                el1.CodigoUi = "//a[@title='" + el1.Nome.TrimStart().TrimEnd() + "']";
            }
            _crl.SuiteADD(suiteSubMenu); _suites = _crl.SuiteList();
            return suiteSubMenu;
        }
        private static Suite GetSuite(string SuiteNome, string SUITE_TIPO)
        {
            
            Suite obj = _crl.FindSuiteByName(FormatNome(SuiteNome, SUITE_TIPO));
            if (obj == null)
            {
                obj = NewSuite(SuiteNome, SUITE_TIPO); 
            }
            return obj;
        }

        private static string FormatNome(string Nome, string TIPO)
        {
            string formatNome = TIPO + "[" + Nome.TrimStart().TrimEnd() + "]";
            return formatNome;
        }

        private static string FormatNome2(string NomeCaso,string NomeElemento, string TIPO)
        {
            string formatNome = TIPO + "[" + NomeCaso.TrimStart().TrimEnd() + "]"+"["+NomeElemento+"]";
            return formatNome;
        }

        private static Suite NewSuite(string nome, string TIPO)
        {
            Suite obj = new Suite();
            obj.Nome = FormatNome(nome, TIPO);
            return obj;
        }

        private static Transacao GetTransacao(string Nome, string TIPO)
        {
           Transacao tr = _crl.FindTransacaoByName(FormatNome(Nome, TIPO));
            if(tr==null){
            tr = NewTransacao(Nome,TIPO);
            }
            return tr;
        }

        private static Transacao NewTransacao(string Nome, string TIPO)
        {
            Transacao tr = new Transacao();
            tr.NMPAGINA = FormatNome(Nome, TIPO);
            return tr;
        }

        //private static Caso GetCaso(string CasoNome, string TransacaoNome, int order, string CASO_TIPO, string TRANSACAO_TIPO)
        //{
        //    Caso tr = _crl.FindCasoByName(FormatNome(CasoNome, CASO_TIPO));
        //    if (tr == null)
        //    {
        //        tr = NewCaso(CasoNome, TransacaoNome,order,CASO_TIPO,TRANSACAO_TIPO);
        //    }
        //    return tr;
        //}

        private static Caso InsereComandosScrapOnCasoLogin(List<Elemento> ElementosScrap, Caso casoLogin, int order)
        {
            casoLogin.Transacao.ElementoLista = ElementosScrap.Select(e => ElementoToElementoTransacao2(e)).ToList();
            foreach (var elementologin in casoLogin.Transacao.ElementoLista.Select(e => ElementoToElementoTransacao(e)).ToList())
            {
                Comando newcmd = null;
                if (elementologin.TipoControle == ConstControlTypeUI.TYPE_TEXTBOX && elementologin.Type == "password")
                {
                    newcmd = ADDCMD(elementologin, ConstActionCommand.ACTION_INSERT, ConstTipoComando.TYPE_ACTION_ELEMENT, "sigef2018*", order);
                }
                else if (elementologin.TipoControle == ConstControlTypeUI.TYPE_TEXTBOX && elementologin.Type == "text")
                {
                    newcmd = ADDCMD(elementologin, ConstActionCommand.ACTION_INSERT, ConstTipoComando.TYPE_ACTION_ELEMENT, "04088701925", order);
                }
                else if (elementologin.TipoControle == ConstControlTypeUI.TYPE_BUTTON)
                {
                    newcmd = ADDCMD(elementologin, ConstActionCommand.ACTION_CLICK, ConstTipoComando.TYPE_ACTION_ELEMENT, "", order);
                }
                if (newcmd != null) {
                    casoLogin.ComandoLista.Add(newcmd);
                }
                
            }
            return casoLogin;
        }

        private static  void SetComandosInsertObrigatorios(Transacao tr, Caso CasoExecutaPesquisa, int order)
        {
            List<Comando> comandosInsertObrigatorio = ComandosInsertObrigatorios(tr.ElementoLista.Select(e=>ElementoToElementoTransacao(e)).ToList(),order);

            foreach (var item in comandosInsertObrigatorio)
            {
                CasoExecutaPesquisa.ComandoLista.Add(item);
            }
        }

        public static  List<Comando> ComandosInsertObrigatorios(List<Elemento> elementos,int order)
        {
            List<Comando> comandos = new List<Comando>();

            var elementosObrigatorios = elementos.Select(e=>e).Where(e => e.IsObrigatorio).ToList();
            var elementosObrigatoriosSemPesquisa = elementosObrigatorios.Select(e => e).Where(e => !e.IsCampoPesquisa && !e.IsBtnPesquisa);

            int i = 0;
            foreach (var campo in elementosObrigatoriosSemPesquisa)
            {
                comandos.Add(ADDCMD_INSERT(campo, campo.Id + (i++).ToString(), order++));
            }
            return comandos;
        }

        public static List<Comando> ComandosInsertObrigatoriosIfEmpty(List<Elemento> elementos, int order)
        {
            List<Comando> comandos = new List<Comando>();

            var elementosObrigatorios = elementos.Select(e => e).ToList().Where(e => e.IsObrigatorio);
            var elementosObrigatoriosSemPesquisa = elementosObrigatorios.Select(e => e).ToList().Where(e => !e.IsCampoPesquisa && !e.IsBtnPesquisa);

            int i = 0;
            foreach (var campo in elementosObrigatoriosSemPesquisa)
            {
                comandos.Add(ADDCMD_INSERT_IF_EMPTY(campo, campo.Id + (i++).ToString(), order++));
            }
            return comandos;
        }

        #endregion

        public static List<Suite> SuiteList(string nome)
        {
            
            return _suites.Where(e => e.Nome.Contains(nome)).ToList();
            
            
        }

        
        

    }
}
