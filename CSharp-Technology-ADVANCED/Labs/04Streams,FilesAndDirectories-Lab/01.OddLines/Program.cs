using System;
using System.IO;

namespace _01.OddLines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "01.Odd Lines";
            string fileName = "input.txt";
            string filePath = Path.Combine(path, fileName); // combining the name of the file with the path

            using (var reader = new StreamReader(filePath))
            {
                using (var writter = new StreamWriter("output.txt"))
                {
                    int cnt = 0;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        if (cnt % 2 == 0)
                        {
                            writter.WriteLine(line);
                        }
                        cnt++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
