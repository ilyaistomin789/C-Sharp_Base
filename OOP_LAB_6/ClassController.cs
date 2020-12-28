using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_6
{
    public class ClassController<T> where T : Plants, new()
    {
        
        private readonly ClassContainer<T> collection = new ClassContainer<T>();

        public void Add(T item) => collection.Add(item);
        //public T FirstOrDefault(Predicate<T> predicate)
        //{
        //    Console.ForegroundColor = ConsoleColor.DarkRed;

        //    return _plantList.Find(predicate);
        //}

        //public void FindAll(Predicate<T> predicate)
        //{
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    List<T> result = _plantList.FindAll(predicate);

        //    foreach (var element in result)
        //    {
        //        Console.WriteLine($"{element.Name},{element.Family},{element.Kingdom}");
        //    }

        //}

        //public static T operator +(T obj1,T obj2)
        //{
        //    return new T
        //    {
        //        Result = obj1.Leafs +obj2.Leafs
        //    };
        //}
    }
}
