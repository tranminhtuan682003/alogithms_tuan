using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alogithms_tuan.alogithms
{
    public class Queuee<T>
    {
        private int capacity;
        private T[] data;
        private int front;
        private int rear;
        private int count;

        /// <summary>
        /// Constructer of class Queue.
        /// </summary>
        public Queuee()
        {
            capacity = 1;
            data = new T[capacity];
            front = rear = 0;
            count = 0;
        }

        /// <summary>
        /// check to Queue if it empty
        /// </summary>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// check to Queue if it Full
        /// </summary>
        public bool IsFull()
        {
            return count == capacity;
        }

        /// <summary>
        /// push item into Queue if it full then update
        /// </summary>
        public void Push(T item)
        {
            if (IsFull())
            {
                UpdateCapacity();
            }
            front = (front + 1) % capacity;
            data[front] = item;
            count++;
        }

        /// <summary>
        /// delete item out the Queue if it empty then print error
        /// </summary>
        public void Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            rear = (rear + 1) % capacity;
            count--;
        }

        /// <summary>
        /// update capacity of Queue
        /// </summary>
        private void UpdateCapacity()
        {
            capacity = capacity * 2 + 1;
            T[] newData = new T[capacity];
            for (int i = 0; i < count; i++)
            {
                newData[i] = data[(rear + i) % (capacity / 2)];
            }
            rear = 0;
            front = count - 1;
            data = newData;
        }

        /// <summary>
        /// return the size of Queue;
        /// </summary>
        public int Size()
        {
            return count;
        }

        /// <summary>
        /// Retrieves the front element of the queue without removing it.
        /// </summary>
        public T Front()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return data[(rear + 1) % capacity];
        }
    }
}
