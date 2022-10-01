using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(110_122_222, 33);
            foreach (var @string in strings) Console.Write(@string + " ");
            Console.WriteLine();
            foreach (long @integer in integers) Console.Write(@integer + " ");
            Console.WriteLine();
            for (int i = 0; i < strings.Length; i++) Console.Write (strings[i] + " ");
             

        }
    }
}
