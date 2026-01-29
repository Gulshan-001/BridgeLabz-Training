using System;
using System.Data.SqlClient;
using System.IO;

class Program
{
    static void Main()
    {
        string connectionString =
            "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;";

        string outputFile = "employees_report.csv";

        string query =
            "SELECT EmployeeId, Name, Department, Salary FROM Employees";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                connection.Open();

                // Write CSV header
                writer.WriteLine("Employee ID,Name,Department,Salary");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string line =
                            reader["EmployeeId"] + "," +
                            reader["Name"] + "," +
                            reader["Department"] + "," +
                            reader["Salary"];

                        writer.WriteLine(line);
                    }
                }
            }

            Console.WriteLine("CSV report generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error generating report: " + ex.Message);
        }
    }
}
