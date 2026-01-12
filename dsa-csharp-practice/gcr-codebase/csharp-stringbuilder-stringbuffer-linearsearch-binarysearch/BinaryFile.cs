using System;
using System.IO;
using System.Text;

class BinaryFile
{
    static void Main()
    {
        string filePath = "C:\\Users\\gulsh\\Desktop\\SAMPLEBINARYFILE.txt"; // Text file path

        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
        {
            int character;

            while ((character = reader.Read()) != -1)
            {
                Console.Write((char)character);
            }
        }
    }
}
