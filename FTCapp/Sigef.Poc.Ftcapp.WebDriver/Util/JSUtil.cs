using OpenQA.Selenium;
using Sigef.Poc.Ftcapp.Util.LOG;
using System;

namespace Sigef.Poc.Ftcapp.WebDriver.Util
{
    public class JSUtil
    {
        const string imgLoad = "var imgload = document.getElementById('divAguarde'); if(imgload!=null){ return imgload.style.visibility;}";
        const string jsPageLoad = "var mm = document.readyState; return mm;";

        public static object JavaScriptRun(IWebDriver driver, string js)
        {

            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            return j.ExecuteScript(js);

        }

        public static bool PageLoad(IWebDriver driver)
        {

            int time = 0;
            bool pageLoad = false;
            try
            {
                do
                {
                    pageLoad = (string)JavaScriptRun(driver, jsPageLoad) == "complete";
                    if (!pageLoad)
                    {
                        System.Threading.Thread.Sleep(1000);
                        time++;
                    }
                } while (!pageLoad && time < 10);

            }
            catch (Exception ex)
            {
                new LogUtil().FormaTLogException("PageLoad", ex.GetType().Name, ex.Message);
                pageLoad = false;
            }
            return pageLoad;

        }

        public static bool AguardeLoad(IWebDriver driver)
        {
            int time = 0;
            bool AguardeLoad = false;
            try
            {
                do
                {
                    AguardeLoad = (string)JavaScriptRun(driver, imgLoad) == "visible";
                    if (AguardeLoad)
                    {
                        System.Threading.Thread.Sleep(1000);
                        time++;
                    }
                } while (AguardeLoad && time < 10);

            }
            catch (Exception ex)
            {
                new LogUtil().FormaTLogException("AguardeLoad", ex.GetType().Name, ex.Message);
                AguardeLoad = false;
            }
            return AguardeLoad;

        }

    }
}
