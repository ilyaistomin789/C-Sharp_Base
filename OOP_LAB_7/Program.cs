using System;
using System.Diagnostics;

namespace OOP_LAB_7
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLog.ClearFile();
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
            Debug.WriteLine("End of creating objects");
            Debug.WriteLine("Try-catch block");
            try
            {
                fileCollection.ReadFile();
                jsonFileCollection.ReadJsonFile();
                Console.WriteLine(fileCollection.GetCount());
                collection.Add(oakTree);
                //collection.Add(oakTree);//error
                collection.Add(pineTree);
                collection.Add(firTree);
                collection.Add(roseFlower);
                collection.Add(chamomileFlower);
                collection.Add(flowerOfCannes);
                Console.WriteLine(collection.GetCount());
                collection.Delete(flowerOfCannes);
                //collection.Delete(flowerOfCannes);
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
                
                //throw new Exception("Внутреннее исключение",e);
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
