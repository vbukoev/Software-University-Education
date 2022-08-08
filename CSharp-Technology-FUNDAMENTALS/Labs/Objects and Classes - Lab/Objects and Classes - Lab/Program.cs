using System;

namespace Objects_and_Classes___Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');
            Random random = new Random();
            
            for (int i = 0; i < words.Length; i++)
            {
                int indexRandom = random.Next(0, words.Length);
                string currWord = words[i];
                words[i] = words[indexRandom];
                words[indexRandom] = currWord;
            }
            foreach (var item in words) Console.WriteLine(item);
        }
    }
}
