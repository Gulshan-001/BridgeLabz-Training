using System;

// Represents a single Address Book
public class AddressBook
{
    public string Name { get; private set; }

    public Address[] Contacts { get; private set; }
    public int ContactCount { get; set; }

    public AddressBook(string name)
    {
        Name = name;
        Contacts = new Address[100];
        ContactCount = 0;
    }
}
