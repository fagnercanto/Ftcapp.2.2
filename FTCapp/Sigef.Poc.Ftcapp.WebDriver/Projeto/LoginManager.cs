using OpenQA.Selenium;
using Sigef.Poc.Ftcapp.WebDriver;

namespace Sigef.Poc.Ftcapp.WebDriver.Projeto
{
    public class LoginManager : WebDriverPai
    {
        public void Go()
        {


            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe")));


            driver.FindElement(By.Id("txtSenha")).SendKeys("123"); ;
            driver.FindElement(By.Id("txtCPF")).SendKeys("04088701925"); ;



            driver.FindElement(By.Id("cmbEnviar")).Click();


        }

        public LoginManager(IWebDriver pdriver)
        {
            // TODO: Complete member initialization
            driver = pdriver;
        }
    }
}
