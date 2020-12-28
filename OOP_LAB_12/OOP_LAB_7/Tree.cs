using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB_12
{
    public class Tree : Plants
    {
        public Tree(string name, string family, string kingdom)
        {
            Name = name;
            Family = family;
            Kingdom = kingdom;
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
