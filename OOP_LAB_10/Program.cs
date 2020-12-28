using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_10
{
    class Program
    {
        static void Main(string[] args)
        {
            var pineDefault = new Pine(30,4,"Pine Family",1567444);
            var pineSibirica = new Pine(44,500,"Pine Family",1333657);
            var pineHalepensis = new Pine(20,2,"Pine Family",200000);
            var oakPetiolate = new Oak(40,300, "Fagaceae Family",3000000);
            var oakDefault = new Oak(30,40, "Fagaceae Family",200000);

            Queue<Tree> queueTree = new Queue<Tree>();
            queueTree.Enqueue(pineDefault);
            queueTree.Enqueue(pineSibirica);
            queueTree.Enqueue(pineHalepensis);
            queueTree.Enqueue(oakPetiolate);
            queueTree.Enqueue(oakDefault);
            Console.WriteLine(queueTree.Count);
            foreach (var elementsTree in queueTree)
            {
                Console.WriteLine(elementsTree.ToString());
            }
            Console.WriteLine("IEnumerator");
            IEnumerator qwer = queueTree.GetEnumerator();
            while (qwer.MoveNext())
            {
                Console.WriteLine(qwer.Current);
            }

        }
    }
}
