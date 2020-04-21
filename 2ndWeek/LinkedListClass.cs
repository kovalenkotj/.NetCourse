using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _2ndWeek
{
    // Task 6
    class LinkedListNode<T>
    {
        public LinkedListNode<T> Prev { get; set; }
        public LinkedListNode<T> Next { get; set; }
        public T Value { get; set; }
        public LinkedListNode(T value)
        {
            Value = value;
        }
    }
    class LinkedListClass<T>: IEnumerable<LinkedListNode<T>>
    {
        public LinkedListNode<T> First { get; set; }
        public LinkedListNode<T> Last { get; set; }
        public int Count 
        {
            get
            {
                int count = 0;
                foreach(var current in this)
                {
                    count++;
                }
                return count;
            }
        }

        public void Add(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);
            if (First == null)
            {
                First = node;
            }
            else
            {
                Last.Next = node;
                node.Prev = Last;
            }
            Last = node;
        }

        public void Remove(T value)
        {
            LinkedListNode<T> current = First;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    Last = current.Prev;
                }

                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    First = current.Next;
                }
            }
        }

        public IEnumerator<LinkedListNode<T>> GetEnumerator()
        {
            LinkedListNode<T> current = First;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
