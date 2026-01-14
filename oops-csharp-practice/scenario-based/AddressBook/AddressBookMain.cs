using System;

// Starts the Address Book application flow
public class AddressBookMain
{
    public void Start()
    {
        AddressBookMenu menu = new AddressBookMenu();
        menu.ShowMenu();
    }
}
