using OpenQA.Selenium;

namespace Sigef.Poc.Ftcapp.WebDriver.Util
{
    public class NavigateUtil
    {

        public static void Refresh(IWebDriver driver)
        {
            driver.Navigate().Refresh();
            ConfigIR(driver, null);
        }

        public static void IrGoToURL(IWebDriver driver, string URLPagina)
        {
            driver.Navigate().GoToUrl(URLPagina);
            ConfigIR(driver, URLPagina);
        }

        public static void IrURL(IWebDriver driver, string URLPagina)
        {
            driver.Url = URLPagina;
            ConfigIR(driver, URLPagina);
        }

        public static void IrSwit(IWebDriver driver, string URLPagina)
        {
            driver.SwitchTo().Window(URLPagina);
            ConfigIR(driver, URLPagina);
        }

        private static void ConfigIR(IWebDriver driver, string URLPagina)
        {
            if (!SeleniumUtil.IsPaginaConceito(driver))
            {
                if (!CloseIfAlertPresent(driver))
                {
                    JSUtil.PageLoad(driver);
                }
            }
            else
            {
                JSUtil.PageLoad(driver);
            }


            if (!string.IsNullOrEmpty(URLPagina))
            {
                ManagerUtil.MinimizeOtherWindows(driver, URLPagina);
                ManagerUtil.PosicionaJanelaCantoSuperiorDireito(driver);
            }

        }

       

        public static void CloseAlert(IWebDriver driver)
        {
            driver.SwitchTo().Alert().Accept();
        }

        private static bool CloseIfAlertPresent(IWebDriver driver)
        {
            var result = IsAlertPresents(driver);
            if (result)
            {
                CloseAlert(driver);
            }
            return result;
        }



        internal static bool IsAlertPresents(IWebDriver driver)
        {
            bool result = true;
            try
            {
                driver.SwitchTo().Alert();

            }
            catch {
                result = false;
            }
            return result;
        }

        internal static bool closeAllPages(IWebDriver driver)
        {

            foreach (var item in driver.WindowHandles) {
                driver.SwitchTo().Window(item);
                driver.Close();
            }

            return driver.WindowHandles.Count==0 ;
        }

        internal static bool SwitchTocontains(IWebDriver driver,string contains)
        {
            bool result = false;
            if (driver.Url.Contains(contains)) { return true; }
            foreach (var item in driver.WindowHandles)
            {
                driver.SwitchTo().Window(item);
                if (driver.Url.Contains(contains))
                {
                    result = true;
                    break;
                }
                
            }

            return result;
        }

    }
}
