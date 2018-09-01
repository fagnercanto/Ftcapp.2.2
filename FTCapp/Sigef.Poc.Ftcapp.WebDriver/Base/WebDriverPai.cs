using OpenQA.Selenium;
using Sigef.Poc.FTCapp.Util;
using Sigef.Poc.Ftcapp.Entidade.Const;
using System.Collections.Generic;
using Sigef.Poc.FTCapp.Util.DTO;
using Sigef.Poc.Ftcapp.Entidade;
using System;
using System.Linq;
using Sigef.Poc.Ftcapp.WebDriver.Util;
using Sigef.Poc.Ftcapp.Util.LOG;
using Sigef.Poc.Ftcapp.Util.CONST;

namespace Sigef.Poc.Ftcapp.WebDriver
{
    public class WebDriverPai
    {

       // protected List<IWebElement> _Elements;
        protected List<ElementoScrap> _ElementosScrap;
        public IWebDriver driver
        {
            get;
            set;
        }


        private List<Variavel> _Variaveis;

        public List<Variavel> Variaveis
        {
            get
            {
                if (_Variaveis == null)
                {
                    _Variaveis = new List<Variavel>();
                }
                return _Variaveis;
            }
            set { _Variaveis = value; }
        }


        private LogUtil _log;
        
        protected LogUtil log
        {
            get{
                if(_log==null){
                    _log = new LogUtil();
                     }
                return _log;
            }
            set{_log = value;}
        }


        private List<string> _LabelsObrigatorios;
        public List<string> LabelsObrogatorios
        {
            get
            {
                if (CollectionUtil.IsNullOrEmpty(_LabelsObrigatorios))
                {
                    var els = driver.FindElements(By.ClassName(ConstClassName.SIGEFLabel_Padrao));
                    _LabelsObrigatorios = new List<string>();
                    foreach (IWebElement item in els)
                    {
                        var id = item.GetAttribute("id");
                        var text = StringUtil.IsNullReturnEmpty(item.Text.ToString());
                        if (!string.IsNullOrEmpty(id) && text.Contains("*"))
                        {
                            _LabelsObrigatorios.Add(id);
                        }

                    }

                }
                return _LabelsObrigatorios;
            }
            set { _LabelsObrigatorios = value; }
        }

        #region FindElementValidation
        protected bool IsElementPresentAndDisplayed(By by)
        {
            
                if (IsElementPresent(by))
                {
                    return false;
                }
                else {
                   return driver.FindElement(by).Displayed;
                }
            
        }
        protected bool IsElementPresent(By by)
        {
            try
            {
                var lt = driver.FindElements(by);
                if (lt != null && lt.Count > 0)
                {
                    
                    return true;
                }
                else
                {
                    
                    return false;
                }

            }
            catch (OpenQA.Selenium.InvalidSelectorException ex)
            {
                log.FormaTLogException(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.GetType().Name, ex.Message);
                return false;
            }
            catch (NoSuchElementException ex)
            {
                log.FormaTLogException(System.Reflection.MethodBase.GetCurrentMethod().Name,ex.GetType().Name,ex.Message);
                return false;
            }
            catch (WebDriverException ex)
            {
                log.FormaTLogException(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.GetType().Name, ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                log.FormaTLogException(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.GetType().Name, ex.Message);
                return false;
            }
        }

        
        #endregion


        #region FIND Element 

        protected IWebElement FindElementReturNull(Comando cmd)
        {
             

            IWebElement el = null;
            By by = null;
            if (cmd != null && cmd.Elemento != null)
            {
                switch (cmd.Elemento.FindElementBy)
                {
                    case ConstFindElementBy.BY_XPATH:
                        by = By.XPath(cmd.Elemento.CodigoUi);
                        break;
                    case ConstFindElementBy.BY_ID:
                        by = By.Id(cmd.Elemento.CodigoUi);
                        break;
                    default:
                        return null;

                }
                try
                {
                    
                    el = FindElementBy( by);
                }
                catch(Exception ex)
                {
                    log.FormaTLogException(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.GetType().Name, ex.Message, ConstTraceField.ELEMENTO,"NAO ENCONTRADO");
                }

            }
            return el;
            
        }

        protected IWebElement FindElementBy( By by)
        {
            ICollection<IWebElement> els = null;
            int i = 0;
            do
            {
                els = driver.FindElements(by);
                i++;
            } while ((!IsElementPresent(by)) && i < 4);
            if (i > 3 && els != null && els.Count > 0)
            {
                int x = 1;
                foreach (var item in els)
                {
                    
                    x++;
                   
                }

            }
            return els.FirstOrDefault();
        }

        #endregion

        #region WEB comands validations

        protected void TimeWebPageAction()
        {

            By by = By.XPath("//h4[contains(text(),'Carregando')]");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            
            while (IsElementPresentAndDisplayed(by)){
            #if DEBUG
                log.TraceInicioFim();
                log.TraceWriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name, Sigef.Poc.Ftcapp.Util.CONST.ConstTraceException.METODO);
                log.TraceIdentAndUniIdent(by.ToString(), Sigef.Poc.Ftcapp.Util.CONST.ConstTraceField.ELEMENTO);
                log.TraceInicioFim();

            #endif
            }

            while (!(JSUtil.PageLoad(driver))){
                #if DEBUG
                log.TraceInicioFim();
                log.TraceWriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name, Sigef.Poc.Ftcapp.Util.CONST.ConstTraceException.METODO);
                log.TraceIdentAndUniIdent("PAGE LOADING", Sigef.Poc.Ftcapp.Util.CONST.ConstTraceField.PAGINA);
                log.TraceInicioFim();
                #endif
            }
           
        }

        #endregion

    }
}
