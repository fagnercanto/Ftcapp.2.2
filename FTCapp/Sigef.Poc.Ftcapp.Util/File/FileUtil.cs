using System;
using System.IO;

namespace Sigef.Poc.Ftcapp.WebDriver.Util
{
    public class FileUtil
    {
        #region FILE DYRETORY UTIL
        public bool FileCreateIfNotExists(string path)
        {
            bool result = false;
            if (!FileExists(path))
            {
                FileCreate(path);
                result = true;
            }
            return result;
        }

        public void FileCreate(string path)
        {

            FileInfo info = new FileInfo(path);

            var file = info.Create();
            file.Close();
        }

        public void FileRemove(string path)
        {
            System.IO.File.Delete(path);
        }

        public bool FileExists(string Path)
        {
            FileInfo Validation = new FileInfo(Path);

            return Validation.Exists;
        }

        public bool FileWrite(string path, string content)
        {
            if (!FileCreateIfNotExists(path))
            {
                FileClearContent(path);
            }

            System.IO.File.WriteAllText(path, content);

            return true;
        }

        public string FileRead(string path)
        {
            string text = "";
            if (FileExists(path))
            {
                text = System.IO.File.ReadAllText(path);
            }
            return text;
        }

        public bool FileExclude(string path)
        {
            bool result = true;
            if (FileExists(path))
            {
                try
                {
                    System.IO.File.Delete(path);
                }
                catch
                {
                    result = false;
                }

            }
            return result;
        }

        public void FileClearContent(string path)
        {
            StreamWriter strm = File.CreateText(path);
            strm.Flush();
            strm.Close();
        }

        public bool DiretoryCreateIfNotExists(string path)
        {
            bool result = false;
            if (!DiretoryExists(path))
            {
                DiretoryCreate(path);
                result = true;
            }
            return result;
        }


        public FileInfo[] FilesGetAllCreate(string diretoryPath)
        {

            DirectoryInfo diretory = new DirectoryInfo(diretoryPath);

            return diretory.GetFiles();

        }

        public void DiretoryCreate(string Path)
        {

            DirectoryInfo diretory = new DirectoryInfo(Path);

            diretory.Create();

        }

        public bool DiretoryExists(string Path)
        {
            DirectoryInfo Validation = new DirectoryInfo(Path);
            return Validation.Exists;
        }

        #endregion

    }
}
