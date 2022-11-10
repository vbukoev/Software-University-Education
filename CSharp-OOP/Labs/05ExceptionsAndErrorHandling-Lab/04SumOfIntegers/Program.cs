using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04SumOfIntegers
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split());
            while (queue.Any())
            {
                int number = 0;
                string element = queue.Dequeue();
                try
                {
                    number = int.Parse(element);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException ofe)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }

                sum += number;
                Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
