using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList2
{
    class CustomLinkedList<V>
    {
        private class ListNode<T>
        {
            public T Value { get; set; }
            public ListNode<T> NextNode { get; set; }
            public ListNode<T> PreviousNode { get; set; }

            public ListNode(T value)
            {
                this.Value = value;
            }
        }
        private ListNode<V> head;
        private ListNode<V> tail;

        public int Count { get; private set; }

        public void AddFirst(V element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<V>(element);
            }
            else
            {
                var newHead = new ListNode<V>(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }
            this.Count++;
        }

        public void AddLast(V element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<V>(element);
            }
            else
            {
                var newTail = new ListNode<V>(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }

        public V RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = this.head.Value;
            this.head = this.head.NextNode;
            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }
            this.Count--;
            return firstElement;

        }

        public V RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            var lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;
            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }
            this.Count--;
            return lastElement;
        }

        public void ForEach(Action<V> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                while (currentNode != null)
                {
                    action(currentNode.Value);
                    currentNode = currentNode.NextNode;
                }
            }
        }

        public V[] ToArray()
        {
            V[] array = new V[this.Count];
            int counter = 0;
            var currentNode = this.head;
            while (currentNode != null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
                counter++;
            }
            return array;
        }
    }
}
