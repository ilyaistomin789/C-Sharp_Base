using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_9
{
    class AddingElementEx : MyException
    {
        public override void Info()
        {
            Console.WriteLine("You have exception with adding file");
        }
    }
}
