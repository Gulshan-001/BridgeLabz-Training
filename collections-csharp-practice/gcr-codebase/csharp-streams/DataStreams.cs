using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "student.dat";

        // ---------- WRITE DATA ----------
        using (FileStream fsWrite = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fsWrite))
        {
            writer.Write(101);           // Roll Number
            writer.Write("Gulshan");     // Name
            writer.Write(8.75);          // GPA
        }

        Console.WriteLine("Student data written successfully.\n");

        // ---------- READ DATA ----------
        using (FileStream fsRead = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fsRead))
        {
            int rollNo = reader.ReadInt32();
            string name = reader.ReadString();
            double gpa = reader.ReadDouble();

            Console.WriteLine("Student Data Retrieved:");
            Console.WriteLine($"Roll No : {rollNo}");
            Console.WriteLine($"Name    : {name}");
            Console.WriteLine($"GPA     : {gpa}");
        }
    }
}
