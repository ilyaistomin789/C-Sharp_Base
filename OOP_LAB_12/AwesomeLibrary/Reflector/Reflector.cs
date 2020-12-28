using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OOP_LAB_12
{
    struct ObjectInfo
    {
        public bool HasConstructor;
        public string ObjectType;
        public string AssemblyName;
        public List<string> PublicFields;
        public List<string> PublicProperties;
        public List<string> PrivateFields;
        public List<string> PrivateProperties;
        public List<string> PublicMethods;
        public List<string> PrivateMethods;
        public List<string> Interfaces;
        public bool isSealed;
    }
    public static class Reflector
    {
        static readonly ConsoleLog _consoleLog = ConsoleLog.GetInstance();
        static readonly FileLog _fileLog = FileLog.GetInstance();
        
        private static ObjectInfo _objectInfo;
        private static string _info;

        public static void Analyze<T>(T obj)
        {
            Type objectType = typeof(T);
            _objectInfo.HasConstructor = (objectType.GetConstructors().Length != 0);
            _objectInfo.ObjectType = objectType.FullName;
            _objectInfo.AssemblyName = objectType.AssemblyQualifiedName;
            _objectInfo.PublicFields = new List<string>();
            _objectInfo.PublicProperties = new List<string>();
            _objectInfo.PrivateFields = new List<string>();
            _objectInfo.PrivateProperties = new List<string>();
            _objectInfo.PublicMethods = new List<string>();
            _objectInfo.PrivateMethods = new List<string>();
            _objectInfo.Interfaces = new List<string>();
            _objectInfo.isSealed = objectType.IsSealed;


            foreach (var fields in objectType.GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                _objectInfo.PublicFields.Add(fields.Name);
            }

            foreach (var fields in objectType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                _objectInfo.PrivateFields.Add(fields.Name);
            }

            foreach (var properties in objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                _objectInfo.PublicProperties.Add(properties.Name);
            }

            foreach (var properties in objectType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                _objectInfo.PrivateProperties.Add(properties.Name);
            }

            foreach (var methods in objectType.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                _objectInfo.PublicMethods.Add(methods.Name);
            }

            foreach (var methods in objectType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                _objectInfo.PrivateMethods.Add(methods.Name);
            }

            foreach (var baseClasses in objectType.GetInterfaces())
            {
                _objectInfo.Interfaces.Add(baseClasses.FullName);
            }

            _info += $"\nHas Constructor : {_objectInfo.HasConstructor}\n" +
                    $"Object Type : {_objectInfo.ObjectType}\n" +
                    $"Assembly Name : {_objectInfo.AssemblyName}\n" +
                    $"Is Sealed : {_objectInfo.isSealed}\n";

            foreach (var elements in _objectInfo.PublicFields)
            {
                _info += $"Public Fields : {elements}\n";
            }

            foreach (var elements in _objectInfo.PrivateFields)
            {
                _info += $"Private Fields : {elements}\n";
            }

            foreach (var elements in _objectInfo.PublicProperties)
            {
                _info += $"Public Properties : {elements}\n";
            }
            
            foreach (var elements in _objectInfo.PrivateProperties)
            {
                _info += $"Private Properties : {elements}\n";
            }

            foreach (var elements in _objectInfo.PublicMethods)
            {
                _info += $"Public Methods : {elements}\n";
            }
            
            foreach (var elements in _objectInfo.PrivateMethods)
            {
                _info += $"Private Methods : {elements}\n";
            }

            foreach (var elements in _objectInfo.Interfaces)
            {
                _info += $"Interfaces : {elements}\n";
            }

            _consoleLog.Log(LogLevel.Information,_info);
            _fileLog.Log(LogLevel.Information, _info);
        }

        public static void Save(string path, string objectInfo)
        {
            FileLog.ClearJsonFile(path);
            objectInfo = JsonConvert.SerializeObject(_objectInfo,Formatting.Indented);
            File.AppendAllText(path,objectInfo);
        }

        public static T Create<T>()
        {
            Type myType = typeof(T);
            var obj = Activator.CreateInstance(myType);
            return (T) obj;
        }

        public static void Invoke<T>(T obj, string method, Type[] parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            Type myType = typeof(T);
            MethodInfo methodInfo = myType.GetMethod(method);
            if (methodInfo != null)
            {
                parameters = methodInfo.GetGenericArguments();
                methodInfo.Invoke(obj, parameters);
            }

            throw new Exception("Could not find method");
        }

        public static void Invoke<T>(string method, Type[] parameters)
        {
            var obj = Create<T>();
            Invoke(obj, method, parameters);
        }

        public static void Invoke<T>(T obj, string method, Type[] parameters, BindingFlags flag)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            Type myType = typeof(T);
            MethodInfo methodInfo = myType.GetMethod(method, flag);
            if (methodInfo != null)
            {
                parameters = methodInfo.GetGenericArguments();
                methodInfo.Invoke(obj, parameters);
            }

            throw new Exception("Could not find method");
        }
        public static void Invoke<T>(string method, Type[] parameters, BindingFlags flag)
        {
            var obj = Create<T>();
            Invoke(obj, method, parameters, flag);
        }
    }
}
