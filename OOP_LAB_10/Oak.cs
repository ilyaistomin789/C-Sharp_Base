using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_10
{
    class Oak : Tree
    {
       public Oak(int height, int age, string family,int counterOfLeaf)
       {
           this.height = height;
           this.age = age;
           this.family = family;
           this.counterOfLeaf = counterOfLeaf;
           ToString();
       }
    }
}
