using System.Collections.Generic;
//Resresents ONE Address Book
public class AddressBook
{
    public string Name { get; private set; }
    public List<Address> Contacts { get; private set; }

    public AddressBook(string name)
    {
        Name = name;
        Contacts = new List<Address>();
    }
}
