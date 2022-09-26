namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = "../../../text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            char[] symbolsForReplace = { '-', ',', '.', '!', '?' };
            using StreamReader sr = new StreamReader(inputFilePath);
            var cnt = 0;
            var currLine = "";

            while (!sr.EndOfStream)
            {
                currLine = sr.ReadLine();
                if (cnt % 2 == 0)
                {
                    foreach (var item in symbolsForReplace)
                    {
                        currLine = currLine.Replace(item, '@');
                    }
                    var reversed = currLine.Split(' ');
                    Console.WriteLine(String.Join(" ", reversed.Reverse()));
                }
                cnt++;
            }
            return "";
        }
    }
}
