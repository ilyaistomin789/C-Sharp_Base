using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB_5
{
    internal abstract class Tree : Plants
    {
        public Tree(string name, string family, string kingdom)
        {
            Name = name;
            Family = family;
            Kingdom = kingdom;
        }
        public override bool Equals(object obj)
        {
            if (obj ==null && !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Plants s = (Plants) obj;
            return Kingdom == s.Kingdom;
        }

        public override void GetCountOfLeaf()
        {
            Console.WriteLine("Counter of Leaf is : 100,000-300,000");
        }
    }
}
