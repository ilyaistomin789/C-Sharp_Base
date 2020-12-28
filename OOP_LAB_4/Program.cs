using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OOP_LAB_4
{
    class Program
    {
        static void Main(string[] args)
        {
            ElectronicsStore Processor = new ElectronicsStore("Intel", 105.1d, 50, 10);
            ElectronicsStore Monitor = new ElectronicsStore("LG", 90, 100, 50);
            ElectronicsStore Smartphone = new ElectronicsStore("Samsung", 800, 300, 250);
            ElectronicsStore Memory = new ElectronicsStore("HyperX DDR4", 100, 500, 250);
            

            ClassCollection classOfItems = new ClassCollection();
            classOfItems.Add(Processor);
            classOfItems.Add(Monitor);
            classOfItems.Add(Smartphone);
            Console.WriteLine($"{classOfItems.dmy},{classOfItems.user}");
            classOfItems.GetInformation();
            Thread.Sleep(3000);
            ClassCollection classOfItems1 = new ClassCollection();
            classOfItems1.Add(Memory);
            Console.WriteLine($"{classOfItems1.dmy},{classOfItems1.user}");
            classOfItems.GetInformation();
            Console.WriteLine(Processor.ToString());
            //Console.WriteLine(ClassCollection.ToString());

            




            Console.WriteLine(ClassCollection.GetCount());
        }
    }
}
