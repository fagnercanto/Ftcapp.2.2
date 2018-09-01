

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Drawing;
using System.IO;



namespace Sigef.Poc.Ftcapp.WebDriver.Util
{
    public class ScreamShotUtil
    {
        public static byte[]  GetScreamShot(OpenQA.Selenium.IWebDriver driver, string nome)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            //ICapabilities capabilities = ((RemoteWebDriver)driver).Capabilities;

            //var uri = "";
            //FileInfo info = null;


            //int i = 0;
            //do
            //{
            //    nome = nome.Replace("/", "-").Trim();
               
            //    uri = @"C:\" + nome + i + ".png";
            //    info = new FileInfo(uri);
            //    i++;
            //} while (info.Exists);

            //var file = info.Create();
            //file.Close();


            //ss.SaveAsFile(uri, ScreenshotImageFormat.Png);
            
            return ss.AsByteArray;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        
        

        private static bool FileCreateIfNotExists(string path)
        {
            bool result = false;
            if (!FileExists(path))
            {
                FileCreate(path);
                result = true;
            }
            return result;
        }

        private static void FileCreate(string path)
        {

            FileInfo info = new FileInfo(path);

            var file = info.Create();
            file.Close();
        }

        private static bool FileExists(string Path)
        {
            FileInfo Validation = new FileInfo(Path);

            return Validation.Exists;
        }


    }
}
