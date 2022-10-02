using System;

namespace DEMO
{
    internal class Program
    {
        static void Main()
        {
            PrintIntegers(1, 2);
            Console.WriteLine();
            PrintIntegers(3, 4, 6, 12);


        }        
        public static void PrintIntegers(params int[] integers)
        
        {
        
            foreach (var integer in integers)
        
                Console.Write(integer + " ");
        
        }
    }
    
}
