using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB_5
{
    internal sealed class Flower : Plants
    {
        public Flower(string name, string family, string kingdom)
        {
            Name = name;
            Family = family;
            Kingdom = kingdom;
        }

        public override void GetCountOfLeaf()
        {
            Console.WriteLine("Counter of Leaf is : 30-100");
        }
    }
}
