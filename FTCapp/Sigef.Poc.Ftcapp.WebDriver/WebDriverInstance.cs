using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Sigef.Poc.Ftcapp.WebDriver.Projeto;
using Sigef.Poc.Ftcapp.WebDriver.Util;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sigef.Poc.Ftcapp.WebDriver
{
    public class WebDriverInstance
    {
        protected List<IWebElement> _Elements;

        protected IWebDriver _driver;

        public IWebDriver driver
        {
            get
            {
                if (_driver == null)
                {
                 
var options = new ChromeOptions();
options.AddArgument("--headless");
//options.AddArgument("--disable-gpu");
//options.AddArgument("--no-sandbox");
//options.AddArgument("--ignore-certificate-errors");
//options.AddArgument("--disable-web-security");
//options.AddArgument("--allow-insecure-localhost");
//options.AddArgument("--allow-running-insecure-content");
//options.AddArgument("--acceptInsecureCerts=true");
//options.AddArgument("--disable-extensions");


//_driver = new ChromeDriver(options);
_driver = new ChromeDriver();
                    _driver.Manage().Window.Position = new System.Drawing.Point {X=0,Y=0 };
                    _driver.Manage().Window.Size = new System.Drawing.Size {Height=450,Width=500};
                    //_driver = new InternetExplorerDriver();
                    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                    //testc(_driver);
                }
                return _driver;
            }
        }

        //private void testc(IWebDriver _driver)
        //{
        //    _driver.Navigate().GoToUrl("http://10.19.110.96/sigef/SIGEFPortal.html?p=1");
        //    System.Threading.Thread.Sleep(5000);
        //    //IFRAME LOGIN
        //    var iframe = driver.FindElement(By.XPath("//iframe[1]"));
        //    System.Diagnostics.Debug.WriteLine("          IFRAME", iframe.GetAttribute("id"));
        //    _driver.SwitchTo().Frame(iframe);
        //    //CMAPOS LOGIN
        //    var els = _driver.FindElements(By.XPath("//input"));
        //    var btns = _driver.FindElements(By.TagName("button"));
        //    var xpathbutton = "//iux-button[@text='Acessar']/button";
        //    var xpathsenha = "//input[@placeholder='Senha']";
        //    var xpathcpf = "//input[@placeholder='Usuário']";
        //    var xpath1todos = "//div[contains(@class,'login')]//following::*[(name()='iux-button' and @text='Acessar') or name()='input']";
        //    var btn1 = _driver.FindElements(By.XPath(xpathbutton));
        //    var cpf1 = _driver.FindElements(By.XPath(xpathcpf));
        //    var usuario1 = _driver.FindElements(By.XPath(xpathsenha));
        //    var todos = _driver.FindElements(By.XPath("//div[contains(@class,'login')]//following::*[(name()='iux-button' and @text='Acessar')]/button"));
        //    btn1[0].Click();
        //    IWebElement BtnEnviar = null;
        //    foreach (var item in todos)
        //    {
                
                
        //        if (BtnEnviar==null && item.Displayed)
        //        {
        //            string text =  GetElementoSpanText(item);
        //            if (text == "Acessar") {
        //                BtnEnviar = item;
        //            }
        //        }
        //    }
            
        //    var elCpf = els[0];
        //    System.Diagnostics.Debug.WriteLine("          CPF", elCpf.GetAttribute("css"));
            
        //    var elPass = els[1];
        //    System.Diagnostics.Debug.WriteLine("          Senha", elPass.GetAttribute("css"));

        //    System.Diagnostics.Debug.WriteLine("          Btn", BtnEnviar.GetAttribute("css"));


        //    do
        //    {
        //        System.Diagnostics.Debug.WriteLine("          CPF value", elCpf.GetAttribute("value"));
                
        //        elCpf.SendKeys("04088701925");
        //    } while (elCpf.GetAttribute("value") != "04088701925");

        //    do
        //    {
        //        System.Diagnostics.Debug.WriteLine("          pass value", elPass.GetAttribute("value"));
        //        elPass.Clear();
        //        elPass.SendKeys("sigef2018*");
        //    } while (elPass.GetAttribute("value") != "sigef2018*");

           
            
        //    BtnEnviar.Click();

        //    ICollection<IWebElement> elss = null; 
        //    do
        //    {
        //       elss = _driver.FindElements(By.XPath("//input[@type='password']"));
        //       if (elss != null && elss.Count > 0) {
        //           System.Diagnostics.Debug.WriteLine("          btn presente na tela");
        //       }
               

                
        //    } while (elss != null && elss.Count > 0);
        //    // IR MENU
            
        //    _driver.Navigate().GoToUrl("http://10.19.110.96/sigef/SIGEFPortal.html?p=1");
            
        //    //IFRAME MENU
        //    //OpenQA.Selenium.StaleElementReferenceException
        //    IWebElement iframeMenu = null;
            
        //    do
        //    {
                
        //        iframeMenu = driver.FindElement(By.XPath("//iframe"));
                

        //    } while (!ElementoStaleValid(iframeMenu));
            
        //    _driver.SwitchTo().Frame(iframeMenu);
        //    ReadOnlyCollection<IWebElement> campoMenu = null;
        //    do
        //    {
        //        campoMenu = _driver.FindElements(By.XPath("//input[contains(@placeholder,'Pesquisar funcionalidades do sistema')]"));
        //    } while (campoMenu == null || campoMenu.Count==0);
                        
        //   //Menu
        //   var LinksMenu =  _driver.FindElements(By.TagName("a"));
           
        //  IWebElement Menu = null;
        //  do
        //  {
        //      Menu = GetFirstLinkComTextNomeParcial(LinksMenu, "Menu", "Administr");
        //  } while (Menu == null);
               
           
        //   Menu.Click();

        //    //CategoriaFunc

        //   var LinksCategorias = _driver.FindElements(By.TagName("a"));
        //   IWebElement Categoria = null;
        //   do
        //   {
        //       Categoria = GetFirstLinkComTextNomeParcial(LinksCategorias, "CategoriaFunc", "Administr");
        //   } while (Categoria == null);
        //   Categoria.Click();

        //   //Funcionalidades

        //   var LinkFuncionalidades = _driver.FindElements(By.TagName("a"));

        //              IWebElement FuncionalidadeManter = null;
        //   do
        //   {
        //       FuncionalidadeManter = GetFirstLinkComTextNomeParcial(LinkFuncionalidades, "Funcionalidades", "Manter Ag");
        //   } while (FuncionalidadeManter == null);
           
            
        //    FuncionalidadeManter.Click();

        //   _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        //   var xpath = "//*[( (contains(name(),'tr') and contains(@class,'GridCabecalho') and ancestor::table[@id]) or (contains(name(),'textarea')) or (contains(name(),'input') and (contains(@type,'image') or contains(@type,'text') or contains(@type,'password') or contains(@type,'checkbox'))) or (contains(name(),'table')[@id and .//*[contains(@class,'Grid')]]) or (contains(name(),'img') and (contains(@id,'btnManutencao') or contains(@id,'Pesquisa'))) ) and not(contains(@style,'display:none'))]  ";
        //   var elementos = _driver.FindElements(By.XPath(xpath));
        //   GetFirstLinkComNome(elementos,"elementos");
        //   /*
        //    txtBanco_SIGEFPesquisa
        //    txtBanco_BtnPesquisa
        //    txtCodigo
        //    txtNome
        //    txtNomeAbreviado
        //    txtPracaPagto
        //    chkFlTransferencia
        //    chkFlStatus
        //    btnManutencao_BtnIncluir
        //    btnManutencao_BtnAlterar
        //    btnManutencao_BtnConsultar
        //    btnManutencao_BtnListar
        //    btnManutencao_BtnLimpar
        //    btnManutencao_BtnAjuda
        //    btnManutencao_BtnFechar
        //    */

        //   var btnPesquisa = elementos.First(e => e.TagName == "img" && e.GetAttribute("id").Contains("Pesquisa"));
            

        //   var xpathGrid = "//table[@id and .//*[contains(@class,'Grid')]]";
        //   var grid = _driver.FindElements(By.XPath(xpathGrid));
        //   GetFirstLinkComNome(grid, "elementos");
        //   var xpgridx = "//*[contains(name(),'table')][@id and .//*[contains(@class,'Grid')]]";

        //   var gridx = _driver.FindElements(By.XPath(xpgridx));
        //   GetFirstLinkComNome(gridx, "elementos");
        //}

        private static bool ElementoStaleValid(IWebElement el)
        {
            bool isErro = true;
            try
            {
                System.Diagnostics.Debug.WriteLine("");
                System.Diagnostics.Debug.WriteLine("      ElementoStaleValid         " + el.Displayed);
                System.Diagnostics.Debug.WriteLine("");
            }
            catch (OpenQA.Selenium.StaleElementReferenceException exs)
            {
                new Sigef.Poc.Ftcapp.Util.LOG.LogUtil().FormaTLogException("ElementoStaleValid", exs.GetType().Name, exs.Message);
                isErro = false;
            }
            return isErro;
        }

        private string GetElementoSpanText(IWebElement item)
        {
            string result = "";
            var span = item.FindElements(By.TagName("span"));
            if (span != null && span.Count>0) {
                result = span[0].Text;
            }
            return result;
        }

        public bool IsDisplayed(IWebElement e){
            return e.Displayed;
        }
        private static IWebElement GetFirstLinkComNome(IEnumerable<IWebElement> Links, string tipo)
        {
            


            IWebElement result = null;
            
            foreach (var item in Links)
            {

                try
                {
                    System.Diagnostics.Debug.WriteLine(" ");
                    System.Diagnostics.Debug.WriteLine(item.Displayed);
                    System.Diagnostics.Debug.WriteLine(" ");
                }
                catch (OpenQA.Selenium.StaleElementReferenceException exs)
                {
                    return null;
                }

                bool text =  string.IsNullOrEmpty(item.Text);
                bool id = string.IsNullOrEmpty(item.GetAttribute("id"));
                if (!text)
                {
                    if (result == null) {
                        result = item;
                    }
                    System.Diagnostics.Debug.WriteLine(" ");
                    System.Diagnostics.Debug.WriteLine(item.Text);
                    System.Diagnostics.Debug.WriteLine(" ");
                }
                else if (!id) {
                    System.Diagnostics.Debug.WriteLine(item.GetAttribute("id"));
                }
            }
            
            return result;
        }

        private static IWebElement GetFirstLinkComTextNomeParcial(IEnumerable<IWebElement> Links, string tipo,string ParcialText)
        {
            IWebElement result = null;
           
            foreach (var item in Links)
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine(item.Displayed);
                }
                catch (OpenQA.Selenium.StaleElementReferenceException exs)
                {
                    new Sigef.Poc.Ftcapp.Util.LOG.LogUtil().FormaTLogException("GetFirstLinkComTextNomeParcial", exs.GetType().Name, exs.Message);
                    return null;
                }
                bool text = string.IsNullOrEmpty(item.Text);
                bool id = string.IsNullOrEmpty(item.GetAttribute("id"));
                if (!text && item.Text.Contains(ParcialText))
                {
                    if (result == null)
                    {
                        result = item;
                    }

                    
                }
               
            }
            
            return result;
        }


        public void DisposeInstance()
        {
            driver.Quit();
            ProcessUtil.ForceKill();
        }

        public AccessProject _acessInstance;
        public FuncionalidadeManager _funcInstance;
        public LoginManager _loginINstance;
        public ScrapElements _scrapInstance;
        public RunComando _runComandoInstance;
        public WebDriverInstance()
        {
            _acessInstance = new AccessProject(driver);
            _funcInstance = new FuncionalidadeManager(driver);
            _loginINstance = new LoginManager(driver);
            _scrapInstance = new ScrapElements(driver);
            _runComandoInstance = new RunComando(driver);
        }




        public byte[] GetScreanShot(string nome)
        {
            return ScreamShotUtil.GetScreamShot(driver, nome);
        }
    }
}
