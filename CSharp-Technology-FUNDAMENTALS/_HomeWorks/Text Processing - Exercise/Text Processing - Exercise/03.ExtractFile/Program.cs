using System;

namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathToAFile = Console.ReadLine();
            int startIndex = pathToAFile.LastIndexOf('\\') + 1;
            string file = pathToAFile.Substring(startIndex);
            int startIndexExtension = file.IndexOf('.') + 1;
            string fileNAme = file.Substring(0, startIndexExtension - 1);
            string fileExtension = file.Substring(startIndexExtension);
            Console.WriteLine($"File name: {fileNAme}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
