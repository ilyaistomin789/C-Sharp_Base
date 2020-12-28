using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_12
{
    public enum LogLevel
    {
        Error = 0,
        Warning,
        Information
    };
    interface ILogger
    {
        void Log(Exception exception);
        void Log(LogLevel logLevel, string message);
    }
}
