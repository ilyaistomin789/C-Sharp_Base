using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_12
{
    public class FileLog : ILogger
    {
        private static readonly string Path = $"{Environment.CurrentDirectory}\\Logger.txt";
        private static FileLog instance;
        private FileLog() {}

        public static FileLog GetInstance()
        {
            return instance ?? (instance = new FileLog());
        }

        public static void ClearJsonFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void Log(LogLevel logLevel, string message)
        {
            string str = $"{DateTime.Now} {logLevel.ToString()} : {message}\n";
            File.AppendAllText(Path,str);
        }

        public void Log(Exception exception)
        {
            Log(LogLevel.Error, exception.Message);
        }

    }
}
