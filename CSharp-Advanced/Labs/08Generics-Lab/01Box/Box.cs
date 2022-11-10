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
        public void Add(T element) //adding element of type "T"
        {
            this.elements.Add(element);
        }
        public T Remove() // we firstly take the first element and then we remove the topmost element and return last element (which is the element with the count of the elements minus 1)
        {
            T last = this.elements[this.Count - 1];
            this.elements.RemoveAt(this.Count - 1);
            return last;
        }
    }
}
