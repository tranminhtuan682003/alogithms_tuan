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

        /// <summary>
        /// Initializes a new instance of the Stack class with a specified capacity.
        /// </summary>
        public Stack(int initialCapacity)
        {
            capacity = initialCapacity;
            array = new T[capacity];
            top = -1;
        }

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        public bool IsEmpty()
        {
            return top == -1;
        }


        /// <summary>
        /// Checks if the stack is full.
        /// </summary>
        public bool IsFull()
        {
            return top == capacity - 1;
        }

        /// <summary>
        /// Pushes an item onto the stack. If the stack is full, it attempts to increase the capacity.
        /// </summary>
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

        /// <summary>
        /// Updates the capacity of the stack.
        /// </summary>
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

        /// <summary>
        /// Pops an item from the stack.
        /// </summary>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is Empty");
            }
            return array[top--];
        }

        /// <summary>
        /// Peeks at the top item of the stack without removing it.
        /// </summary>
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is Empty");
            }
            return array[top];
        }

        /// <summary>
        /// Displays all items in the stack.
        /// </summary>
        public void Display()
        {
            for (int i = 0; i <= top; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
