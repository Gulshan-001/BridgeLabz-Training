using System;

// Implements address book operations
public class AddressBookUtilityImpl : IAddressBook
{
    private Address[] contacts = new Address[100];
    private int contactCount = 0;

    // UC2: Add new contact
    public void AddContact()
    {
        if (contactCount >= 100)
        {
            Console.WriteLine("Address Book is full!");
            return;
        }

        Console.Write("First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Address: ");
        string addressLine = Console.ReadLine();

        Console.Write("City: ");
        string city = Console.ReadLine();

        Console.Write("State: ");
        string state = Console.ReadLine();

        Console.Write("Zip: ");
        string zip = Console.ReadLine();

        Console.Write("Phone Number: ");
        string phone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Address contact = new Address(
            firstName, lastName, addressLine,
            city, state, zip, phone, email
        );

        contacts[contactCount] = contact;
        contactCount++;

        Console.WriteLine("Contact added successfully!");
    }
}
