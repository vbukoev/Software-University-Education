using System;
using System.IO;

namespace _07FolderSize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            long bytes = RecurseDirectory("../../../"); 
        }

        private static void RecurseDirectory(string path)
        {
            Console.WriteLine(path);
            string[]  dirs = Directory.GetFiles(path);
            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
            }
            string[] files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
