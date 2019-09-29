using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<T>
    {
        public List<T> list;            
        public Box()
        {
            this.list = new List<T>();
        }

        public void SwapElelments(int ind1, int ind2)
        {
            var temp = list[ind2];
            list[ind2] = list[ind1];
            list[ind1] = temp;
            printList();
        }

        private void printList()
        {
            foreach (var value in list)
            {
                Console.WriteLine($"{value.GetType().FullName}: {value}");
            }
            
        }
    }
}
