using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB_8
{
    sealed class Flower : Plants
    {
        public Flower(string name, string family, string kingdom)
        {
            Name = name;
            Family = family;
            Kingdom = kingdom;
        }
    }
}
