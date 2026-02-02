using System.Collections.Generic;

// Represents a single Address Book
public class AddressBook<T> where T : IContactEntity
{
    public string Name { get; private set; }
    public List<T> Contacts { get; private set; }

    public AddressBook(string name)
    {
        Name = name;
        Contacts = new List<T>();
    }
}
