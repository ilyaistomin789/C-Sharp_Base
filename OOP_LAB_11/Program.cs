using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Work with LINQ");
            var firstItem = new Item();
            var secondItem = new Item();
            var thirdItem = new Item();
            var fourthItem = new Item();
            var fifthItem = new Item();
            var sixthItem = new Item();
            var seventhItem = new Item();
            var eighthItem = new Item();
            var ninthItem = new Item();
            var tenthItem = new Item();
            List<Item> listOfItems = new List<Item>(){firstItem, secondItem, thirdItem, fourthItem, fifthItem, sixthItem, seventhItem, eighthItem, ninthItem, tenthItem};
            var VolumeLinq = from x in listOfItems where x.volume > 200 select x;
            //var VolumeLinq1 = listOfItems.Where(t => t.volume > 200);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Volume more than 200");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (var elements in VolumeLinq)
            {
                Console.WriteLine(elements.ToString());
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            var threeElements = (from t in listOfItems orderby t.volume select t).Take(3);
            //var threeElements1 = listOfItems.OrderBy(t => t.volume).Take(3);
            foreach (var elementsMin in threeElements)
            {
                Console.WriteLine(elementsMin.ToString());
            }
            Console.ResetColor();
            var sortWeight = from y in listOfItems orderby y.weight select y;
            //var sortWeight1 = listOfItems.OrderBy(t => t.weight);
            Console.WriteLine("Sort weight");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (var elementsWeight in sortWeight)
            {
                Console.WriteLine(elementsWeight.ToString());
            }
            Console.ResetColor();
            var searchCar = (from t in listOfItems where t.name == "Car" select t).Count();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Count of Car");
            Console.ResetColor();
            Console.WriteLine(searchCar.ToString());
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Weight [0..100]");
            Console.ResetColor();
            var lowWeight = (from t in listOfItems where t.weight >= 0 && t.weight <= 100 select t);
            foreach (var low in lowWeight)
            {
                Console.WriteLine(low.ToString());
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("from 200 to infinity");
            Console.ResetColor();
            var v200Element = (from t in listOfItems where t.weight > 200 select t);
            foreach (var elements in v200Element)
            {
                Console.WriteLine(elements.ToString());
            }
        }
    }
}
