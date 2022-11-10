namespace IteratorsAndComparators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class Stack<T> : IEnumerable<T>
    {
        private const int length = 8;
        private T[] collection;
        public int Count { get; private set; }
        public Stack()
        {
            this.collection = new T[length]; // T[8]
            this.Count = 0;
        }
        public void Push(params T[] values)
        {
            foreach (var item in values) 
            {
                if (collection.Length == Count)// this does the resizing function
                {
                    var arr = new T[collection.Length * 2];
                    for (int i = 0; i < collection.Length; i++)
                    {
                        arr[i] = collection[i];
                    }
                    collection = arr;
                }
                collection[Count] = item;
                Count++;
            }
        }
        public T Pop()
        {
            if (Count == 0)// checks if the stack's empty
            {
                throw new InvalidOperationException("No elements");
            }
            var temp = collection[Count - 1];
            collection[Count - 1] = default;
            Count -= 1;
            return temp;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count-1; i >= 0; i--)
            {
                yield return collection[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}