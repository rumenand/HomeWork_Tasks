using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_1._ListyIterator
{
    class ListyIterator<T>
    {
        private List<T> list;
        private int currentIndex;

        public ListyIterator()
        {
            this.list = new List<T>();
            this.currentIndex = 0;
        }

        public ListyIterator(IEnumerable<T> collection)
        {
            this.list = new List<T>(collection);
            this.currentIndex = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                this.currentIndex++;
                return true;
            }
            return false;
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(list[currentIndex]);
            }
            catch
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public bool HasNext()
        {
            if (this.list.Count - 1 > currentIndex) return true;            
            return false;
        }
    }
}
