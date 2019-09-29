using System;

namespace GenericCountMethodStrings
{
    public class Box<T> : IComparable<T>
    where T : IComparable<T>
    {
        public T item;

        public Box(T item)
        {
            this.item = item;
        }
        public int CompareTo(T other)
        {
            return this.item.CompareTo(other);
        }

        public override string ToString()
        {
            return $"{this.item.GetType().FullName}: {this.item}";
        }
    }
}
