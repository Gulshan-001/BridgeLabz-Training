using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string file1 = "students1.csv";
        string file2 = "students2.csv";
        string outputFile = "students_merged.csv";

        Dictionary<string, string[]> studentData = new Dictionary<string, string[]>();

        // Read students1.csv (ID, Name, Age)
        string[] lines1 = File.ReadAllLines(file1);
        for (int i = 1; i < lines1.Length; i++) // skip header
        {
            string[] data = lines1[i].Split(',');
            studentData[data[0]] = new string[] { data[1], data[2] };
        }

        // Read students2.csv and merge
        string[] lines2 = File.ReadAllLines(file2);

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            // Write header
            writer.WriteLine("ID,Name,Age,Marks,Grade");

            for (int i = 1; i < lines2.Length; i++) // skip header
            {
                string[] data = lines2[i].Split(',');
                string id = data[0];

                if (studentData.ContainsKey(id))
                {
                    string name = studentData[id][0];
                    string age = studentData[id][1];
                    string marks = data[1];
                    string grade = data[2];

                    writer.WriteLine($"{id},{name},{age},{marks},{grade}");
                }
            }
        }

        Console.WriteLine("CSV files merged successfully.");
    }
}
