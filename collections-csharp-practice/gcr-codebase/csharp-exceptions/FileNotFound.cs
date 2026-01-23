using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "data.txt";

        try
        {
            // Try to read and display file contents
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine("File Contents:\n");
                Console.WriteLine(content);
            }
        }
        catch (IOException)
        {
            // Handles file not found and other IO-related issues
            Console.WriteLine("File not found");
        }
    }
}
