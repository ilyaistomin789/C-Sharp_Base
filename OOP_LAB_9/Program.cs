using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OOP_LAB_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Creating objects");
            Tree oakTree = new Tree("Oak", "Fagaceae Family", "Plant Tree");
            Tree pineTree = new Tree("Pine", "Pinales Family", "Plant Tree");
            Tree firTree = new Tree("Fir", "Pinaceae Family", "Plant Tree");
            Flower roseFlower = new Flower("Rose", "Rosaceae Family", "Plant");
            Flower chamomileFlower = new Flower("Chamomile", "Compositae Family", "Plant");
            Flower flowerOfCannes = new Flower("Flower Of Cannes", "Cannaceae Family", "Plant");
            var collection = new ClassCollection<Plants>();
            var fileCollection = new ClassCollection<Plants>();
            var jsonFileCollection = new ClassCollection<Plants>();
            var treeCollection = new ClassCollection<Tree>();
            var flowerCollection = new ClassCollection<Flower>();
            List<int> intList = new List<int>();
            List<double> doubleList = new List<double>();
            string creator = "Ilya Istomin";
            Debug.WriteLine("End of creating objects");
            Debug.WriteLine("Try-catch block");
            try
            {
                intList.Add(5);
                intList.Add(777);
                Console.WriteLine($"Counter of int list : {intList.Count}");
                doubleList.Add(6.66);
                doubleList.Add(7.9);
                Console.WriteLine($"Counter of double list : {doubleList.Count}");
                Console.WriteLine($"Item of int list :");
                foreach (var item in intList)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine($"Item of double list :");
                foreach (var item in doubleList)
                {
                    Console.WriteLine(item.ToString());
                }
                fileCollection.ReadFile();
                jsonFileCollection.ReadJsonFile();
                Console.WriteLine($"Counter of file collection : {fileCollection.GetCount()}");
                //Console.WriteLine($"Counter of JSON file collection : {jsonFileCollection.GetCount()}"); //0, because method ReadJsonFile() creates new List ):
                treeCollection.Add(oakTree);
                treeCollection.Add(pineTree);
                Console.WriteLine($"Counter of tree collection : {treeCollection.GetCount()}");
                flowerCollection.Add(roseFlower);
                flowerCollection.Add(chamomileFlower);
                Console.WriteLine($"Counter of flower collection : {flowerCollection.GetCount()}");
                collection.Add(oakTree);
                //collection.Add(oakTree);//error
                collection.Add(pineTree);
                collection.Add(firTree);
                collection.Add(roseFlower);
                collection.Add(chamomileFlower);
                collection.Add(flowerOfCannes);
                Console.WriteLine(collection.GetCount());
                collection.Delete(flowerOfCannes);
                //collection.Delete(flowerOfCannes);//error
                Console.WriteLine(collection.GetCount());
                collection.WriteFile();
                collection.ObjectFile();
                collection.ReadFile();
                collection.GetInfoOfCollection();
                collection.FindAll(x => x.Kingdom == "Plant Tree");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(oakTree is Flower);
                Console.WriteLine(flowerOfCannes is Flower);
                var exampleAs = oakTree as Plants;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(roseFlower.Equals(chamomileFlower));
                Console.ForegroundColor = ConsoleColor.White;
                //Debug.Assert(oakTree is Flower);
                Action<int> flowerAction;
                Predicate<int> fileExist = i => { return i > 0;};
                flowerAction = delegate { Console.WriteLine("You have a few flowers!!!"); };
                Flower.CheckFlowers(flowerCollection.GetCount(),flowerAction);
                Console.WriteLine(fileExist(fileCollection.GetCount()));
                Func<string,string> infoFunc = Plants.GetInfoAboutCreator;
                Console.WriteLine(infoFunc(creator));
                

            }
            catch (MyException e)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Black;
                e.Info();
                Console.WriteLine($"Target Site:                 {e.TargetSite}");
                Console.WriteLine($"Declaring Type:              {e.TargetSite.DeclaringType}");
                Console.WriteLine($"Member Type:                 {e.TargetSite.MemberType}");
                Console.WriteLine($"Message:                     {e.Message}");
                Console.WriteLine($"Source:                      {e.Source}");
                Console.WriteLine($"Help Link:                   {e.HelpLink}");
                Console.WriteLine($"Stack:                       {e.StackTrace}");
                
            }
            Debug.WriteLine("Try-catch-finally block");
            try
            {
                Console.WriteLine(collection.FirstOrDefault(x => x.Name == "Oak"));
                //Console.WriteLine(collection.FirstOrDefault(x => x.Name == "123")); //error
            }
            catch (Exception e)
            {
                //throw new Exception("Inner Exception",e);
                Console.WriteLine($"Target Site:                 {e.TargetSite}");
                Console.WriteLine($"Declaring Type:              {e.TargetSite.DeclaringType}");
                Console.WriteLine($"Member Type:                 {e.TargetSite.MemberType}");
                Console.WriteLine($"Message:                     {e.Message}");
                Console.WriteLine($"Source:                      {e.Source}");
                Console.WriteLine($"Help Link:                   {e.HelpLink}");
                Console.WriteLine($"Stack:                       {e.StackTrace}");
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"PROGRAM END. TIME : {DateTime.Now}");
            }
        }
    }
}
