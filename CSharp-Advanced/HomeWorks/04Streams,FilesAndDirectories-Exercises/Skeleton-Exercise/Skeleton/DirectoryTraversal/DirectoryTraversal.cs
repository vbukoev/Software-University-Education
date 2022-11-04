namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            var dirInfo = new SortedDictionary<string, Dictionary<string, double>>();
            var directoryInfo = new DirectoryInfo(".");
            var allFiles = directoryInfo.GetFiles(inputFolderPath);
            foreach (var file in allFiles)
            {
                double size = (double)file.Length / 1024;
                string name = file.Name;
                string extension = file.Extension;
                if (!dirInfo.ContainsKey(extension))
                {
                    dirInfo.Add(extension, new Dictionary<string, double>());
                }
                if (!dirInfo[extension].ContainsKey(name))
                {
                    dirInfo[extension].Add(name, size);
                }
            }
            string report = "";
            foreach (var extension in dirInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)) 
            {
                 report += extension.Key + "\n";
                foreach (var file in extension.Value.OrderBy(x=>x.Value))
                {
                    report += $"--{file.Key} - {file.Value}kb\n";
                }
            }
            return report;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (var writer = new StreamWriter(path + reportFileName))
            {
                writer.Write(textContent);
            }
        }
    }
}
