using System;

namespace OOP_LAB_3_4
{
    class Program 
    {
       
        static void Main(string[] args)
        {
            static void Sum(double x, double y, out double a)
            {
                a = x + y;
            }
            var student = new { Name = "Ilya", Age = 18 };
            
            
            Item MyC = new Item();
            Item Goose = new Item("Goose",0,"Bird");
            Item Chicken = new Item("Chicken", 10, "Bird");
            Item Car = new Item("BMW", 2000, "Car");

            Console.WriteLine($"Result student.name : {student.Name}");
            Console.WriteLine(MyC.Print());
            Console.WriteLine($"Count of Items is {Item.counter}");
            //Car.YearOfImportationItem = 1999; //ERROR
            //Goose.NameOfItem = ""; //ERROR
            //Goose.counterOfCurrentItem = 0; //ERROR
            Goose.counterOfCurrentItem = 30;
            Console.WriteLine($"Count of Goose is {Goose.counterOfCurrentItem}");
            Goose.multiplyCounterby10(ref Goose.counterOfCurrentItem);
            Console.WriteLine($"Count of Goose after x10 is {Goose.counterOfCurrentItem}");

            double SumOfChickenAndCar;
            Sum(Chicken.costOfItem, Car.costOfItem,out SumOfChickenAndCar);
            
            Console.WriteLine($"Sum of chicken and car is : {SumOfChickenAndCar}");


            Console.WriteLine($"Result .Equals // Goose and Chicken // : {Goose.Equals(Chicken)}");
            Console.WriteLine($"Result .Equals // Car and Goose // : {Car.Equals(Goose)}");
            Console.WriteLine($"Result Goose.GetHashCode() : {Goose.GetHashCode()}");
            Console.WriteLine(Car.ToString());
            Console.WriteLine(Car.Print());

            
            Console.WriteLine(Item.GetStorage());

            ClassInfo.GetInfoAboutItem(Goose);

            #region Пример функций с ref и без
            void Method(ref int refArgument)
            {
                refArgument = refArgument + 44;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            int number = 1;
            Method(ref number);
            Console.WriteLine(number);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            //не меняется нессылочный тип
            void Method1(int Argument)
            {
                Argument = Argument + 44;
            }

            int number1 = 33;
            Method1(number1);
            Console.WriteLine(number1);
            #endregion
            Console.ForegroundColor = ConsoleColor.Yellow;
            ClassCollectionItem collectionOfItems = new ClassCollectionItem();
            //ClassCollectionItem collectionOfItems = ClassCollectionItem.getInstance();
            collectionOfItems.Add(Goose);
            collectionOfItems.Add(Car);
            ClassCollectionItem Empty = new ClassCollectionItem();
            //ClassCollectionItem Empty = ClassCollectionItem.getInstance();
            Empty.Add(MyC);
            // collectionOfItems.Add(Goose);
            //collectionOfItems.Delete(Car);
            Console.WriteLine(collectionOfItems.Count);
            foreach (Item s in collectionOfItems)
            {
                Console.WriteLine(s);
                Console.WriteLine("-----------");
            }
            Console.WriteLine(collectionOfItems.Equals(MyC));
            Console.WriteLine(Empty.GetHashCode());

            Console.WriteLine($"\n{collectionOfItems.ToString()}");
            var innn=Empty.Unite(collectionOfItems);
            collectionOfItems.Search(Goose);
            collectionOfItems.Search(MyC);


            collectionOfItems.Dispose();
           
            

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
