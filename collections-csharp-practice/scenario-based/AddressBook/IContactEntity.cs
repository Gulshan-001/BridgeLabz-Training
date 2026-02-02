// Generic contact entity interface
public interface IContactEntity
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string AddressLine { get; set; }
    string City { get; set; }
    string State { get; set; }
    string Zip { get; set; }
    string PhoneNumber { get; set; }
    string Email { get; set; }
}
