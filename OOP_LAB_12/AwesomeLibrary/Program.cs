using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeLibrary
{
    
    class Program
    {
        static void Main(string[] args)
        {
            MyClass neverMoreClass = new MyClass();
            neverMoreClass.GetAge();
            neverMoreClass.Hello();
            Reflector.Analyze(neverMoreClass);
            Reflector.Save();
        }
    }
}
