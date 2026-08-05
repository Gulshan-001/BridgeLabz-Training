using System.Data;
using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Service;

public class PatientService
{
    DatabaseConnection db = new DatabaseConnection();

    // Add Patient
    public void AddPatient()
    {
        using SqlConnection connection = db.GetConnection();

        Console.Write("Enter First Name : ");
        string firstName = Console.ReadLine()!;

        Console.Write("Enter Last Name : ");
        string lastName = Console.ReadLine()!;

        Console.Write("Enter Date of Birth (yyyy-mm-dd) : ");
        DateTime dob = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Enter Gender (M/F/O) : ");
        string gender = Console.ReadLine()!;

        Console.Write("Enter Phone : ");
        string phone = Console.ReadLine()!;

        Console.Write("Enter Address : ");
        string address = Console.ReadLine()!;

        try
        {
            connection.Open();

            string query = @"INSERT INTO Patient
                            (FirstName, LastName, DateOfBirth, Gender, Phone, Address)
                            VALUES
                            (@FirstName, @LastName, @DOB, @Gender, @Phone, @Address)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@DOB", dob);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Address", address);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("\nPatient Added Successfully.");
            else
                Console.WriteLine("\nFailed to Add Patient.");
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

    // View Patients (Disconnected Architecture)
    public void ViewPatients()
    {
        using SqlConnection connection = db.GetConnection();

        try
        {
            string query = "SELECT * FROM Patient";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet, "Patient");

            Console.WriteLine("\n========== PATIENTS ==========\n");

            foreach (DataRow row in dataSet.Tables["Patient"]!.Rows)
            {
                Console.WriteLine($"Patient ID   : {row["PatientID"]}");
                Console.WriteLine($"Name         : {row["FirstName"]} {row["LastName"]}");
                Console.WriteLine($"DOB          : {Convert.ToDateTime(row["DateOfBirth"]).ToShortDateString()}");
                Console.WriteLine($"Gender       : {row["Gender"]}");
                Console.WriteLine($"Phone        : {row["Phone"]}");
                Console.WriteLine($"Address      : {row["Address"]}");
                Console.WriteLine("--------------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError : {ex.Message}");
        }
    }

    // Update Patient
    public void UpdatePatient()
    {
        using SqlConnection connection = db.GetConnection();

        Console.Write("Enter Patient ID : ");
        int patientId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter New First Name : ");
        string firstName = Console.ReadLine()!;

        Console.Write("Enter New Last Name : ");
        string lastName = Console.ReadLine()!;

        Console.Write("Enter New Date of Birth (yyyy-mm-dd) : ");
        DateTime dob = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Enter New Gender : ");
        string gender = Console.ReadLine()!;

        Console.Write("Enter New Phone : ");
        string phone = Console.ReadLine()!;

        Console.Write("Enter New Address : ");
        string address = Console.ReadLine()!;

        try
        {
            connection.Open();

            string query = @"UPDATE Patient
                             SET FirstName = @FirstName,
                                 LastName = @LastName,
                                 DateOfBirth = @DOB,
                                 Gender = @Gender,
                                 Phone = @Phone,
                                 Address = @Address
                             WHERE PatientID = @PatientID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PatientID", patientId);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@DOB", dob);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Address", address);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("\nPatient Updated Successfully.");
            else
                Console.WriteLine("\nPatient ID Not Found.");
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

    // Delete Patient
    public void DeletePatient()
    {
        using SqlConnection connection = db.GetConnection();

        Console.Write("Enter Patient ID : ");
        int patientId = Convert.ToInt32(Console.ReadLine());

        try
        {
            connection.Open();

            string query = "DELETE FROM Patient WHERE PatientID = @PatientID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PatientID", patientId);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("\nPatient Deleted Successfully.");
            else
                Console.WriteLine("\nPatient ID Not Found.");
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