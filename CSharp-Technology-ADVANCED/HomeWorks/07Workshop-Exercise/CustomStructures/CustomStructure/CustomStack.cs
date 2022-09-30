using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CustomStructure
{
    public class CustomStack
    {
        private const int defaultSize = 4;
        private int[] items;
        public int Count { get; private set; }

        public CustomStack()
        {
            this.Count = 0;
            this.items = new int[defaultSize];
        }
        public void Push(int element)
        {
            if (items.Length == Count)
            {
                var next = new int[this.items.Length * 2];
                for (int i = 0; i < this.items.Length; i++)
                {
                    next[i] = this.items[i];
                }
                this.items = next;
            }
            this.items[this.Count] = element;
            Count++;
        }
        public int Pop()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
            var lastIndex = this.Count - 1;
            int last = this.items[lastIndex];
            Count--;
            return last;
        }
        public int Peek()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
            return items[Count - 1];
        }
        public void ForEach(Action<object> action)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                action(items[i]);
            }
        }

    }
}
