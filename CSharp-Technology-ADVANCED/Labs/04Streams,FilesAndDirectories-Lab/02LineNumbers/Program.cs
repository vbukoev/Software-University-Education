using System;
using System.IO;


namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputFilePath, outputFilePath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(@"..\..\..\Files\input.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"..\..\..\Files\output.txt"))
                {
                    int row = 1;
                    
                        string line = reader.ReadLine();

                    while (line!=null)
                    {
                        writer.WriteLine($"{row}. {line}");
                        row++;
                        line = reader.ReadLine();
                    }
                    
                }
            }
        }
    }
}
