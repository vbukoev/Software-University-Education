using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01Scheduling
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int cntOfTheTasksToBeKilled = int.Parse(Console.ReadLine());
            while (true)
            {
                int task = tasks.Peek();
                int thread = threads.Peek();
                if (task == cntOfTheTasksToBeKilled) break;
                tasks.Pop();
                threads.Dequeue();
                if (thread < task) tasks.Push(task);
            }
            Console.WriteLine($"Thread with value {threads.Peek()} killed task {cntOfTheTasksToBeKilled}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
