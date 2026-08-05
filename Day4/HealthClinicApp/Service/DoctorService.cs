using System.Data;
using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Service;

public class DoctorService
{
    DatabaseConnection db = new DatabaseConnection();

    // Add Doctor
    public void AddDoctor()
    {
        using SqlConnection connection = db.GetConnection();

        Console.Write("Enter First Name : ");
        string firstName = Console.ReadLine()!;

        Console.Write("Enter Last Name : ");
        string lastName = Console.ReadLine()!;

        Console.Write("Enter Specialization : ");
        string specialization = Console.ReadLine()!;

        Console.Write("Enter Phone : ");
        string phone = Console.ReadLine()!;

        try
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("sp_AddDoctor", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Specialization", specialization);
            cmd.Parameters.AddWithValue("@Phone", phone);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("\nDoctor Added Successfully.");
            else
                Console.WriteLine("\nFailed to Add Doctor.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError : {ex.Message}");
        }
        finally
        {
            connection.Close();
        }
    }

    // View Doctors
    public void ViewDoctors()
    {
        using SqlConnection connection = db.GetConnection();

        try
        {
            connection.Open();

            string query = "SELECT * FROM Doctor";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n========== DOCTORS ==========\n");

            while (reader.Read())
            {
                Console.WriteLine($"Doctor ID      : {reader["DoctorID"]}");
                Console.WriteLine($"First Name     : {reader["FirstName"]}");
                Console.WriteLine($"Last Name      : {reader["LastName"]}");
                Console.WriteLine($"Specialization : {reader["Specialization"]}");
                Console.WriteLine($"Phone          : {reader["Phone"]}");
                Console.WriteLine("-----------------------------------");
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError : {ex.Message}");
        }
        finally
        {
            connection.Close();
        }
    }

    // Update Doctor
    public void UpdateDoctor()
    {
        using SqlConnection connection = db.GetConnection();

        Console.Write("Enter Doctor ID : ");
        int doctorId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter New First Name : ");
        string firstName = Console.ReadLine()!;

        Console.Write("Enter New Last Name : ");
        string lastName = Console.ReadLine()!;

        Console.Write("Enter New Specialization : ");
        string specialization = Console.ReadLine()!;

        Console.Write("Enter New Phone : ");
        string phone = Console.ReadLine()!;

        try
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("sp_UpdateDoctor", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DoctorID", doctorId);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Specialization", specialization);
            cmd.Parameters.AddWithValue("@Phone", phone);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("\nDoctor Updated Successfully.");
            else
                Console.WriteLine("\nDoctor ID Not Found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError : {ex.Message}");
        }
        finally
        {
            connection.Close();
        }
    }

    // Delete Doctor
    public void DeleteDoctor()
    {
        using SqlConnection connection = db.GetConnection();

        Console.Write("Enter Doctor ID to Delete : ");
        int doctorId = Convert.ToInt32(Console.ReadLine());

        try
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("sp_DeleteDoctor", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DoctorID", doctorId);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("\nDoctor Deleted Successfully.");
            else
                Console.WriteLine("\nDoctor ID Not Found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError : {ex.Message}");
        }
        finally
        {
            connection.Close();
        }
    }
}