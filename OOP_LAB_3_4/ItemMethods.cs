using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB_3_4
{
    public partial class Item
    {
        
        
        public void multiplyCounterby10(ref int Applicant)
        {
            if (Applicant > 0)
                Applicant = Applicant * 10;
            else
                Console.WriteLine("ERROR");
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType())) return false;

            Item s = (Item)obj;
            return typeOfItem == s.typeOfItem;
        }
        public override int GetHashCode()
        {
            int Hash = 77;
            Hash = string.IsNullOrEmpty(nameOfItem) ? 0 : Hash.GetHashCode();
            Hash = (Hash * 188) + costOfItem.GetHashCode();
            return Hash;
        }

        public override string ToString()
        {
            return $"Type : {base.ToString()} \nName : {nameOfItem} \nCost : {costOfItem} \nType : {typeOfItem}";
        }

        
        public static string GetStorage()
        {
            if (!String.IsNullOrEmpty(storage))
                return $"Location of this item is {storage}";
            else
                return "ERROR";
        }


        public string Print()
        {
            if (costOfItem != 0)
            {
                return $"Item : {nameOfItem}, Cost : {costOfItem}, Type : {typeOfItem}";
            }
            else
            {
                return $"Item : {nameOfItem}, Cost : No Data, Type : {typeOfItem}";
            }
        }

    }
}
