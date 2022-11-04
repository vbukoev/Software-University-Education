using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CustomStructure
{
    public class CustomQueue
    {
        private const int InitialCapacity = 4;
        private const int FirstElementIndex = 0;
        private int[] items;
        private int count;
        public CustomQueue()
        {
            count = 0;
            items = new int[InitialCapacity];
        }
        public int Count => count;
        public void Enqueue(int item)
        {
            if (items.Length == count)
            {
                IncreaseSize();
            }
            items[count] = item;
            count++;
        }
        public int Dequeue()
        {
            IsEmpty();
            count--;
            var first = items[FirstElementIndex];
            SwitchElements();
            return first;
        }
        public int Peek()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty");
            }
            return items[Count - 1];
        }
        public void Clear()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty");
            }
            for (int i = 0; i < items.Length; i++)
            {
                Array.Clear(items, 0, items.Length);
            }
        }
        public void ForEach(Action<object> action)
        {
            for (int i =0; i < count; i++)
            {
                action(this.items[i]);
            }
        }
        private void SwitchElements()
        {
            items[FirstElementIndex] = default;
            for (int i = 1; i < items.Length; i++)
            {
                items[i - 1] = items[i];
            }
            items[items.Length - 1] = default;
        }

        private void IsEmpty()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
        }

        private void IncreaseSize()
        {
            int[] temp = new int[items.Length * 2];// array*2 gets every element from the array and *2 its value
            items.CopyTo(temp, 0);
            items = temp;
        }
    }
}
