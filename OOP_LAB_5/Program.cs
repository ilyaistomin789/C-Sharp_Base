using System;

namespace OOP_LAB_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree oakTree= new Tree("Oak", "Fagaceae Family", "Plant");
            Tree pineTree = new Tree("Pine", "Pinales Family","Plant");
            Tree firTree = new Tree("Fir", "Pinaceae Family", "Plant");
            Flower roseFlower = new Flower("Rose","Rosaceae Family","Plant");
            Flower chamomileFlower = new Flower("Chamomile","Compositae Family","Plant");
            Flower flowerOfCannes = new Flower("Flower Of Cannes", "Cannaceae Family", "Plant");
            var collection = ClassCollection<Plants>.GetInstance();
            collection.Add(oakTree);
            collection.Add(pineTree);
            collection.Add(firTree);
            collection.Add(roseFlower);
            collection.Add(chamomileFlower);
            collection.Add(flowerOfCannes);
            collection.WriteFile();
            collection.ObjectFile();
            collection.GetInfoOfCollection();
            Console.WriteLine(collection.Search(x => x.Name == "Oak"));
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(oakTree is Flower);
            Console.WriteLine(flowerOfCannes is Flower);
            if (!(oakTree is Plants exampleAs))
            {
                Console.WriteLine("Convertion Error");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(roseFlower.Equals(chamomileFlower));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
