using System;
using System.IO;


namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(@"..\..\..\Files\input.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"..\..\..\Files\output.txt"))
                {
                    int row = 2;
                    while (reader.EndOfStream == false)
                    {
                        string line = reader.ReadLine();
                        if (row++ % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}
