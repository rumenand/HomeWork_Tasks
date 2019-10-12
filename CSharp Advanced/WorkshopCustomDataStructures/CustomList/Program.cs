using System;

namespace CustomList
{
    class Program
    {
        static void Main()
        {
            var test = new CustomList();
            test.Add(4);
            test.Add(4);
            test.Add(4);
            test.Add(4);
            test.Add(4);
            test.Add(4);
            Console.WriteLine(test[3]);
            test[2] = 8;
            Console.WriteLine(test[2]);
            Console.WriteLine(test.Contains(3));
            Console.WriteLine(test.Count);
            test.Swap(2, 3);
            Console.WriteLine(test[2]);
            test.Insert(4, 15);
            Console.WriteLine("Final List");
            for (int i = 0; i < test.Count; i++)
            {
                Console.WriteLine(test[i]);
            }
           
        }
    }
}
