using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ArrayModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    Console.WriteLine(string.Join(", ", numbers));
                    break;
                }
                string[] tokens = command.Split();
                string action = tokens[0];
                switch (action)
                {
                    case "swap":
                        Swap(int.Parse(tokens[1]), int.Parse(tokens[2]), numbers);
                        break;
                    case "multiply":
                        Multiply(int.Parse(tokens[1]), int.Parse(tokens[2]), numbers);

                        break;
                    case "decrease":
                        Decrease(numbers);
                        break;

                }
            }
        }

        private static void Swap(int firstIndex, int secondIndex, List<int> numbers)
        {
            int num1 = numbers[firstIndex];
            int num2 = numbers[secondIndex];
            int temp = num1;

            numbers[firstIndex] = num2;
            numbers[secondIndex] = temp;
        } 
        private static void Multiply(int firstIndex, int secondIndex, List<int> numbers)
        {
            numbers[firstIndex] = numbers[firstIndex] * numbers[secondIndex];
        }
        private static void Decrease(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]--;
            }
        }

    }
}
