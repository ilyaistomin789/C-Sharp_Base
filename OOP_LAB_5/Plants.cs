using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB_5
{
    public abstract class Plants : IPlants
    {
        public abstract void GetCountOfLeaf();
        public string Name { get; set; }
        public string Kingdom { get; set; }
        public string Family { get; set; }
        public Plants() { }
        public Plants(string name,string family, string kingdom)
        {
            Name = name;
            Family = family;
            Kingdom = kingdom;
        }
        public string GetInfo()
        {
            return $"INFO ABOUT OBJECT : \n{GetType()} \nName : {Name} \nFamily : {Family} \nKingdom : {Kingdom}";
        }
        public override string ToString()
        {
            return $"CLASS INFORMATION \nType : {GetType()} \nName : {Name} \nFamily : {Family} \nKingdom : {Kingdom}";
        }
    }
}
