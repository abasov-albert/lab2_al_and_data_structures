using System;
using System.Text;

namespace ConsoleApp1.Model
{
    public class MyList<T>
    {
        private Element<T> Head { get; set; }
        private Element<T> Tail { get; set; }
        private int Count { get; set; }

        public MyList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void Add(T value)
        {
            Element<T> elem = new Element<T>(value);
            
            if (Tail != null)
            {
                Tail.Next = elem;
                Tail = elem;
                Tail.Next = Head;
                Count++;
            }
            else
            {
                Head = elem;
                Tail = elem;
                Count = 1;
            }
        }

        public T Get(int index)
        {
            if (index == Count - 1)
            {
                return Tail.Value;
            }
            else if (index == 0)
            {
                return Head.Value;
            }

            Element<T> currentElem = Head;
            int current = 0;
            while (current < index)
            {
                currentElem = currentElem.Next;
                current++;
            }

            return currentElem.Value;
        }

        public void Add(T value, int index)
        {
            Element<T> current = Head;
            Element<T> previos = Head;
            Element<T> newElement = new Element<T>(value);
            for (var i = 0; i < index; i++)
            {
                previos = current;
                current = current.Next;
            }

            previos.Next = newElement;
            newElement.Next = current;
        }

        public void Remove(T value)
        {
            Element<T> current = Head;
            Element<T> previos = Head;
            for (var i = 0; i < Count; i++)
            {
                if (Equals(current.Value, value))
                {
                    previos.Next = current.Next;
                    Count--;
                }

                previos = current;
                current = current.Next;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            Element<T> current = Head;
            for (var i = 0; i < Count; i++)
            {
                sb.Append(current.Value);
                sb.Append(", ");
                current = current.Next;
            }

            sb.Append("]");
            
            return sb.ToString();
        }

        public void PrintFormatted()
        {
            Element<T> current = Head;

            int max = current.Value.ToString().Length;
            for (var i = 0; i < Count; i++)
            {
                var length = current.Value.ToString().Length;
                if (length > max)
                {
                    max = length;
                }
                current = current.Next;
            }
            
            current = Head;
            for (var i = 0; i < Count; i++)
            {
                Console.WriteLine(String.Format("{0, " + max + "}", current.Value));
                current = current.Next;
            }
            
        }
    }


    public class Element<T>
    {
        public T Value { get; set; }
        public Element<T> Next { get; set; }

        public Element(T value)
        {
            Value = value;
        }
    }
}