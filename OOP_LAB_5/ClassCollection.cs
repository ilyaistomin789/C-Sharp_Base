using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System.Linq;

namespace OOP_LAB_5
{
    public class ClassCollection<T> : IEnumerable, IEnumerator where T : Plants
    {
        private readonly List<T> _plantList = new List<T>();
        private int _position = -1;
        static int _counterOfCollection;
        private static ClassCollection<T> instance;
        private ClassCollection() { }
        public static ClassCollection<T> GetInstance()
        {
            if (instance == null)
                instance = new ClassCollection<T>();

            return instance;
        }
        public T this[int index]
        {
        get => _plantList[index];
        set => _plantList[index] = value;
        }

        public bool IsExist(T obj)
        {
            if (_plantList.Exists(x => x.Name == obj.Name))
            {
                return true;
            }

            return false;
        }

        public bool MoveNext()
        {
            if (_position < _plantList.Count - 1)
            {
                _position++;

                return true;
            }

            return false;
        }

        public object Current => _plantList[_position];

        public void Reset()
        {
            _position = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this as IEnumerator;
        }

        public void Add(T obj)
        {
            if (IsExist(obj))
            {
                Console.WriteLine("Error when adding");
            }

            _plantList.Add(obj);
            _counterOfCollection++;
        }

        public int GetCount()
        {
            return _counterOfCollection;
        }

        public void Delete(T obj)
        {
            foreach (var element in _plantList)
            {
                if (element != obj)
                {
                    Console.WriteLine("There is no such object");
                }
                else
                {
                    _plantList.Remove(obj);
                    _counterOfCollection--;
                }
            }
        }

        public T Search(Predicate<T> predicate)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            return _plantList.Find(predicate);
        }

        public void GetInfoOfCollection()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var element in _plantList)
            {
                Console.WriteLine(
                    $"Type : {GetType()} \nName : {element.Name} \nFamily : {element.Family} \nKingdom : {element.Kingdom}");
            }
        }

        public void WriteFile()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dateTime = DateTime.Now;
            string path = @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_5\collection.txt";
            using (StreamWriter sw = new StreamWriter(path))
            { 
                sw.WriteLine($"\tINFORMATION ABOUT COLLECTION\t{dateTime}");
                foreach (var element in _plantList)
                {
                    sw.WriteLine($"\nType : {GetType()} \nName : {element.Name} \nFamily : {element.Family} \nKingdom : {element.Kingdom}");
                }
            }
        }

        public void ObjectFile()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime dateTime = DateTime.Now;
            string path = @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_5\ObjectFile.txt";
            
            using (StreamWriter sw = new StreamWriter(path))
            { 
                sw.WriteLine($"\tINFORMATION ABOUT OBJECTS\t{dateTime}");
                for (int i = 0; i < _plantList.Count; i++)
                {
                    if (_plantList[i].Name.Length > 5)
                    { 
                        sw.WriteLine($"Index : {i}\t\t\tObject : {_plantList[i].Name.Substring(0, 5)}\t\t\tObjType : {_plantList[i].GetType()}");
                    }
                    else
                    {
                        sw.WriteLine($"Index : {i}\t\t\tObject : {_plantList[i].Name}\t\t\tObjType : {_plantList[i].GetType()}");
                    }
                }
            }    
        }
    }
}
