using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> elements;
        public int Count => this.elements.Count;
        public Box()
        {
            this.elements = new List<T>();
        }
        public void Add(T element)
        {
            this.elements.Add(element);
        }
        public T Remove()
        {
            var last = this.elements[Count - 1];
            this.elements.RemoveAt(this.Count - 1);
            return last;
        }
    }
}
