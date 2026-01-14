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
            Console.WriteLine("2. Add Contact");
            Console.WriteLine("3. Add Multiple Contacts");
            Console.WriteLine("4. Edit Contact");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    addressBook.AddAddressBook();
                    break;
                case 2:
                    addressBook.AddContact();
                    break;
                case 3:
                    addressBook.AddMultipleContacts();
                    break;
                case 4:
                    addressBook.EditContact();
                    break;
                case 5:
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
