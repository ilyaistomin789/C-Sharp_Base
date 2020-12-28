using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_12
{
    public class ConsoleLog : ILogger
    {
        private static ConsoleLog instance;
        private ConsoleLog() { }

        public static ConsoleLog GetInstance()
        {
            return instance ?? (instance = new ConsoleLog());
        }

        public void Log(LogLevel logLevel, string message)
        {
            switch (logLevel)
            {
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Information:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }

            string str = $"{DateTime.Now} {logLevel.ToString()} : {message}";
            Console.WriteLine(str);
            Console.ResetColor();
        }

        public void Log(Exception exception)
        {
            Log(LogLevel.Error, exception.Message);
            Console.ResetColor();
        }
    }
}
