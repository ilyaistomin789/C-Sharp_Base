using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace OOP_LAB_9
{
    public class ClassCollection<T> : IEnumerable, IEnumerator where T : Plants
    {
        private EventArgs collectionEvent = new EventArgs();
        private readonly List<T> _plantList = new List<T>();
        private int _position = -1;
        int _counterOfCollection;
        static int _counterEvent;
        struct Info
        {
            public string Author { get; set; }
            public DateTime DateTimeInfo;
        }
        public ClassCollection()
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
    public bool IsThere(T obj)
    {
        foreach (var t in _plantList)
        {
            if (t.Name == obj.Name)
            {
                return true;
            }
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
    public static void AddEvent()
    {
        _counterEvent++;
        Console.WriteLine($"Congratulations!!!! You added new object. Counter is {_counterEvent}");
    }

    public static void DeleteEvent()
    {
        _counterEvent--;
        Console.WriteLine($"This is the right decision, this object was superfluous. Counter is {_counterEvent}");
    }
    public void Add(T obj)
    {
        if (IsThere(obj))
        {
            throw new AddingElementEx();
        }
        else
        {
            collectionEvent.MyEvent += AddEvent;
            _plantList.Add(obj); 
            _counterOfCollection++;
            collectionEvent.InvokeEvent();
            collectionEvent.MyEvent -= AddEvent;
        }
    }
    public int GetCount() => _counterOfCollection;
    public void Delete(T obj)
    {
        if (IsThere(obj))
        {
            collectionEvent.MyEvent += DeleteEvent;
            _plantList.Remove(obj);
            _counterOfCollection--;
            Console.WriteLine($"Element *{obj.Name}* is removed");
            collectionEvent.InvokeEvent();
            collectionEvent.MyEvent -= DeleteEvent;
        }
        else
        {
            throw new RemovingElementEx();
        }
    }
    public T FirstOrDefault(Predicate<T> predicate)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        if (_plantList.Find(predicate) == null)
        {
            throw new Exception();
        }
        return _plantList.Find(predicate);
        Console.ResetColor();
    }
    public void FindAll(Predicate<T> predicate)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        List<T> result = _plantList.FindAll(predicate);
        foreach (var element in result)
        {
            Console.WriteLine($"{element.Name},{element.Family},{element.Kingdom}");
        }
        Console.ResetColor();
        
    }
    public void GetInfoOfCollection()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var element in _plantList)
        {
            Console.WriteLine(
                $"Type : {base.GetType()} \nName : {element.Name} \nFamily : {element.Family} \nKingdom : {element.Kingdom}");
        }
        Console.ResetColor();
    }
    public void WriteFile()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        DateTime dateTime = DateTime.Now;
        string path = @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_9\collection.txt";
        if (!File.Exists(path))
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine($"\tINFORMATION ABOUT COLLECTION\t{dateTime}");
                foreach (var element in _plantList)
                {
                    sw.WriteLine($"\nType : {base.GetType()} \nName : {element.Name} \nFamily : {element.Family} \nKingdom : {element.Kingdom}");
                }
            }
        }
        else Console.WriteLine("File was created earlier");
        Console.ResetColor();
    }
    public void ObjectFile()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        DateTime dateTime = DateTime.Now;
        string path = @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_9\ObjectFile.txt";
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
        else Console.WriteLine("File was created earlier");
        Console.ResetColor();
    }
    public void ReadFile()
    {
        string path = @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_9\Read.txt";
        if (File.Exists(path))
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string paramCollection = sr.ReadLine();
                    Plants filePlants = new Plants(paramCollection.Split(new char[] {','})[0],
                        paramCollection.Split(new char[] {','})[1], paramCollection.Split(new char[] {','})[2]);
                    _plantList.Add((T) filePlants);
                    _counterOfCollection++;
                }
            }
        }
        else
        {
             throw new ReadingFileEx();
        }
    }
    public void ReadJsonFile()
    {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string path = @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_9\Read.json";
            if (File.Exists(path))
            {
                List<Plants> jsonPlants = JsonConvert.DeserializeObject<List<Plants>>(File.ReadAllText(path));
                Console.WriteLine("JSON FILE INFORMATION");
                foreach (var element in jsonPlants)
                {
                    Console.WriteLine($"{element.Name} , {element.Family} , {element.Kingdom}");
                }

                Console.WriteLine("END JSON");
            }
            else
            {
                throw new ReadingFileEx();
            }

            Console.ResetColor();
            
    }
    ~ClassCollection()
    {
        collectionEvent.MyEvent -= AddEvent;
        collectionEvent.MyEvent -= DeleteEvent;
    }

    }
}
