using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_11
{
    internal class Collection<T> : IEnumerable, IEnumerator where T : Item
    {
        private readonly List<T> _plantList = new List<T>();
        private int _position = -1;
        int _counterOfCollection;
        public T this[int index]
        {
            get => _plantList[index];
            set => _plantList[index] = value;
        }
        public bool IsExist(T obj)
        {
            if (_plantList.Exists(x => x.name == obj.name))
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
        public void Add(params T[] obj)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                _plantList.Add(obj[i]);
                _counterOfCollection++;
            }
          
        }

        public int GetCount() => _counterOfCollection;

        public void Delete(T obj)
        {
            if (IsExist(obj))
            {
                _plantList.Remove(obj);
                _counterOfCollection--;
                Console.WriteLine($"Element *{obj.name}* is removed");
            }
            else
            {
                Console.WriteLine("Error with removing element");
            }
        }
    }
}
