using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_7
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

        public static void ClearFile()
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
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

        public void Log(string message)
        {
            Log(LogLevel.Information, message);
        }
    }
}
