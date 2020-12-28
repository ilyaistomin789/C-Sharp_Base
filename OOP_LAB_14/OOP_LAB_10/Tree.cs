using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_14
{
    [Serializable]
    public class Tree
    {

        public int counterOfLeaf;
        public string family;
        public int age;
        public int height;

        public override string ToString()
        {

            return $"{base.GetType()} \nHeight : {height} \nAge : {age} \nFamily : {family} \nCounter of leaf : {counterOfLeaf}";
        }

    }
}
