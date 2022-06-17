using System;
using System.Linq;

namespace _09PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {

            var sequence = Console.ReadLine().Split().Select(int.Parse).ToList(); 
            int index;
            int currValue;
            int sum = 0;

            while (sequence.Count != 0)
            {
                index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    currValue = sequence[0];
                    sum += currValue;
                    sequence[0] = sequence[sequence.Count - 1];
                }
                else if (index > sequence.Count - 1)
                {
                    currValue = sequence[sequence.Count - 1];
                    sum += currValue;
                    sequence[sequence.Count - 1] = sequence[0];
                }
                else
                {
                    currValue = sequence[index];
                    sum += currValue;
                    sequence.RemoveAt(index);
                }
                for (int i = 0; i < sequence.Count; i++)
                {
                    if (sequence[i] <= currValue)
                    {
                        sequence[i] += currValue;
                    }
                    else
                    {
                        sequence[i] -= currValue;
                    }
                }
            }

            Console.WriteLine(sum);


            //    List<int> pokemons = Console.ReadLine()
            //        .Split()
            //        .Select(int.Parse)
            //        .ToList();

            //    int sumOfRemovedNumbers = 0;

            //    while (pokemons.Count != 0)
            //    {
            //        int indexToRemove = int.Parse(Console.ReadLine());

            //        if (indexToRemove >= 0 && indexToRemove < pokemons.Count)
            //        {
            //            int removedNumber = pokemons[indexToRemove];
            //            sumOfRemovedNumbers = sumOfRemovedNumbers + removedNumber;

            //            pokemons.RemoveAt(indexToRemove);

            //            IncreasingAndDecreasing(pokemons, removedNumber);
            //        }
            //        else if (indexToRemove < 0)
            //        {
            //            int removedNumber = pokemons[0];
            //            sumOfRemovedNumbers = sumOfRemovedNumbers + removedNumber;

            //            pokemons.RemoveAt(0);
            //            pokemons.Insert(0, pokemons[pokemons.Count - 1]);

            //            IncreasingAndDecreasing(pokemons, removedNumber);
            //        }
            //        else if (indexToRemove > pokemons.Count - 1)
            //        {
            //            int removedNumber = pokemons[pokemons.Count - 1];
            //            sumOfRemovedNumbers = sumOfRemovedNumbers + removedNumber;

            //            pokemons.RemoveAt(pokemons.Count - 1);
            //            pokemons.Add(pokemons[0]);

            //            IncreasingAndDecreasing(pokemons, removedNumber);
            //        }
            //    }

            //    Console.WriteLine(sumOfRemovedNumbers);
            //}

            //private static void IncreasingAndDecreasing(List<int> pokemons, int removedNumber)
            //{
            //    for (int i = 0; i < pokemons.Count; i++)
            //    {
            //        if (pokemons[i] <= removedNumber)
            //        {
            //            pokemons[i] = pokemons[i] + removedNumber;
            //        }
            //        else
            //        {
            //            pokemons[i] = pokemons[i] - removedNumber;
            //        }
            //    }
        }
    }
}