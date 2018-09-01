using Sigef.Poc.Ftcapp.WebDriver;

namespace Sigef.Poc.Ftcapp.WebDriver.Projeto
{
    public class AccessProject : WebDriverPai
    {
        public void Go(string url)
        {
            driver.Navigate().GoToUrl(url);

        }



        public AccessProject(OpenQA.Selenium.IWebDriver pdriver)
        {
            // TODO: Complete member initialization
            driver = pdriver;
        }
    }
}
