// Represents a Contact (Person)
public class Address : IContactEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AddressLine { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Address(string firstName, string lastName, string addressLine,
                   string city, string state, string zip,
                   string phoneNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        AddressLine = addressLine;
        City = city;
        State = state;
        Zip = zip;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}
