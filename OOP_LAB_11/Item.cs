using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_11
{
    public class Item
    {
        public string name;
        public int weight;
        public int volume;
        static Random randomInt = new Random();

        public Item()
        {
            
            string[] randomName = new string[5];
            randomName[0] = "Car";
            randomName[1] = "Boiler";
            randomName[2] = "Building Material";
            randomName[3] = "Truck";
            randomName[4] = "Safe";
            name = randomName[randomInt.Next(0, randomName.Length)];
            weight = randomInt.Next(0, 250);
            volume = randomInt.Next(0, 500);
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Type : {base.GetType()} \nName : {name} \nWeight : {weight} \nVolume : {volume}";
        }

    }
}
