using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "employees.csv";

        string[] records =
        {
            "ID,Name,Department,Salary",
            "1,Alice,HR,50000",
            "2,Bob,IT,65000",
            "3,Charlie,Finance,60000",
            "4,Diana,Marketing,55000",
            "5,Evan,Operations,58000"
        };

        File.WriteAllLines(filePath, records);

        Console.WriteLine("Employee data written to CSV file successfully.");
    }
}
