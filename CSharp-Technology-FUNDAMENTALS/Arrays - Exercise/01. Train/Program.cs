using System;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int numOfWagons = int.Parse(Console.ReadLine());
            int sum = 0;
            int[] wagons = new int[numOfWagons];
            for (int i = 0; i < wagons.Length; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
                sum += wagons[i];
            }
            foreach (var wagon in wagons)
            {
                Console.Write($"{wagon} ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);


            //int numOfWagons = int.Parse(Console.ReadLine());
            //int sum = 0;
            //int[] wagons = new int[numOfWagons];   
            //for (int i = 0; i < wagons.Length; i++)
            //{
            //    wagons[i]= int.Parse(Console.ReadLine());               
            //    sum += wagons[i];
            //}
            //for (int i = 0; i < wagons.Length; i++)
            //{
            //    Console.Write($"{wagons[i]} ");

            //}
            //Console.WriteLine();
            //Console.WriteLine(sum);
        }
    }
}
