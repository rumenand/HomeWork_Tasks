using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
   public class ArrayCreator<T>
    {
        static T[] Create(int length, T item)
        {
            var array = new T [length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = item;
            }
            return array;
        }
    }
}
