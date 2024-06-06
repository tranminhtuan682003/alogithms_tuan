using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alogithms_tuan.alogithms
{
    public class Stack<T>
    {
        private int top;
        private int capacity;
        private T[] array;

        public Stack(int initialCapacity)
        {
            capacity = initialCapacity;
            array = new T[capacity];
            top = -1;
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public bool IsFull()
        {
            return top == capacity - 1;
        }

        public void Push(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack is Full");
                if (!UpdateCapacity(capacity * 2 + 1))
                {
                    throw new InvalidOperationException("Cannot increase stack capacity.");
                }
            }
            array[++top] = item;
        }

        public bool UpdateCapacity(int newCapacity)
        {
            if (newCapacity <= capacity)
            {
                return false;
            }

            T[] newArray = new T[newCapacity];
            Array.Copy(array, newArray, top + 1);
            array = newArray;
            capacity = newCapacity;
            return true;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is Empty");
            }
            return array[top--];
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is Empty");
            }
            return array[top];
        }

        public void Display()
        {
            for (int i = 0; i <= top; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
