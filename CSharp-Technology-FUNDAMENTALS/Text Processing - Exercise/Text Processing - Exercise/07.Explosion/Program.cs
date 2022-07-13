using System;

namespace _07.Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int strenght = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];
                if (symbol == '>')
                {
                    strenght += int.Parse(input[i + 1].ToString());
                    continue;
                }
                if (strenght > 0)
                {
                    input = input.Remove(i, 1);
                    i--;
                    strenght--;
                }
            }
            Console.WriteLine(input);
        }
    }
}
