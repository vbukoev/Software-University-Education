namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var words = File.ReadAllLines(wordsFilePath);
            var wordCounts = new Dictionary<string, int>();
            var textLines = File.ReadAllLines(textFilePath);
            foreach (var word in words)
            {
                if (!wordCounts.ContainsKey(word))
                {
                    wordCounts.Add(word, 0);
                }
            }
            foreach (var line in textLines)
            {
                var curLine = line.Split(new char[] { ' ', '.', ',', '!', '?', '-', '\'' });
                foreach (var word in curLine)
                {
                    string lowerCase = word.ToLower();
                    if (!wordCounts.ContainsKey(lowerCase))
                    {
                        wordCounts[lowerCase] += 1;
                    }
                }
            }
            foreach (var (word, count) in wordCounts.OrderByDescending(x=>x.Value))
            {
                File.AppendAllText(outputFilePath, $"{word} - {count}{Environment.NewLine}");
            }
        }
    }
}
