using System;

namespace CustomStack
{
    public class CustomStack
    {
        private const int initialCapacity = 4;
        private int[] items;
        private int count;

        public CustomStack()
        {
            this.count = 0;
            this.items = new int[initialCapacity];
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Push(int element)
        {
            if (this.count == this.items.Length)
            {
                var nextItems = new int[this.count * 2];
                for (int i = 0; i < items.Length; i++)
                {
                    nextItems[i] = this.items[i];
                }
                this.items = nextItems;
            }
            this.items[this.count] = element;
            this.count++;
        }

        public int Pop()
        {
            if (this.items.Length == 0) throw new InvalidOperationException("CustomStack is empty");
            this.count--;
            return this.items[this.count];
        }

        public int Peek()
        {
            if (this.items.Length == 0) throw new InvalidOperationException("CustomStack is empty");
            return this.items[count - 1];
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.items[i]);
            }
        }
    }
}
