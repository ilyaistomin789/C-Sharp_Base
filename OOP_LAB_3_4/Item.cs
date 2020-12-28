using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB_3_4
{

    public partial class Item
    {
        
        public static int counter;
        public int counterOfCurrentItem;
        public static string storage = "Moscow";
        private string nameOfItem;
        private int hours;
        
        public string NameOfItem
        {
            get
            {
             
                return nameOfItem;
            }
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Length > 1)
                {
                    nameOfItem = value;
                    
                }
                else
                {
                    
                    Console.WriteLine("Check the validity of entered name");
                    
                }
                
            }
        }
        public double costOfItem;
        public string typeOfItem { get; set; }
       
        public static string locationOfItem;
        private string nameOfHead = "Ilya";
        //public readonly string nameOfHead = "Ilya";
        public string NameOfHead
        {
            get
            {
                return nameOfHead;
            }
        }
        private int yearOfImportationItem;
        public int YearOfImportationItem
        {
            set
            {
                if (value >= 2000 && value <= 2019)
                {
                    yearOfImportationItem = value;
                }
                else
                {
                    Console.WriteLine("Check the validity of entered year");
                }
            }
        }


       

        public Item()
        {
            NameOfItem = "No Name";
            costOfItem = 0;
            typeOfItem = "No Info";
            counter++;
            

        }

        public Item(string _nameOfItem, double _costOfItem, string _typeOfItem)
        {
            nameOfItem = _nameOfItem;
            costOfItem = _costOfItem;
            typeOfItem = _typeOfItem;
            counter++;
           
        }

        static Item()
        {
            locationOfItem = "Minsk";
        }

        public Item(Item ExistItem)
        {
            nameOfItem = ExistItem.nameOfItem;
            costOfItem = ExistItem.costOfItem;
            typeOfItem = ExistItem.typeOfItem;
            counter++;

        }



        ~Item() => Console.WriteLine("The destructor of Item is executing");
        


    }

}
