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

        public Queuee()
        {
            capacity = 1;
            data = new T[capacity];
            front = rear = 0;
            count = 0;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public bool IsFull()
        {
            return count == capacity;
        }

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

        public void Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            rear = (rear + 1) % capacity;
            count--;
        }

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

        public int Size()
        {
            return count;
        }

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
