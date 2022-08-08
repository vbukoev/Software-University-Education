using System;
using System.Linq;

namespace _01._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStringsToRead = int.Parse(Console.ReadLine());
            int[] numberOfSequences = new int[numberOfStringsToRead];
            char[] vowels = { 'a', 'A', 'o', 'O', 'e', 'E',
                              'i', 'I', 'u', 'U'/*, 'y', 'Y'*/};
            for (int i = 0; i < numberOfStringsToRead; i++)
            {
                string input = Console.ReadLine();
                char[] charsFromTheInput = input.ToCharArray();
                int sum = 0;
                for (int j = 0; j < charsFromTheInput.Length; j++)
                {
                    if (vowels.Contains(charsFromTheInput[j]))
                    {
                        sum += charsFromTheInput[j] * input.Length;
                    }
                    else
                    {
                        sum += charsFromTheInput[j] / input.Length;
                    }
                }
                numberOfSequences[i] = sum;                    
            }
            Array.Sort(numberOfSequences);// sort the the numbers in the int array
            for (int i = 0; i < numberOfSequences.Length; i++)
            {
                Console.WriteLine(numberOfSequences[i]);
            }
        }
    }
}
