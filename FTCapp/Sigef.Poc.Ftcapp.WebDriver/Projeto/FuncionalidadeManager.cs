
using Sigef.Poc.Ftcapp.WebDriver;
namespace Sigef.Poc.Ftcapp.WebDriver
{
    public class FuncionalidadeManager : WebDriverPai
    {
        public void AccessTransacao(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public FuncionalidadeManager(OpenQA.Selenium.IWebDriver pdriver)
        {
            // TODO: Complete member initialization
            driver = pdriver;
        }
    }
}
