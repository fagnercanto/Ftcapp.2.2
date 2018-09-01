using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Const;
using Sigef.Poc.Ftcapp.Util.CONST;
using Sigef.Poc.Ftcapp.WebDriver;
using Sigef.Poc.Ftcapp.WebDriver.Util;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Sigef.Poc.Ftcapp.WebDriver
{
    public class RunComando : WebDriverPai
    {

        public void SetVariaveis(List<Variavel> variaveis){
        Variaveis = variaveis;
        }

        public List<Variavel> GetVariaveis()
        {
           return Variaveis;
        }


        public RunComando(OpenQA.Selenium.IWebDriver _driver)
        {
            driver = _driver;
        }

        public bool Run(Comando cmd) {
            

            
            bool result = false;
            cmd.Resultado = new Resultado();
            cmd.Resultado.status = ConstResultadoStatus.STATUS_INICIADO;
            try
            {
                result = RunCmd(cmd);
            }
            catch (StaleElementReferenceException ex) {
                log.FormaTLogException(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.GetType().Name, ex.Message);
                //Run(cmd);
            }
            catch (Exception ex)
            {
                log.FormaTLogException(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.GetType().Name, ex.Message);
                ExeptionReturnConfig(cmd.Resultado, ex, driver);
            }
             #if DEBUG

            log.TraceInicioFim();
            log.TraceWriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name, Sigef.Poc.Ftcapp.Util.CONST.ConstTraceException.METODO);
            log.TraceIdentAndUniIdent(cmd.Elemento.Nome, Sigef.Poc.Ftcapp.Util.CONST.ConstTraceField.ELEMENTO);
            log.TraceInicioFim();

            #endif
            return result;
        }

        public bool RunCmd(Comando cmd)
        {
            IWebElement el;
            bool isPassou = true;
            cmd.Url = driver.Url;
            string valorElementocopy = cmd.ValorElemento;
            cmd = ConfigValorElemento(cmd);
                switch (cmd.TipoComando)
                {
                    case ConstTipoComando.TYPE_VARIAVEL:
                        el = FindElementReturNull(cmd);
                        isPassou = RunVariavel(cmd,el);
                        break;
                    case ConstTipoComando.TYPE_ACTION_WEBDRIVER:
                        isPassou = RunActionWebDriverComand(cmd.Acao, cmd.ValorElemento);
                        break;
                    case ConstTipoComando.TYPE_ACTION_ELEMENT:
                        el = FindElementReturNull(cmd);
                        isPassou = RunActionComand(cmd.Acao, el, cmd.ValorElemento);
                        break;
                    case ConstTipoComando.TYPE_VALIDATION_ELEMENT_STATE:
                        el = FindElementReturNull(cmd);
                        isPassou = RunValidationElementoState(cmd.Resultado, cmd.Acao, el);
                        break;
                    case ConstTipoComando.TYPE_VALIDATION_ELEMENT_VALUE:
                        el = FindElementReturNull(cmd);
                        isPassou = RunValidationElementoValor(cmd.Resultado, cmd.Acao, cmd.ValorElemento, el.Text);
                        break;
                }
                if (!isPassou)
                {
                    cmd.Resultado.status = ConstResultadoStatus.STATUS_NAO_PASSOU;
                    string nome = cmd.CasoLista.Last().Nome + cmd.Id;
                    cmd.Resultado.ScrenShotBytes = ScreamShotUtil.GetScreamShot(driver, nome+"["+cmd.Resultado.status+"]");
                }
                else
                {
                    
                    cmd.Resultado.status = ConstResultadoStatus.STATUS_PASSOU;
                    string nome = cmd.Elemento.CodigoUi + cmd.Id;
                    cmd.Resultado.ScrenShotBytes = ScreamShotUtil.GetScreamShot(driver, nome + "[" + cmd.Resultado.status + "]");
                }
                cmd.ValorElemento = valorElementocopy;
                return isPassou;
        }

        private Comando ConfigValorElemento(Comando cmd)
        {
            switch (cmd.TipoValorElemento) { 
                case ConstValorElementoTipo.VARIAVEL:
                    Variavel variavel = Variaveis.FirstOrDefault(e => e.Nome == cmd.ValorElemento);
                    cmd.ValorElemento = variavel.Valor;
                    break;
                default:
                    break;
                    
            }
            return cmd;
        }

        private static void ExeptionReturnConfig(Resultado rs, Exception ex, IWebDriver driver)
        {
            try
            {
                if (ex.GetType().Name.Contains("NullReference"))
                {
                    rs.status = ConstResultadoStatus.STATUS_WEBDRIVER_EXCEPTION;
                }
                else
                if (ex.GetType().Name.Contains("NoSuchWindowException"))
                {
                    rs.status = ConstResultadoStatus.STATUS_WEBDRIVER_EXCEPTION;
                }else
                if (ex.GetType().FullName.Contains("WebDriver"))
                {
                    rs.status = ConstResultadoStatus.STATUS_WEBDRIVER_EXCEPTION;
                }
                else if (ex.GetType().FullName.Contains("Browser"))
                {
                    rs.status = ConstResultadoStatus.STATUS_BROSWER_EXCEPTION;
                }
                else if (driver != null)
                {
                    var a = driver.FindElements(By.XPath("//form[contains(@action,'Suporte/SIGEFErro.aspx')]"));
                    if (a != null&& a.Count>0)
                    {
                        rs.status = ConstResultadoStatus.STATUS_PAGINA_EXCEPTION;
                        var feedbackResult = driver.FindElements(By.XPath("//span[@id='lblDescricaoErro']")).FirstOrDefault();
                        if (feedbackResult != null)
                        {
                            rs.feedBack = feedbackResult.Text;
                            rs.ScrenShotBytes = ScreamShotUtil.GetScreamShot(driver, rs.status);
                        }
                    }
                }
            }
            finally
            {
                if (string.IsNullOrEmpty(rs.status))
                    if (driver != null) {
                        rs.ScrenShotBytes = ScreamShotUtil.GetScreamShot(driver, rs.status);
                    }
                    
                    rs.status = ConstResultadoStatus.STATUS_EXCEPTION_DESCONHECIDA;
            }

        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                log.FormaTLogException(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.GetType().Name, ex.Message);
                return false;
            }
        }

        private bool RunValidationElementoState(Resultado rs, string validation, IWebElement el)
        {
            bool isPassou = false;
            switch (validation)
            {
                case ConstValidationCommand.IS_CHECKED:
                    isPassou = el.Selected;
                    break;
                case ConstValidationCommand.IS_UNCHECKED:
                    isPassou = !el.Selected;
                    break;
                case ConstValidationCommand.IS_ENABLE:
                    isPassou = el.Enabled;
                    break;
                case ConstValidationCommand.IS_NOT_ENABLE:
                    isPassou = !el.Enabled;
                    break;
                case ConstValidationCommand.IS_VISIBLE:
                    isPassou = el.Displayed;
                    break;
                case ConstValidationCommand.IS_NOT_VISIBLE:
                    isPassou = !el.Displayed;
                    break;
            }
            rs.Valor = isPassou ? "SIM" : "NAO";
            return isPassou;
        }

        private bool RunValidationElementoValor(Resultado rs, string validation, string valorelementoValidacao, string valorelementocurrent)
        {
            bool isPassou = false;
            switch (validation)
            {

                case ConstValidationCommand.IS_MAIOR:
                    float validacao;
                    float current;
                    bool try1 = float.TryParse(valorelementoValidacao, out validacao);
                    bool try2 = float.TryParse(valorelementocurrent, out current);
                    if (try1 && try2)
                    {
                        isPassou = validacao > current;
                    }
                    else
                    {
                        isPassou = false;
                        rs.feedBack = "Não foi possível usar os valores em uma operação matemática";
                    }


                    break;
                case ConstValidationCommand.IS_MENOR:

                    try1 = float.TryParse(valorelementoValidacao, out validacao);
                    try2 = float.TryParse(valorelementocurrent, out current);
                    if (try1 && try2)
                    {
                        isPassou = validacao < current;
                    }
                    else
                    {
                        isPassou = false;
                        rs.feedBack = "Não foi possível usar os valores em uma operação matemática";
                    }
                    break;
                case ConstValidationCommand.IS_IGUAL:
                    isPassou = valorelementoValidacao == valorelementocurrent;
                    break;
                case ConstValidationCommand.IS_DIFERENTE:
                    isPassou = valorelementoValidacao != valorelementocurrent;
                    break;
                case ConstValidationCommand.CONTAINS:
                    isPassou = valorelementocurrent.Contains(valorelementoValidacao);
                    break;
                case ConstValidationCommand.NOT_CONTAINS:
                    isPassou = !valorelementocurrent.Contains(valorelementoValidacao);
                    break;

            }

            return isPassou;
        }

        private bool RunVariavel(Comando cmd, IWebElement el)
        {

            switch (cmd.Acao)
            {
               
                case ConstActionCommand.ACTION_SET_TEXT_VARIAVEL:
                    

                    Variavel variavel = new Variavel();

                    
                    variavel.Tipo = ConstVariavelTipo.COMANDO;
                    variavel.Valor = el.Text;
                    variavel.Nome = cmd.Elemento.CodigoUi;


                    Variaveis.Add(variavel);

                    
                    break;
               
            }
            return true;
        }

        private bool RunActionComand(string comando, IWebElement el, string valor)
        {
            try
            {
                switch (comando)
                {
                    case ConstActionCommand.ACTION_CHECK:
                        el.Click();
                        break;
                    case ConstActionCommand.ACTION_CLICK_ONCLIK:
                        var script = el.GetAttribute("onclick");
                        JSUtil.JavaScriptRun(driver, script);
                        break;
                    case ConstActionCommand.ACTION_CLICK:

                        //WebElementUtil.GetWebElementByID(driver, el.GetAttribute("id")).Click();
                        //string url = driver.Url;

                        //el.Click();
                        try
                        {
                            el.Click();

                        }

                        catch (NoSuchWindowException ex)
                        {
                            driver.SwitchTo().Window(driver.WindowHandles.Last());


                        }
                        catch (Exception ex)
                        {
                            log.FormaTLogException(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.GetType().Name, ex.Message);

                        }
                        //var el3 = el.FindElements(By.TagName("//span[text()='Ajuda']"));
                        //var el2 = driver.FindElements(By.XPath("//span[text()]/preceding::button[not(contains(@style,'display:none')) and not(contains(@style,'display:hidden')) and contains(@class,'btn-primary')]"));
                        //driver.FindElement(By.Cod(el.GetAttribute("id"))).Click();
                        //el.Click();
                        break;
                    case ConstActionCommand.ACTION_INSERT:
                        el.SendKeys(valor);
                        break;
                    case ConstActionCommand.ACTION_INSERT_IF_EMPTY:
                        if ((el.Text == null && el.GetAttribute("value") == null) || (el.Text == "" && el.GetAttribute("value") == ""))
                        {
                            el.SendKeys(valor);
                        }

                        break;
                    case ConstActionCommand.ACTION_SELECT:
                        var combobox = new SelectElement(el);
                        combobox.SelectByText(valor);
                        break;

                    case ConstActionCommand.ACTION_GRID_GETFIRST_ITEM:
                        driver.SwitchTo().Window(valor);
                        break;
                    /*
                     //tr[contains(@class,'GridLinha')][1]/following::td[1]
                     */

                }
            }
            catch (Exception ex) {
              Console.Write(ex.Message);
            }
            return true;
        }

        private bool RunActionWebDriverComand(string comando, string valor)
        {

            switch (comando)
            {
                case ConstActionCommand.ACTION_SWITCH_TO_FRAME:
                    if (driver.PageSource.Contains("<iframe")) { 
                   var by = By.XPath(valor);
                   IWebElement iframe = FindElementBy(by);;
                   var tt = driver.FindElements(By.XPath("//iframe[1]"));
                   driver.SwitchTo().Frame(iframe);
                    }
                    break;
                case ConstActionCommand.ACTION_GO_TO:
                    do{
                        driver.Navigate().GoToUrl(valor);
                    }
                while(!driver.Url.Contains(valor));
                    break;
                case ConstActionCommand.ACTION_SWITCH_TO_BACK:
                    try
                    {
                        driver.Navigate().Back();
                        
                    }
                    catch {
                       
                    }
                    break;
                case ConstActionCommand.ACTION_SWITCH_TO_CONTAIS:
                    do
                    {
                        NavigateUtil.SwitchTocontains(driver, valor);
                    }
                    while (!driver.Url.Contains(valor));
                    
                    break;

                case ConstActionCommand.ACTION_SWITCH_TO_LAST:
                    driver.SwitchTo().Window(driver.WindowHandles.Last());

                    break;
                case ConstActionCommand.ACTION_RUN_JS:
                    JSUtil.JavaScriptRun(driver, valor);
                    break;
                
                case ConstActionCommand.ACTION_CLOSE_ALERT:
                    if (NavigateUtil.IsAlertPresents(driver))
                    {
                        try
                        {
                            driver.SwitchTo().Alert().Accept();
                        }
                        catch
                        {
                            return true;
                        }

                    }
                    

                    break;
                
                case ConstActionCommand.ACTION_ClOSE_ALL_PAGES:

                    break;
                case ConstActionCommand.ACTION_SWITCH_TO:

                    do
                    {
                        driver.SwitchTo().Window(valor);
                    }
                    while (!driver.Url.Contains(valor));
                    
                    break;
                case ConstActionCommand.ACTION_GRID_GETFIRST_ITEM:
                    driver.SwitchTo().Window(valor);
                    break;
               
            }
            //TimeWebPageAction();
            return true;
        }

        public string GetUrl()
        {
            return driver.Url;
        }
    }
}
