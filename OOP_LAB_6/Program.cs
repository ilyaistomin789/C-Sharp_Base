using System;

namespace OOP_LAB_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Type daysType = typeof(Plants.Days);
            
            Tree oakTree= new Tree("Oak", "Fagaceae Family", "Plant Tree");
            Tree pineTree = new Tree("Pine", "Pinales Family","Plant Tree");
            Tree firTree = new Tree("Fir", "Pinaceae Family", "Plant Tree");
            Flower roseFlower = new Flower("Rose","Rosaceae Family","Plant");
            Flower chamomileFlower = new Flower("Chamomile","Compositae Family","Plant");
            Flower flowerOfCannes = new Flower("Flower Of Cannes", "Cannaceae Family", "Plant");
            var collection = new ClassContainer<Plants>();
            var fileCollection = new ClassContainer<Plants>();
            var jsonFileCollection = new ClassContainer<Plants>();
            Console.WriteLine("Names of Enum :");
            foreach (var elementsName in Enum.GetNames(daysType))
            {
                Console.WriteLine(elementsName);
            }
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
            collection.Delete(flowerOfCannes); //fix (head of collection is deleted)
            collection.Delete(flowerOfCannes);//error
            Console.WriteLine(collection.GetCount());
            collection.WriteFile();
            collection.ObjectFile();
            collection.ReadFile();
            collection.GetInfoOfCollection();
            Console.WriteLine(collection.FirstOrDefault(x => x.Name == "Oak"));
            collection.FindAll(x => x.Kingdom == "Plant Tree");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(oakTree is Flower);
            Console.WriteLine(flowerOfCannes is Flower);
            var exampleAs = oakTree as Plants;
            if (exampleAs == null)
            {
                Console.WriteLine("Convertion Error");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(roseFlower.Equals(chamomileFlower));
            Console.ForegroundColor = ConsoleColor.White;

            var conroller = new ClassController<Plants>();

            conroller.Add(flowerOfCannes);
        }
    }
}
