using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace Sigef.Poc.Ftcapp.WebDriver.Util
{
    public class SeleniumUtil
    {

        public static void WaitElement(By by, IWebDriver driver)
        {

            ReadOnlyCollection<IWebElement> elements = null;
            int count = 0;
            try
            {
                do
                {
                    elements = driver.FindElements(by);
                    if (WebElementUtil.isElementsNull(elements))
                    {
                        System.Threading.Thread.Sleep(3000);
                        count++;
                        
                    }
                } while (count < 3 && WebElementUtil.isElementsNull(elements));

            }
            catch (Exception ex)
            {
                new Sigef.Poc.Ftcapp.Util.LOG.LogUtil().FormaTLogException("WaitElement", ex.GetType().Name, ex.Message);
            }
        }




        public static string GetOnclickAttText(IWebElement el)
        {
            string uri = el.GetAttribute("onclick");
            uri = uri.Replace(@"OpenURL('", "").Replace(@"');", "");
            return uri;
        }

        public static IWebElement GetATagNameContainsText(IWebDriver _driver, string _text)
        {

            var el = _driver.FindElement(By.XPath(string.Format("//a[contains(text(),'{0}')]", _text)));
            return el;
        }


        public static bool IsPaginaConceito(IWebDriver driver)
        {
            bool result = false;

            try
            {
                result = driver.Url != null;
            }
            catch (Exception ex)
            {
                new Sigef.Poc.Ftcapp.Util.LOG.LogUtil().FormaTLogException("IsPaginaConceito", ex.GetType().Name, ex.Message);
                if (ex.Message == "Modal dialog present")
                {
                    System.Threading.Thread.Sleep(2000);
                }
            }
            finally
            {
                result = (driver.Url != ConstUtil.GetPaginaHome() && driver.Url != ConstUtil.GetPaginaInicial());
            }

            return result;
        }




        internal static void Click(IWebDriver _driver, IWebElement el)
        {
            By by = null;

            var id = el.GetAttribute("codigo");
            if (id != null && id != "")
            {
                by = By.Id(id);
                WaitElement(by, _driver);
            }
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            IWebElement element = wait.Until(drv => drv.FindElement(by));
            try
            {
                JSUtil.JavaScriptRun(_driver, "document.getElementById('" + id + "').click()");
                JSUtil.PageLoad(_driver);
                JSUtil.AguardeLoad(_driver);
            }
            catch (Exception ex)
            {
                new Sigef.Poc.Ftcapp.Util.LOG.LogUtil().FormaTLogException("Click", ex.GetType().Name, ex.Message);
            }

        }
    }
}
