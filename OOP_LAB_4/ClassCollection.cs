using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_4
{
    class ClassCollection
    {
        public  string user;
        public  DateTime dmy;
        public Information qwer = new Information();
        public ClassCollection()
        {
            this.dmy = qwer.DateInfo;
            this.user = qwer.developer;
        }
        
        readonly public List<ElectronicsStore> listOfStores = new List<ElectronicsStore>();
        static int counterOfList;
        public ElectronicsStore this[int index]
        {
            get { return listOfStores[index]; }
            set { listOfStores[index] = value; }
        }
        public bool IsThere(string name)
        {
            //name = name.ToLower();
            foreach (ElectronicsStore t in this.listOfStores)
            {
                if (t.NameOfProduct == name)
                {
                    return true;
                };
            }
            return false;
        }

        public void GetInformation()
        {
            foreach(ElectronicsStore store in listOfStores)
            {
                Console.WriteLine($"Name : {store.NameOfProduct} \nPrice : {store.PriceOfProduct} \nCount : {store.CountOfCurrentProduct} \nHow Many Sold : {store.HowManySold}");
            }
            
        }

        public void Add(ElectronicsStore item)
        {


            
            if (this.IsThere(item.NameOfProduct))
            {
                Console.WriteLine("This name is already existing");
                return;
            }
            else
            {
                if (item.NameOfProduct.Length > 1)
                {
                    listOfStores.Add(item);
                    counterOfList++;
                }
                else
                {
                    Console.WriteLine("Check the validity of entered name");
                }
            }




        }
        public void Delete(ElectronicsStore item)
        {
            if (counterOfList == 0)
            {
                Console.WriteLine("This collection is empty.");
            }
            else
            {
                listOfStores.Remove(item);
                counterOfList--;
            }
        }
        public static int GetCount()
        {
            return counterOfList;
        }

        public class Information
        {
           public  DateTime DateInfo = DateTime.Now;
           public  string developer = "Ilya Istomin";
           
        }
         


    }
}
