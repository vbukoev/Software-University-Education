using System;
using System.Collections.Generic;
using System.Text;

namespace DEMO
{
    public class ObjectList
    {
        private object[] elements;
        public ObjectList()
        {
            this.elements = new object[4];
        }
        public void Add(object value) { }
        public object Get(int index)
        {
            return this.elements[index];
        }
    }
}
