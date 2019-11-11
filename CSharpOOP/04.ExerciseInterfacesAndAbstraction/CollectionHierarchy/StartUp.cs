using System;
using System.Collections.Generic;
using CollectionHierarchy.Collections;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy
{
    class StartUp
    {
        static void Main()
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var line1 = new List<int>();
            var line2 = new List<int>();
            var line3 = new List<int>();

            var input = Console.ReadLine().Split();
            foreach (var item in input)
            {
                line1.Add(addCollection.Add(item));
                line2.Add(addRemoveCollection.Add(item));
                line3.Add(myList.Add(item));
            }

            var removeCount = int.Parse(Console.ReadLine());
            var line4 = new List<string>();
            var line5 = new List<string>();

            for (int i = 0; i < removeCount; i++)
            {
                line4.Add(addRemoveCollection.Remove());
                line5.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", line1));
            Console.WriteLine(string.Join(" ", line2));
            Console.WriteLine(string.Join(" ", line3));
            Console.WriteLine(string.Join(" ", line4));
            Console.WriteLine(string.Join(" ", line5));
        }
    }
}
