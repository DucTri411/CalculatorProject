using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    class LinkedStack<T>
    {
        private Node<T> top;

        public LinkedStack()
        {
            top = null;
        }

        public void Push(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.Next = top;
            top = newNode;
        }

        public T Pop()
        {
            if (top == null)
            {
                throw new Exception("Stack is empty");
            }

            T value = top.Value;
            top = top.Next;
            return value;
        }

        public T Peek()
        {
            if (top == null)
            {
                throw new Exception("Stack is empty");
            }

            return top.Value;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public void Clear()
        {
            top = null;
        }
    }

}
