namespace _05PlayCatch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int exceptions = 0;
            while (exceptions < 3)
            {
                string[] cmd = Console.ReadLine().Split();

                try
                {
                    if (cmd[0] == "Replace") Replace(array, int.Parse(cmd[1]), int.Parse(cmd[2]));
                    else if (cmd[0] == "Print") Print(array, int.Parse(cmd[1]), int.Parse(cmd[2]));
                    else if (cmd[0] == "Show") Show(array, int.Parse(cmd[1]));
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptions++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptions++;
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }

        public static void Show(int[] array, int index)
        {
            Console.WriteLine(array[index]);
        }

        public static void Print(int[] array, int index, int element)
        {
            Queue<int> queue = new Queue<int>();
            for (int i = index; i <= element; i++)
            {
                queue.Enqueue(array[i]);
            }

            Console.WriteLine(string.Join(", ", queue));
        }

        public static void Replace(int[] array, int index, int element)
        {
            array[index] = element;
        }
    }
}
