namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream source = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (FileStream partOne = new FileStream(partOneFilePath, FileMode.Create))
                {
                    int odd = sourceFilePath.Length % 2 == 1 ? 1 : 0;
                    byte[] buffer = new byte[source.Length / 2 + odd];
                    source.Read(buffer);
                    partOne.Write(buffer);
                }
                using (FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Create))
                {                    
                    byte[] buffer = new byte[source.Length / 2 ];
                    source.Read(buffer);
                    partTwo.Write(buffer);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream joined = new FileStream(joinedFilePath, FileMode.Open))
            {
                using (FileStream partOne = new FileStream(partOneFilePath, FileMode.Create))
                {                    
                    byte[] buffer = new byte[partOne.Length / 2 ];
                    partOne.Read(buffer);
                    partOne.Write(buffer);
                }
                using (FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[partTwo.Length / 2];
                    partTwo.Read(buffer);
                    joined.Write(buffer);
                }
            }
        }
    }
}