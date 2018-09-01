using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Sigef.Poc.Ftcapp.WebDriver.Util
{
    public class ManagerUtil
    {



        #region redimention Utils

        public static void Minimizajanela(IWebDriver driver)
        {

            driver.Manage().Window.Minimize();


        }

        public static void CloseAllWindow(ReadOnlyCollection<string> readOnlyCollection, IWebDriver driver)
        {
            foreach (var item in readOnlyCollection)
            {
                driver.SwitchTo().Window(item).Close();
            }
        }

        public static void MinimizeOtherWindows(IWebDriver driver, string Url)
        {
            foreach (var item in driver.WindowHandles)
            {
                var curl = driver.SwitchTo().Window(item).Url;
                if (curl != Url)
                {
                    driver.Manage().Window.Minimize();
                }
            }
        }

        public static void PosicionaJanelaCantoSuperiorDireito(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            //var size = GetSizeWindows(driver);
            //var position = GetPositionWindows(driver);
            SetSizeWindows(driver, 470, 790);
            //SetPositionWindows(driver,(size.Width - 790), 0);
        }


        //public Point GetPositionWindows(IWebDriver driver)
        //{
        //    return driver.Manage().Window.Position;
        //}

        //public Size GetSizeWindows(IWebDriver driver)
        //{
        //    return driver.Manage().Window.Size;
        //}

        //public static void SetPositionWindows(IWebDriver driver, int x, int y)
        //{
        //    driver.Manage().Window.Position.Offset(x, y);
        //}

        public static void SetSizeWindows(IWebDriver driver, int Height, int Width)
        {
            //driver.Manage().Window.Size = new Size { Height = Height, Width = Width };
        }






        #endregion
    }
}
