using System;

// UC1: Ability to create a Contact in Address Book
// This is ONLY a skeletal, encapsulated class
// No functionality yet – just data holding

public class Address
{
    // Private fields (encapsulation)
    private string firstName;
    private string lastName;
    private string address;
    private string city;
    private string state;
    private string zip;
    private string phoneNumber;
    private string email;

    // Public properties to access private fields
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string AddressLine
    {
        get { return address; }
        set { address = value; }
    }

    public string City
    {
        get { return city; }
        set { city = value; }
    }

    public string State
    {
        get { return state; }
        set { state = value; }
    }

    public string Zip
    {
        get { return zip; }
        set { zip = value; }
    }

    public string PhoneNumber
    {
        get { return phoneNumber; }
        set { phoneNumber = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
}
