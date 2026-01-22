using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "UserInfo.txt";

        // StreamReader for console input
        using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
        {
            Console.Write("Enter your name: ");
            string name = reader.ReadLine();

            Console.Write("Enter your age: ");
            string age = reader.ReadLine();

            Console.Write("Enter your favorite programming language: ");
            string language = reader.ReadLine();

            // StreamWriter for file output
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("User Information");
                writer.WriteLine("----------------");
                writer.WriteLine("Name: " + name);
                writer.WriteLine("Age: " + age);
                writer.WriteLine("Favorite Language: " + language);
            }
        }

        Console.WriteLine("\nUser information saved successfully.");
    }
}
