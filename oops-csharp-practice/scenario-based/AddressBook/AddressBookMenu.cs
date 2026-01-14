using System;

public class AddressBookMenu
{
    private IAddressBook addressBook;

    public AddressBookMenu()
    {
        addressBook = new AddressBookUtilityImpl();
    }

    public void ShowMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\n===== ADDRESS BOOK SYSTEM =====");
            Console.WriteLine("1. Create Address Book");
            Console.WriteLine("2. Switch Address Book");
            Console.WriteLine("3. Add Contact");
            Console.WriteLine("4. Add Multiple Contacts");
            Console.WriteLine("5. Edit Contact");
            Console.WriteLine("6. Delete Contact");
            Console.WriteLine("0. Exit");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    addressBook.AddAddressBook();
                    break;
                case 2:
                    addressBook.SwitchAddressBook();
                    break;
                case 3:
                    addressBook.AddContact();
                    break;
                case 4:
                    addressBook.AddMultipleContacts();
                    break;
                case 5:
                    addressBook.EditContact();
                    break;
                case 6:
                    addressBook.DeleteContact();
                    break;
                case 0:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 0);
    }
}
