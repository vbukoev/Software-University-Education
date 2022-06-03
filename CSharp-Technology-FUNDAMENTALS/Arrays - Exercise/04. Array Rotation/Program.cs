using System;
using System.Linq;

namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int rotation = 0; rotation < rotations; rotation++)
            {
                int tempElement = array[0];
                for (int operations = 0; operations < array.Length-1; operations++)
                {
                    array[operations] = array[operations + 1];
                }
                array[array.Length - 1] = tempElement;
            }
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
