namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (var streamReader = new FileStream(inputFilePath, FileMode.Open))
            {
                using (var streamWriter = new FileStream(outputFilePath, FileMode.Create))
                {
                    while (true)
                    {
                        var buffer = new byte[4096];
                        int readSize = streamReader.Read(buffer, 0, buffer.Length);
                        if (readSize == 0)
                        {
                            break;
                        }
                        streamWriter.Write(buffer, 0, readSize);
                    }
                }
            }
        }
    }
}
