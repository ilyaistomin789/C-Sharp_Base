using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB_9
{
    sealed class Flower : Plants
    {
        public Flower(string name, string family, string kingdom)
        {
            _event.MyEvent += Plants.counterOfElements;
            Name = name;
            Family = family;
            Kingdom = kingdom;
            _event.InvokeEvent();
            _event.MyEvent -= Plants.counterOfElements;
        }
        public static void CheckFlowers(int counter, Action<int> op)
        {
            if (counter <= 2)
            {
                op(counter);
            }
        }
    }
}
