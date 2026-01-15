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

            switch (ch)
            {
                case 0:
                    return;

                case 1:
                    system.AddAddressBook();
                    break;

                case 2:
                    system.SwitchAddressBook();
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            if (!system.IsAddressBookSelected())
                continue;

            while (true)
            {
                Console.WriteLine($"\n--- Address Book: {system.GetCurrentAddressBookName()} ---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Add Multiple Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Search by City/State");
                Console.WriteLine("6. View by City/State");
                Console.WriteLine("7. Count Persons by City or State");
                Console.WriteLine("0. Back");

                int op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        break;

                    case 1:
                        contacts.AddContact();
                        break;

                    case 2:
                        contacts.AddMultipleContacts();
                        break;

                    case 3:
                        contacts.EditContact();
                        break;

                    case 4:
                        contacts.DeleteContact();
                        break;

                    case 5:
                        contacts.SearchPersonByCityOrState();
                        break;

                    case 6:
                        contacts.ViewPersonsByCityOrState();
                        break;

                    case 7:
                        contacts.CountPersonsByCityOrState();
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                if (op == 0)
                    break;
            }
        }
    }
}
