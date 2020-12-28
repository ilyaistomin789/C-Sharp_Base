using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeLibrary
{
    public class MyClass
    {
        public MyClass()
        {
        }
        public string hope;
        public string name;
        public int age;
        private int Year { get; set; }
        public void GetAge()
        {
            Year = 2001;
            age = 18;
            Console.WriteLine($"{age.ToString()},{Year.ToString()}");
        }
        public void Hello()
        {
            Console.WriteLine("Hello World");
            Hope();
        }

        private void Hope()
        {
            hope = "I can end BelStu";
            Console.WriteLine(hope);
        }
    }
}
