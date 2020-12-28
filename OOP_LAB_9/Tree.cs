using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB_9
{
    public class Tree : Plants
    {
        public Tree(string name, string family, string kingdom)
        {
            _event.MyEvent += Plants.counterOfElements;
            Name = name;
            Family = family;
            Kingdom = kingdom;
            _event.InvokeEvent();
            _event.MyEvent -= Plants.counterOfElements;
        }
        public override bool Equals(object obj)
        {
            if (obj ==null && !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Plants s = (Plants) obj;
            return Kingdom == s.Kingdom;
        }
    }
}
