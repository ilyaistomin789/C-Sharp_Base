using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_7
{
    class ReadingFileEx : MyException
    {
        public override void Info()
        {
            Console.WriteLine("You have exception with reading file");
        }
    }
}
