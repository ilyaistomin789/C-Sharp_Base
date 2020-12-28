using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_7
{
    class MyException : Exception
    {
        public MyException() { }

        public MyException(string message) : base(message) { }

        public MyException(string message, Exception inner) : base(message,inner) { }

        public virtual void Info()
        {
            Console.WriteLine("**You have exception**");
        }
    }
}
