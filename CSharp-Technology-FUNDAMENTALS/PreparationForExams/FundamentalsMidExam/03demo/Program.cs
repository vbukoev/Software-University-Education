using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExam
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //02. Numbers
            //"Add {value}"
            //"Remove {value}"
            //"Replace {value} {replacement}"
            //"Collapse {value}"
            //"Finish"

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = "";
            {
                while (command != "Finish")
                {
                    command = Console.ReadLine();
                    string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string cmd = cmdArgs[0];

                    if (cmd == "Add")
                    {
                        int numToAdd = int.Parse(cmdArgs[1]);
                        numbers.Add(numToAdd);
                    }
                    else if (cmd == "Remove")
                    {

                        int numToRemove = int.Parse(cmdArgs[1]);
                        if (numbers.Contains(numToRemove))
                        {
                            numbers.Remove(numToRemove);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (cmd == "Replace")
                    {
                        int numToReplace = int.Parse(cmdArgs[1]);
                        int replacement = int.Parse(cmdArgs[2]);
                        if (numbers.Contains(numToReplace))
                        {
                            int index = numbers.IndexOf(numToReplace);
                            numbers[index] = replacement;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (cmd == "Collapse")
                    {
                        
                    }

                }

                Console.WriteLine(string.Join(" ", numbers));
            }

        }
    }
}
