namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            int cnt = 1;
            var text = File.ReadAllLines(inputFilePath);

            foreach (var line in text)
            {
                int letters = line.Count(char.IsLetter);
                int punctuations = line.Count(char.IsPunctuation);
                File.AppendAllText(outputFilePath, $"Line {cnt}: {line} ({letters})({punctuations}){Environment.NewLine}");

                cnt++;
            }
            //for (int i = 0; i < text.Length; i++)
            //{
            //    int letters = text[i].Count(char.IsLetter);
            //    int punctuations = line.Count(char.IsPunctuation);
            //    File.AppendAllText(outputFilePath, $"Line {cnt}: {line} ({letters})({punctuations}){Environment.NewLine}");

            //    cnt++;
            //}
        }
    }
}