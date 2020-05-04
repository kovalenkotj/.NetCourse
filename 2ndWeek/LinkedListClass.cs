using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace _2ndWeek
{
    // Task 1
    class ListActionsEventArgs<T> : EventArgs
    {
        public T Value { get; }
        public string Message { get; }
        public ListActionsEventArgs(string message, T value)
        {
            Value = value;
            Message = message;
        }

    }

    // Task 6
    [Serializable]
    public class LinkedListNode<T>
    {
        [XmlElement]
        public LinkedListNode<T> Prev { get; set; }
        [XmlElement]
        public LinkedListNode<T> Next { get; set; }
        //[XmlAttribute]
        [XmlElement]
        public T Value { get; set; }
        public LinkedListNode() { }
        public LinkedListNode(T value)
        {
            Value = value;
        }
    }
    [Serializable]
    public class LinkedListClass<T>: IEnumerable<LinkedListNode<T>>
    {
        delegate void ListActionsHandler(object sender, ListActionsEventArgs<T> e);
        [field: NonSerialized]
        event ListActionsHandler ActionMessage;
        [XmlElement]
        public LinkedListNode<T> First { get; set; }
        [XmlElement]
        public LinkedListNode<T> Last { get; set; }
        /* Task 6, Week 3:
         "Modify your class so that the some member will not be serialized, 
         but will be automatically defined upon deserialization"*/
        [field: NonSerialized]
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

        public LinkedListClass()
        {
            ActionMessage += DisplayMessage;
        }

        public void Add(object v) { }
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
            ActionMessage.Invoke(this, 
                new ListActionsEventArgs<T>($"The value {value.ToString()} was added to the {value.GetType().Name} list", value));
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
                ActionMessage.Invoke(this, 
                    new ListActionsEventArgs<T>($"The value {value.ToString()} was removed from the {value.GetType().Name} list", value));
            }
        }

        void DisplayMessage(object sender, ListActionsEventArgs<T> e)
        {
            Console.WriteLine(e.Message);
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
