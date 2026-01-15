using System;

public class AddressBookMenu
{
    private IAddressBookSystem system;
    private IAddressBook contacts;

    public AddressBookMenu()
    {
        AddressBookUtilityImpl impl = new AddressBookUtilityImpl();
        system = impl;
        contacts = impl;
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\n=== ADDRESS BOOK SYSTEM ===");
            Console.WriteLine("1. Create Address Book");
            Console.WriteLine("2. Switch Address Book");
            Console.WriteLine("0. Exit");

            int ch = Convert.ToInt32(Console.ReadLine());
            if (ch == 0) break;
            if (ch == 1) system.AddAddressBook();
            if (ch == 2) system.SwitchAddressBook();

            if (!system.IsAddressBookSelected()) continue;

            while (true)
            {
                Console.WriteLine($"\n--- Address Book: {system.GetCurrentAddressBookName()} ---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Add Multiple Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Search by City/State");
                Console.WriteLine("0. Back");

                int op = Convert.ToInt32(Console.ReadLine());
                if (op == 0) break;

                if (op == 1) contacts.AddContact();
                if (op == 2) contacts.AddMultipleContacts();
                if (op == 3) contacts.EditContact();
                if (op == 4) contacts.DeleteContact();
                if (op == 5) contacts.SearchPersonByCityOrState();
            }
        }
    }
}
