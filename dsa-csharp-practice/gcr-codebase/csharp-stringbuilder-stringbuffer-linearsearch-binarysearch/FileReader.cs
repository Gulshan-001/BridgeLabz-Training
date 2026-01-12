using System;
using System.IO;

class FileReader
{
    static void Main()
    {
        string filePath = "C:\\Users\\gulsh\\Desktop\\SAMPLETEXTFILE.txt"; // Path to your text file

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
