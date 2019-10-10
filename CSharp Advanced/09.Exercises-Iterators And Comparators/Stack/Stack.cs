using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {        
        private T []  collection;
        private int tail;
        
        public Stack ()
        {
            this.collection = new T[4];
            tail = -1;
        }

        public void Push (T [] items)
        {
            foreach (var item in items)
            {
                tail++;
                if (tail == collection.Length) collection = ResizeArray();
                collection[tail] = item;                
            }
        }

        public T Pop()
        {
            if (tail < 0)
            {
                Console.WriteLine("No elements");
                return default(T);
            }
            else
            {
                T item = collection[tail];
                tail--;
                return item;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = tail; i >= 0; i--)
            {
                yield return collection[i];
            }
        }

        private T [] ResizeArray()
        {
            T[] newArray = new T [collection.Length*2];
            Array.Copy(collection, newArray, collection.Length);
            return newArray;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }       
    }
}
