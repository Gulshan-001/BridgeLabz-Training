using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "info.txt";

        try
        {
            // using ensures the file is closed automatically
            using (StreamReader reader = new StreamReader(filePath))
            {
                string firstLine = reader.ReadLine();
                Console.WriteLine(firstLine);
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Error reading file");
        }
    }
}
