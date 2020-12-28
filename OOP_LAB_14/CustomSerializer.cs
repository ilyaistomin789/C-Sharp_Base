using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace OOP_LAB_14
{
    class CustomSerializer
    {
        private static string currentPath;
        public static void BinarySerializer<T>(string path, string saveFile, T obj)
        {
            currentPath = Path.Combine(path, saveFile);
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(currentPath,FileMode.Create))
            {
                bf.Serialize(fs,obj);
                Console.WriteLine("The object is binary serialized");
            }
        }

        public static void BinaryDeserializer<T>(string path, string openFile, out T saveObj)
        {
            currentPath = Path.Combine(path, openFile);
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(currentPath,FileMode.Open))
            {
                saveObj = (T)bf.Deserialize(fs);
                Console.WriteLine("The object is binary deserialized");
            }
        }

        public static void JsonSerializer<T>(string path, string saveFile, T obj)
        {
            currentPath = Path.Combine(path, saveFile);
            string result = JsonConvert.SerializeObject(obj);
            File.AppendAllText(currentPath,result);
            Console.WriteLine("The object is Json serialized");
        }

        public static void JsonDeserializer<T>(string path, string openFile, List<T> obj)
        {
            currentPath = Path.Combine(path, openFile);
            obj = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(currentPath));
            Console.WriteLine("The object is Json deserialized");
            foreach (var elements in obj)
            {
                Console.WriteLine(elements);
            }
        }

        public static void XmlSerializer<T>(string path, string saveFile, T obj)
        {
            currentPath = Path.Combine(path, saveFile);
            System.Xml.Serialization.XmlSerializer xs = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(currentPath, FileMode.OpenOrCreate))
            {
                xs.Serialize(fs,obj);
                Console.WriteLine("The object is Xml serialized");
            }
        }

        public static void XmlDeserializer<T>(string path, string openFile, T saveObj)
        {
            currentPath = Path.Combine(path, openFile);
            System.Xml.Serialization.XmlSerializer xs = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(currentPath,FileMode.Open))
            {
                saveObj = (T)xs.Deserialize(fs);
                Console.WriteLine("The object is Xml deserialized");
            }
        }
    }
}
