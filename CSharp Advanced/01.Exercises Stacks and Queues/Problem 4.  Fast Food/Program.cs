using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4.__Fast_Food
{
    class Program
    {
        static void Main()
        {
            int foodQuantity = int.Parse(Console.ReadLine());            
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Console.WriteLine(orders.Max());
            while(orders.Count>0)
            {
                int newOrder = orders.Peek();
                if ((foodQuantity - newOrder) > -1)
                {
                    foodQuantity -= newOrder;
                    orders.Dequeue();
                }
                else break;
            }
            if (orders.Count > 0) Console.WriteLine($"Orders left: {string.Join(" ",orders)}");
            else Console.WriteLine("Orders complete");
            
        }
    }
}