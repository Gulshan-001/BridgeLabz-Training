using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourcePath = "source.txt";
        string destinationPath = "destination.txt";

        // Check if source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        // Open source file for reading
        using (FileStream sourceStream = new FileStream(
            sourcePath, FileMode.Open, FileAccess.Read))
        {
            // Create destination file for writing
            using (FileStream destinationStream = new FileStream(
                destinationPath, FileMode.Create, FileAccess.Write))
            {
                int data;

                // Read byte by byte and write to destination
                while ((data = sourceStream.ReadByte()) != -1)
                {
                    destinationStream.WriteByte((byte)data);
                }
            }
        }

        Console.WriteLine("File copied successfully.");
    }
}
