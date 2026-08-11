using Microsoft.Data.SqlClient;
using ContactsH2App.Models;

namespace ContactsH2App.Repository;

public class ContactRepository : IContactRepository
{
    private readonly string _connectionString;

    public ContactRepository(IConfiguration configuration)
    {
        _connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string not found.");
    }

    public List<Contact> GetAll()
    {
        var contacts = new List<Contact>();

        using var connection = new SqlConnection(_connectionString);

        connection.Open();

        var query = "SELECT Id, Name, Email, Phone FROM Contacts";

        using var command = new SqlCommand(query, connection);

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            contacts.Add(new Contact
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString()!,
                Email = reader["Email"].ToString()!,
                Phone = reader["Phone"].ToString()!
            });
        }

        return contacts;
    }


    public Contact? GetById(int id)
    {
        using var connection = new SqlConnection(_connectionString);

        connection.Open();

        var query = """
            SELECT Id, Name, Email, Phone
            FROM Contacts
            WHERE Id = @Id
            """;

        using var command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);

        using var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }

        return new Contact
        {
            Id = Convert.ToInt32(reader["Id"]),
            Name = reader["Name"].ToString()!,
            Email = reader["Email"].ToString()!,
            Phone = reader["Phone"].ToString()!
        };
    }


    public Contact Add(Contact contact)
    {
        using var connection = new SqlConnection(_connectionString);

        connection.Open();

        var query = """
            INSERT INTO Contacts (Name, Email, Phone)
            OUTPUT INSERTED.Id
            VALUES (@Name, @Email, @Phone)
            """;

        using var command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Name", contact.Name);
        command.Parameters.AddWithValue("@Email", contact.Email);
        command.Parameters.AddWithValue("@Phone", contact.Phone);

        var id = Convert.ToInt32(command.ExecuteScalar());

        contact.Id = id;

        return contact;
    }


    public bool Update(int id, Contact contact)
    {
        using var connection = new SqlConnection(_connectionString);

        connection.Open();

        var query = """
            UPDATE Contacts
            SET Name = @Name,
                Email = @Email,
                Phone = @Phone
            WHERE Id = @Id
            """;

        using var command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);
        command.Parameters.AddWithValue("@Name", contact.Name);
        command.Parameters.AddWithValue("@Email", contact.Email);
        command.Parameters.AddWithValue("@Phone", contact.Phone);

        var rowsAffected = command.ExecuteNonQuery();

        return rowsAffected > 0;
    }


    public bool Delete(int id)
    {
        using var connection = new SqlConnection(_connectionString);

        connection.Open();

        var query = """
            DELETE FROM Contacts
            WHERE Id = @Id
            """;

        using var command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);

        var rowsAffected = command.ExecuteNonQuery();

        return rowsAffected > 0;
    }
}