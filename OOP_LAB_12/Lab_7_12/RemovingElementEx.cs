using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_12
{
    class RemovingElementEx : MyException
    {
        public RemovingElementEx() { }

        public RemovingElementEx(string message) : base(message) { }

        public RemovingElementEx(string message,Exception inner) : base(message,inner) { }

        public override void Info()
        {
            Console.WriteLine("You have exception with removing file");
        }
    }
}
