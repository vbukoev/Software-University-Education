using System.IO;
using System.Text;
using SoftUniLogger.IO.Interfaces;

namespace SoftUniLogger.IO
{
    public class FileWriter : IFileWriter
    {
        public string FilePath { get; set; }

        public FileWriter(string filePath)
        {
            this.FilePath = filePath;
        }
        public void WriteContent(string content, string fileName)
        {
            string outputPath = Path.Combine(this.FilePath, fileName);
            File.WriteAllText(outputPath, content, Encoding.UTF8);
        }
    }
      
}

