namespace IteratorsAndComparators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index;
        public ListyIterator(params T[] elements)
        {
            this.elements = new List<T>(elements);
            this.index = 0;
        }
        public bool Move()
        {
            if (index + 1 < elements.Count)
            {
                index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            if (index + 1 < elements.Count)
            {
                return true;
            }
            return false;
        }
        public T Print()
        {
            if (elements.Count ==0)
            {
                throw new InvalidOperationException("Invalid operation!");
            }
            return elements[index];
        }
        public string PrintAll()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation!");
            }
            return string.Join(" ", elements);
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in elements)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
