using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_10
{
    class Tree : IEnumerable
    {
        internal int counterOfLeaf;
        internal string family;
        internal int age;
        internal int height;
        public override string ToString()
        {
            
            return $"{base.GetType()} {height} {age} {family} {counterOfLeaf}";
        }

       IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }

    }
}
