using System;
using System.Collections.Generic;
using System.Linq;

namespace _01FlowerWreaths
{
    public class Program
    {
        private const int a = 5;
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int cntOfFlowers = 0;
            int cntOfWreaths = 0;
            while (true)
            {
                if (!lilies.Any() || !roses.Any()) break;
                int lilly = lilies.Peek();
                int rose = roses.Peek();
                if (lilly + rose > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                    continue;
                }
                else if (lilly + rose < 15) cntOfFlowers = cntOfFlowers + lilly + rose;
                else cntOfWreaths++;
                lilies.Pop();
                roses.Dequeue();
            }
            cntOfWreaths += cntOfFlowers / 15;
            if (cntOfWreaths >= 5) Console.WriteLine($"You made it, you are going to the competition with {cntOfWreaths} wreaths!");
            else Console.WriteLine($"You didn't make it, you need {a - cntOfWreaths} wreaths more!");
        }
    }
}
