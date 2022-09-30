using System;

namespace CustomStructure
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new CustomList();

            list.Add(1);
            list.Add(3);
            list.Add(5);

            
            list.RemoveAt(3);

            //list.InsertAt(100, 51);

            list.Insert(4, 8);
            list.Swap(0, 8);

            
        }
    }
}
