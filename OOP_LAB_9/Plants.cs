using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB_9
{
    public class Plants : IPlants
    {
        internal EventArgs _event = new EventArgs();
        static int counterOfPlants = 0;
        private static object result;

        public static void counterOfElements()
        {
            counterOfPlants++;
            Console.WriteLine($"You have {counterOfPlants} plants");
        }
        public string Name { get; set; }
        public string Kingdom { get; set; }
        public string Family { get; set; }
        public enum Days { Saturday = 1, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday };
        public Plants() { }
        public Plants(string name,string family, string kingdom)
        {
            Name = name;
            Family = family;
            Kingdom = kingdom;
        }
        public string GetInfo()
        {
            return $"{base.GetType()} \nName : {Name} \nFamily : {Family} \nKingdom : {Kingdom}";
        }
        public override string ToString()
        {
            return $"CLASS INFORMATION \nType : {base.ToString()} \nName : {Name} \nFamily : {Family} \nKingdom : {Kingdom}";
        }

        public static string GetInfoAboutCreator(string name)
        {
            string aboutCreator =$"{name} {DateTime.Now}";
            return aboutCreator;
        }
    }
}
