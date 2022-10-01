namespace BoxOfT
{
using System.Text;
using System;
using System.Collections.Generic;

    public class Box<T>
    {
        private List<T> elements; //list of elements
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
            T last = this.elements[this.Count - 1];
            this.elements.RemoveAt(this.Count - 1);
            return last;
        }
    }
}
