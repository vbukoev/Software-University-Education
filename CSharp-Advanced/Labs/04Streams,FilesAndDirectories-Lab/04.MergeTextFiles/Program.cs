namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            var mergedList = new List<string>();
            var firstLines=  File.ReadAllLines(firstInputFilePath);
            var secLines=  File.ReadAllLines(secondInputFilePath);
            foreach (var line in firstLines)
            {
                mergedList.Add(line);
            }
            foreach (var line in secLines)
            {
                mergedList.Add(line);
            }
            File.WriteAllLines(outputFilePath, mergedList.OrderBy(x => x));
        }
    }
}
