using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    class Program
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var list = new List<Box<string>>();
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine();
                list.Add(new Box<string>(input));
            }
            var value = Console.ReadLine();
            Console.WriteLine(GetBiggerItems(list,value));           
        }
        static int GetBiggerItems<T> (IEnumerable<Box<T>> list, T compareItem) where T : IComparable<T>
        {
            int counter = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(compareItem) > 0) counter++;
            }
            return counter;
        }
    }
}
