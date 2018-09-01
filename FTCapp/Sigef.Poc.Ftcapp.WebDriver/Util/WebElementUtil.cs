using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace Sigef.Poc.Ftcapp.WebDriver.Util
{
    public class WebElementUtil
    {


        public static IWebElement GetWebElementByID(IWebDriver driver, string p)
        {
            return GetElementBy(driver, By.Id(p));
        }

        public static ReadOnlyCollection<IWebElement> GetWebElementsByClass(IWebDriver driver, string p)
        {
            WaitElement(By.ClassName(p), driver);
            var result = GetElementsBy(driver, By.ClassName(p));

            return result;
        }



        public static void WaitElement(By by, IWebDriver driver)
        {

            ReadOnlyCollection<IWebElement> elements = null;
            int count = 0;
            try
            {
                do
                {
                    elements = driver.FindElements(by);
                    if (isElementsNull(elements))
                    {
                        System.Threading.Thread.Sleep(3000);
                        count++;
                        
                    }
                } while (count < 3 && isElementsNull(elements));

            }
            catch (Exception ex)
            {
                new Sigef.Poc.Ftcapp.Util.LOG.LogUtil().FormaTLogException("WaitElement", ex.GetType().Name, ex.Message);
            }
        }

        public static bool isElementsNull(ReadOnlyCollection<IWebElement> elements)
        {
            return elements == null || elements.Count == 0;
        }

        public static IWebElement GetElementBy(IWebDriver driver, By by)
        {
            WaitElement(by, driver);
            return driver.FindElement(by);
        }

        public static ReadOnlyCollection<IWebElement> GetElementsBy(IWebDriver driver, By by)
        {
            WaitElement(by, driver);
            return driver.FindElements(by);
        }





    }
}
