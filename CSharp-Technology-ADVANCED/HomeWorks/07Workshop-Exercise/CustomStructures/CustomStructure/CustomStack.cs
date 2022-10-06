using System; 

namespace CustomStructure
{
    public class CustomStack // the stack is a LIFO(Last in-First out) so it means that the last added element will be popped from the stack (or we can say that it is an array with elements) 
    {
        private const int defaultSize = 4;//the default size which is a constant only used in this class
        private int[] items; // integer array which is a private which means it is only used in this class
        public int Count { get; private set; } //property

        public CustomStack()
        {
            this.Count = 0;
            this.items = new int[defaultSize];
        }
        public void Push(int element)
        {
            if (this.items.Length == this.Count)
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
        // adding the private methods
        private void Resize()
        {
            Resize(this.items.Length * 2);
        }
        private void Resize(int newSize)
        {
            var newValues = new int[newSize];
            for (int i = 0; i < items.Length; i++)
            {
                newValues[i] = this.items[i];
            }
            this.items = newValues;
        }
    }
}
