namespace ExtractBytes
{
    using System;
    using System.IO;
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (FileStream image = new FileStream(binaryFilePath, FileMode.Open))
            {
                using (FileStream bytes = new FileStream(bytesFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[bytes.Length];
                    bytes.Read(buffer, 0, (int) bytes.Length);

                    byte[] imageBuffer = new byte[image.Length];
                    bytes.Read(imageBuffer, 0, (int)image.Length);

                    using (FileStream output = new FileStream(outputPath, FileMode.Create))
                    {
                        for (int i = 0; i < imageBuffer.Length; i++)
                        {
                            for (int j = 0; j < buffer.Length; j++)
                            {
                                if (imageBuffer[i] == buffer[j])
                                {
                                    output.Write(new byte[] { imageBuffer[i] });
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
