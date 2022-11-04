namespace Telephony.IO.Interfaces
{
    using System;
    using System.IO;


    public class FileReader : IReader
    {
        private string filePath;
        private string[] fileAllLines;

        public FileReader(string filePath)
        {
            FilePath = filePath;
            fileAllLines = File.ReadAllLines(filePath);
            RowNumber = 0;
        }
        public string FilePath
        {
            get
            {
                return filePath;
            }
            private set
            {
                if (!Directory.Exists(filePath))
                {
                    throw new ArgumentException("Invalid file path!");
                }
                filePath = value;
            }
        }
        public int RowNumber { get; private set; }
        public string ReadLine()
        => this.fileAllLines[RowNumber++];
    }
}
