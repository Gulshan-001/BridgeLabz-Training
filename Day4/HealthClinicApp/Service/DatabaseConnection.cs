using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Service;

public class DatabaseConnection
{
    private readonly string connectionString =
        @"Server=localhost\SQLEXPRESS;Database=HospitalDB;Trusted_Connection=True;TrustServerCertificate=True";

    public SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}