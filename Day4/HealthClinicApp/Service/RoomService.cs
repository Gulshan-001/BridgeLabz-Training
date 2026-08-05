using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Service;

public class RoomService
{
    DatabaseConnection db = new DatabaseConnection();

    // Add Room
    public void AddRoom()
    {
        using SqlConnection connection = db.GetConnection();

        Console.Write("Enter Room Number : ");
        string roomNumber = Console.ReadLine()!;

        Console.Write("Enter Floor Number : ");
        int floorNumber = Convert.ToInt32(Console.ReadLine());

        try
        {
            connection.Open();

            string query = @"INSERT INTO Room
                            (RoomNumber, FloorNumber)
                            VALUES
                            (@RoomNumber, @FloorNumber)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@RoomNumber", roomNumber);
            cmd.Parameters.AddWithValue("@FloorNumber", floorNumber);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("\nRoom Added Successfully.");
            else
                Console.WriteLine("\nFailed to Add Room.");
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

    // View Rooms
    public void ViewRooms()
    {
        using SqlConnection connection = db.GetConnection();

        try
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Room", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n========== ROOMS ==========\n");

            while (reader.Read())
            {
                Console.WriteLine($"Room ID      : {reader["RoomID"]}");
                Console.WriteLine($"Room Number  : {reader["RoomNumber"]}");
                Console.WriteLine($"Floor Number : {reader["FloorNumber"]}");
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

    // Update Room
    public void UpdateRoom()
    {
        using SqlConnection connection = db.GetConnection();

        Console.Write("Enter Room ID : ");
        int roomId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter New Room Number : ");
        string roomNumber = Console.ReadLine()!;

        Console.Write("Enter New Floor Number : ");
        int floorNumber = Convert.ToInt32(Console.ReadLine());

        try
        {
            connection.Open();

            string query = @"UPDATE Room
                            SET RoomNumber=@RoomNumber,
                                FloorNumber=@FloorNumber
                            WHERE RoomID=@RoomID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@RoomID", roomId);
            cmd.Parameters.AddWithValue("@RoomNumber", roomNumber);
            cmd.Parameters.AddWithValue("@FloorNumber", floorNumber);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("\nRoom Updated Successfully.");
            else
                Console.WriteLine("\nRoom ID Not Found.");
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

    // Delete Room
    public void DeleteRoom()
    {
        using SqlConnection connection = db.GetConnection();

        Console.Write("Enter Room ID : ");
        int roomId = Convert.ToInt32(Console.ReadLine());

        try
        {
            connection.Open();

            string query = "DELETE FROM Room WHERE RoomID=@RoomID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@RoomID", roomId);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("\nRoom Deleted Successfully.");
            else
                Console.WriteLine("\nRoom ID Not Found.");
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