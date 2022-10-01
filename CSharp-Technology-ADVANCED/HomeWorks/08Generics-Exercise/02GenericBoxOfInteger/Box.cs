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
