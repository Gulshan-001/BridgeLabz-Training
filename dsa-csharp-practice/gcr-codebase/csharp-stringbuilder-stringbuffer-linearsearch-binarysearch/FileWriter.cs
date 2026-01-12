using System;
using System.IO;

class FileWriter
{
    static void Main()
    {
        string filePath = "C:\\Users\\gulsh\\Desktop\\SAMPLETEXTFILE.txt";

        Console.WriteLine("Enter text (type 'exit' to stop):");

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                writer.WriteLine(input);
            }
        }

        Console.WriteLine("User input written to file successfully.");
    }
}
