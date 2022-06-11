using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    int givenIndex = int.Parse(command[1]);
                    arr = ExchangeArr(arr, givenIndex);
                }
                else if (command[0] == "max" || command[0] == "min")
                {
                    FindMinMax(arr, command[0], command[1]);
                }
                else
                {
                    FindNumbers(arr, command[0], int.Parse(command[1]), command[2]);
                }
                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"[{string.Join(", ", arr)}]");


            //int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //string[] command = Console.ReadLine().Split();
            //while (command[0] != "end")
            //{
            //    if (command[0] == "exchange")
            //    {
            //        int givenIndex = int.Parse(command[1]);
            //        arr = ExchangeArr(arr, givenIndex);
            //    }
            //    else if (command[0] == "max" || command[0] == "min")
            //    {
            //        FindMinMax(arr, command[0], command[1]);
            //    }
            //    else
            //    {
            //        FindNumbers(arr, command[0], int.Parse(command[1]), command[2]);
            //    }
            //    command = Console.ReadLine().Split();
            //}
            //Console.WriteLine($"[{string.Join(", ", arr)}]");
        }

        private static void FindNumbers(int[] arr, string position, int numCnt, string evenOrOdd)
        {
            if (numCnt > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            if (numCnt == 0)
            {
                Console.WriteLine($"[]");
                return;
            }

            int resultEvenOrOdd = 1;
            if (evenOrOdd == "even") resultEvenOrOdd = 0;

            int count = 0;
            List<int> nums = new List<int>();

            if (position == "first")
            {
                foreach (int num in arr)
                {
                    if (num % 2 == resultEvenOrOdd)
                    {
                        count++;
                        nums.Add(num);
                    }
                    if (count == numCnt) break;
                }
            }
            else
            {
                for (int currIndex = arr.Length - 1; currIndex >= 0; currIndex--)
                {
                    if (arr[currIndex] % 2 == resultEvenOrOdd)
                    {
                        count++;
                        nums.Add(arr[currIndex]);
                    }

                    if (count == numCnt) break;
                }
                nums.Reverse();
            }
            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }

        private static void FindMinMax(int[] arr, string minOrMax, string evenOrOdd)
        {
            int index = -1;//za da znam che posle si namiram po-golqmo ili po-malkoto chislo
            int min = int.MaxValue;
            int max = int.MinValue;
            int resultOddEven = 1;

            if (evenOrOdd == "even") resultOddEven = 0;

            for (int currIndex = 0; currIndex < arr.Length; currIndex++)
            {
                if (arr[currIndex] % 2 == resultOddEven)
                {
                    if (minOrMax == "min" && min >= arr[currIndex])
                    {
                        min = arr[currIndex];
                        index = currIndex;
                    }
                    else if (minOrMax == "max" && max <= arr[currIndex])
                    {
                        max = arr[currIndex];
                        index = currIndex;
                    }


                }
            }
            Console.WriteLine(index > -1 ? index.ToString() : "No Matches");
        }
        private static int[] ExchangeArr(int[] arr, int splitIndex)
        {
            if (splitIndex >= arr.Length || splitIndex < 0)
            {
                Console.WriteLine("Invalid index");
                return arr;
            }
            int[] exchangedArr = new int[arr.Length];
            int index = 0;
            for (int i = splitIndex + 1; i < arr.Length; i++)
            {
                exchangedArr[index] = arr[i];
                index++;
            }
            for (int i = 0; i <= splitIndex; i++)
            {
                exchangedArr[index] = arr[i];
                index++;
            }
            return exchangedArr;
        }
    }
}