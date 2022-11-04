using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DEMO
{
    public class Program
    {
        public static void Main(string[] args)
        { 
           

            //var objectList = new ObjectList();
            //objectList.Add(1);
            //objectList.Add(new Customer());
            //objectList.Add(new Account());
            //var first = objectList[0];
            //var sec = (Customer)objectList[1];

            //List<int> strings = new List<int>();
            //List<Person> people = new List<Person>();
            ////List<string> strings = new List<string>(); // already we had defined a list with the same name as the one we are trying to create. And 
            //strings.Add(1);// 3 is an integer, we are waiting for a string as an input!!!
        }
        public void AddAll<TItem>(List<TItem> items) where TItem: Type // |  TItem->T  |, "T" MUST BE OR DERIVE FROM the argument supplifed for TItem <-
        {
            //... this is the logic...
        }

    }
}
