using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace _01GenericBoxOfString
{
    public class Box<T> where T : IComparable // i had to add the constraints which use "where T + :" and the ref type, otherwise the task won't work
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
        public int GreaterCount(T value)
        {
            if (this.values.Count == 0)
            {
                throw new InvalidOperationException("Collection is empty!");
            }
            int cnt = 0;
            foreach (T item in this.values)
            {
                if (item.CompareTo(value) <= 0)
                {
                    continue;
                }
                cnt++;
            }
            return cnt;
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
