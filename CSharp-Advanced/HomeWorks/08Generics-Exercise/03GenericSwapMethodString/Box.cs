using System;
using System.Collections.Generic;
using System.Text;

namespace _01GenericBoxOfString
{
    public class Box<T>
    {
        private List<T> values;
        public Box()
        {
            this.values = new List<T>();
        }
        public void Add(T value)
        {
            this.values.Add(value);
        }
        public void Swap(int first, int sec)
        {
            if (this.values.Count == 0)
            {
                throw new InvalidOperationException("Collection is empty!");
            }
            if (first<0|| first >=this.values.Count || sec<0 || sec>=this.values.Count)
            {
                throw new IndexOutOfRangeException();
            }
            var temp = this.values[first];
            this.values[first] = this.values[sec];
            this.values[sec] = temp;
        }
        public override string ToString()
        {
            var res = new StringBuilder();
            foreach (var item in this.values)
            {
                res.AppendLine($"{item.GetType()}: {item}");
            }
            return res.ToString();
        }
    }
}
