using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace OOP_LAB_3_4
{

    public class ClassCollectionItem : IEnumerable, IEnumerator, IDisposable
    {
 
            private static ClassCollectionItem instance;

            public ClassCollectionItem()
            { }

            public static ClassCollectionItem getInstance()
            {
                if (instance == null)
                    instance = new ClassCollectionItem();
                return instance;
            }
        
        readonly List<Item> collectionOfItems = new List<Item>();
        public Item this[int index]
        {
            get { return collectionOfItems[index]; }
            set { collectionOfItems[index] = value; }
        }
        public bool IsThere(string name)
        {
            //name = name.ToLower();
            foreach (Item t in this.collectionOfItems)
            {
                if (t.NameOfItem == name)
                {
                    return true;
                };
            }
            return false;
        }



           private int position = -1;

        int counterOfCollection;
        public bool MoveNext()
        {
            if (position < collectionOfItems.Count - 1)
            {
                position++;
                return true;
                
            }
            else
            {
                return false;
            }
        }

        public object Current
        {
            get
            {
                return collectionOfItems[position];
            }
        } 

        public void Reset()
        {
            position = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }

        public void Add(Item item)
        {

           
            
                if (this.IsThere(item.NameOfItem))
                {
                    Console.WriteLine("This name is already existing");
                    return;
                }
                else
                {
                    if (item.NameOfItem.Length > 1)
                    {
                        collectionOfItems.Add(item);
                        counterOfCollection++;
                    }
                    else
                    {
                        Console.WriteLine("Check the validity of entered name");
                    }
                }
            
               
            
            
        }
        public void Delete(Item item)
        {
            if (counterOfCollection==0)
            {
                Console.WriteLine("This collection is empty.");
            }
            else
            {
                collectionOfItems.Remove(item);
                counterOfCollection--;
            }
        }
        public void Search(Item item)
        {
            foreach (Item Elements in this.collectionOfItems)
            {
                if (Elements.NameOfItem == item.NameOfItem)
                {
                    Console.WriteLine($"This element is found. Info about this element:\n{Elements}");
                    break;
                }
                else
                {
                    Console.WriteLine("This element not found. Check the validity of entered name.");
                    break;
                }
            }
        }

        public int Count { get { return counterOfCollection; } }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType())) return false;

            ClassCollectionItem s = (ClassCollectionItem)obj;
            return s.Count == Count;
            
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Type : {base.ToString()} \nStorage : {Item.storage} \nLocation : {Item.locationOfItem}";
        }

        public ClassCollectionItem Unite(ClassCollectionItem coll)
        {
            ClassCollectionItem united = new ClassCollectionItem();
            foreach (Item item in this)
            {
                united.Add(item);
            }
            foreach (Item item in coll)
            {
                if (!this.IsThere(item.NameOfItem))
                    united.Add(item);
            }
            return united;
        }
        public void Dispose()
        {
            for (int i = collectionOfItems.Count - 1; i >= 0; i--)
            {
                collectionOfItems.Remove(collectionOfItems[i]);
            }
            GC.SuppressFinalize(this);
            Console.WriteLine($"///Disposed///");
        }


    }
}
