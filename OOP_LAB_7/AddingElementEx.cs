using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_7
{
    class AddingElementEx : MyException
    {
        public AddingElementEx() { }

        public AddingElementEx(string message) : base(message) { }

        public AddingElementEx(string message,Exception inner) : base(message,inner) { }

        public override void Info()
        {
            Console.WriteLine("You have exception with adding file");
        }
    }
}
