using System;
using System.Collections.Generic;

namespace DEMO
{
    public class Program
    {
        static void Main(string[] args)
        { 
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            dictionary.Add("123", 1);
            dictionary.Add("234", 122);
            dictionary.Add("23", 3);
            dictionary.Add("12", 4);
            dictionary.Add("4563", 5);
            dictionary.Add("9", 6);
            dictionary.Add("2211", 7);
            dictionary.Add("2213", 8);
            dictionary.Add("64", 9);
            dictionary.Add("1285673", 32);
            dictionary.Add("1312", 345);
            dictionary.Add("1234", 777);
            dictionary.Add("asd", 789);
            dictionary.Add("2623", 4);
            dictionary.Add("99", 5);
            dictionary.Add("623", 7);
            dictionary.Add("12421626", 6);
            dictionary.Add("1236", 5);
            dictionary.Add("77", 4);
            dictionary.Add("1213", 12312);
            dictionary.Add("3125", 412);
            dictionary.Add("135", 2312341);
            dictionary.Add("532", 3124125);
            dictionary.Add("0", 2412);
            dictionary.Add("128525673", 423);
            dictionary.Add("88", 412);
            dictionary.Add("523", 234);
            dictionary.Add("25", 421);
            dictionary.Add("5", 412);
            dictionary.Add("346", 421);
            bool bolean = false;

            if(dictionary.ContainsValue(412)) // return true
            {
                bolean = true;
                Console.WriteLine(bolean);                
            }
            if(dictionary.ContainsKey("345")) //return true
            {
                bolean = true;
                Console.WriteLine(bolean);
            }
        }
}
}
            

