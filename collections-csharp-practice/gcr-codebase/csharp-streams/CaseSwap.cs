using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string sourceFile = "input.txt";
        string destinationFile = "output.txt";

        if (!File.Exists(sourceFile))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        // Explicit encoding to avoid character issues
        Encoding encoding = Encoding.UTF8;

        using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
        using (BufferedStream bufferedSource = new BufferedStream(sourceStream))
        using (StreamReader reader = new StreamReader(bufferedSource, encoding))
        using (FileStream destStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
        using (BufferedStream bufferedDest = new BufferedStream(destStream))
        using (StreamWriter writer = new StreamWriter(bufferedDest, encoding))
        {
            string line;

            // Read line by line, convert to lowercase, and write
            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine(line.ToLower());
            }
        }

        Console.WriteLine("File converted to lowercase successfully.");
    }
}
