using System;

// UC1: Ability to create a Contact in Address Book

public class Address
{
    // Read-only outside the class
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string AddressLine { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Zip { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }

    // Constructor sets all values at object creation
    public Address(
        string firstName,
        string lastName,
        string addressLine,
        string city,
        string state,
        string zip,
        string phoneNumber,
        string email)
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
