using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Service;

public class AppointmentService
{
    DatabaseConnection db = new DatabaseConnection();

    // Add Appointment
    public void AddAppointment()
    {
        using SqlConnection connection = db.GetConnection();

        Console.Write("Enter Patient ID : ");
        int patientId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Doctor ID : ");
        int doctorId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Appointment Date (yyyy-mm-dd) : ");
        DateTime appointmentDate = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Enter Time (HH:mm:ss) : ");
        TimeSpan timeSlot = TimeSpan.Parse(Console.ReadLine()!);

        Console.Write("Enter Status : ");
        string status = Console.ReadLine()!;

        try
        {
            connection.Open();

            string query = @"INSERT INTO Appointment
                            (PatientID, DoctorID, AppointmentDate, TimeSlot, Status)
                            VALUES
                            (@PatientID, @DoctorID, @AppointmentDate, @TimeSlot, @Status)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PatientID", patientId);
            cmd.Parameters.AddWithValue("@DoctorID", doctorId);
            cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            cmd.Parameters.AddWithValue("@TimeSlot", timeSlot);
            cmd.Parameters.AddWithValue("@Status", status);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("\nAppointment Added Successfully.");
            else
                Console.WriteLine("\nFailed to Add Appointment.");
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

    // View Appointments
    public void ViewAppointments()
    {
        using SqlConnection connection = db.GetConnection();

        try
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Appointment", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n========== APPOINTMENTS ==========\n");

            while (reader.Read())
            {
                Console.WriteLine($"Appointment ID : {reader["AppointmentID"]}");
                Console.WriteLine($"Patient ID     : {reader["PatientID"]}");
                Console.WriteLine($"Doctor ID      : {reader["DoctorID"]}");
                Console.WriteLine($"Date           : {Convert.ToDateTime(reader["AppointmentDate"]).ToShortDateString()}");
                Console.WriteLine($"Time           : {reader["TimeSlot"]}");
                Console.WriteLine($"Status         : {reader["Status"]}");
                Console.WriteLine("----------------------------------------");
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

    // Update Appointment
    public void UpdateAppointment()
    {
        using SqlConnection connection = db.GetConnection();

        Console.Write("Enter Appointment ID : ");
        int appointmentId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Patient ID : ");
        int patientId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Doctor ID : ");
        int doctorId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Appointment Date (yyyy-mm-dd) : ");
        DateTime appointmentDate = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Enter Time (HH:mm:ss) : ");
        TimeSpan timeSlot = TimeSpan.Parse(Console.ReadLine()!);

        Console.Write("Enter Status : ");
        string status = Console.ReadLine()!;

        try
        {
            connection.Open();

            string query = @"UPDATE Appointment
                            SET PatientID = @PatientID,
                                DoctorID = @DoctorID,
                                AppointmentDate = @AppointmentDate,
                                TimeSlot = @TimeSlot,
                                Status = @Status
                            WHERE AppointmentID = @AppointmentID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
            cmd.Parameters.AddWithValue("@PatientID", patientId);
            cmd.Parameters.AddWithValue("@DoctorID", doctorId);
            cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            cmd.Parameters.AddWithValue("@TimeSlot", timeSlot);
            cmd.Parameters.AddWithValue("@Status", status);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("\nAppointment Updated Successfully.");
            else
                Console.WriteLine("\nAppointment ID Not Found.");
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

    // Delete Appointment
    public void DeleteAppointment()
    {
        using SqlConnection connection = db.GetConnection();

        Console.Write("Enter Appointment ID : ");
        int appointmentId = Convert.ToInt32(Console.ReadLine());

        try
        {
            connection.Open();

            string query = "DELETE FROM Appointment WHERE AppointmentID = @AppointmentID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("\nAppointment Deleted Successfully.");
            else
                Console.WriteLine("\nAppointment ID Not Found.");
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