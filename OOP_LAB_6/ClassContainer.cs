using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace OOP_LAB_6
{
    public class ClassContainer<T> : IEnumerable, IEnumerator where T : Plants
    {
        protected readonly List<T> _plantList = new List<T>();
        private int _position = -1;
        int _counterOfCollection;
        struct Info
        {
            public string Author { get; set; }
            public DateTime DateTimeInfo;
        }
        public ClassContainer()
        {
            Info newCollection = new Info();
            newCollection.Author = "Ilya Istomin";
            newCollection.DateTimeInfo = DateTime.Now;
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

        public void Reset() => _position = -1;

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

        public void Add(IEnumerable<T> items)
        {
            foreach (var plant in items)
            {
                Add(plant);
            }
        }

        public int GetCount() => _counterOfCollection;

        public void Delete(T obj)
        {
            if (IsExist(obj))
            {
                _plantList.Remove(obj);
                _counterOfCollection--;
                Console.WriteLine($"Element *{obj.Name}* is removed");
            }
            else
            {
                Console.WriteLine("Error while removing element");
            }
        }

        public T FirstOrDefault(Predicate<T> predicate)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            return _plantList.Find(predicate);
        }

        public void FindAll(Predicate<T> predicate)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            List<T> result = _plantList.FindAll(predicate);

            foreach (var element in result)
            {
                Console.WriteLine($"{element.Name},{element.Family},{element.Kingdom}");
            }

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

            string path = @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_7\collection.txt";

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

            string path = @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_7\ObjectFile.txt";

            if (!File.Exists(path))
            {
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
            else
            {
                Console.WriteLine("File was created earlier");
            }
        }

        public void ReadFile()
        {
            string path = @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_7\Read.txt";

                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string paramCollection = sr.ReadLine();
                        Plants filePlants = new Plants(paramCollection.Split(new char[] { ',' })[0],
                            paramCollection.Split(new char[] { ',' })[1], paramCollection.Split(new char[] { ',' })[2]);
                        _plantList.Add((T)filePlants);
                        _counterOfCollection++;
                    }
                }
        }

        public void ReadJsonFile()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string path = @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_7\Read.json";

            List<Plants> jsonPlants = JsonConvert.DeserializeObject<List<Plants>>(File.ReadAllText(path));

            Add(jsonPlants as IEnumerable<T>);
            Console.WriteLine("JSON FILE INFORMATION");
            foreach (var element in jsonPlants)
            {
                Console.WriteLine($"{element.Name} , {element.Family} , {element.Kingdom}");
            }

            Console.WriteLine("END JSON");
                
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
    }
}
