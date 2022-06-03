using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //sequence length 
            int sequenceLength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int[] DNA = new int[sequenceLength];
            int dnaSum = 0;
            int dnaCnt = -1;
            int dnaStartIndex = -1;
            int dnaSamples = 0;
            int sample = 0;

            while (input != "Clone them!")
            {
                //curr dna info
                sample++;
                int[] currDNA = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                //curr dna elements 
                int currCount = 0;
                int currStartIndex = 0;
                int currEndIndex = 0;
                int currDnaSum = 0;
                bool isCurrDnaBetter = false;
                int count = 0;

                for (int i = 0; i < currDNA.Length; i++)
                {
                    if (currDNA[i] != 1)
                    {
                        count = 0;
                        continue;
                    }
                    count++;
                    if (count > currCount)
                    {
                        currCount = count;
                        currEndIndex = i;
                    }
                }

                currStartIndex = currEndIndex - currCount + 1;
                currDnaSum = currDNA.Sum();

                //check which is the best DNA(currDna with best DNA)
                if (currCount > dnaCnt)
                {
                    isCurrDnaBetter = true;
                }
                else if(currCount==dnaCnt)
                {
                    if (currStartIndex<dnaStartIndex)
                    {
                        isCurrDnaBetter = true;
                    }
                    else if (currStartIndex == dnaStartIndex)
                    {
                        if(currDnaSum > dnaSum)
                        {
                            isCurrDnaBetter=true;
                        }
                    }
                }

                if(isCurrDnaBetter)
                {
                    DNA = currDNA;
                    dnaCnt = currCount;
                    dnaStartIndex = currStartIndex;
                    dnaSum = currDnaSum;
                    dnaSamples = sample;
                }

                input = Console.ReadLine();

            }
            Console.WriteLine($"Best DNA sample {dnaSamples} with sum: {dnaSum}.");
            Console.WriteLine(string.Join(" ", DNA));
        }
    }
}
