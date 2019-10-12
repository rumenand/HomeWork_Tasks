using System;

namespace CustomList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;

        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                if (index >= this.Count || index <0) throw new ArgumentOutOfRangeException();
                return items[index];
            }
            set
            {
                if (index >= this.Count || index <0) throw new ArgumentOutOfRangeException();
                items[index] = value;
            }
        }

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count-1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }

        public void Add(int item)
        {
            if (this.Count == this.items.Length) this.Resize();
            this.items[this.Count] = item;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            if (index >= 0) throw new ArgumentOutOfRangeException();
            var removedItem = this.items[index];
            this.Shift(index);
            this.Count--;
            if (this.Count <= this.items.Length / 4) this.Shrink();
            return removedItem;
        }

        public void Insert(int index, int element)
        {
            if (index > this.Count || index < 0) throw new ArgumentOutOfRangeException();
            if (this.Count == this.items.Length) this.Resize();
            this.ShiftToRight(index);
            this.items[index] = element;
            this.Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element) return true;
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex > this.Count || firstIndex < 0) throw new ArgumentOutOfRangeException();
            if (secondIndex > this.Count || secondIndex < 0) throw new ArgumentOutOfRangeException();
            var temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }
    }
}
