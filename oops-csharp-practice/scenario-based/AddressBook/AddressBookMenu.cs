using System;

// Menu-driven class
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
            Console.WriteLine("\n===== ADDRESS BOOK MENU =====");
            Console.WriteLine("1. Add Contact");//UC2
            Console.WriteLine("2. Edit Contact");//UC3
            Console.WriteLine("3. Delete Contact");//UC4
            Console.WriteLine("4. Add Multiple Contacts");//UC5
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    addressBook.AddContact();
                    break;

                case 2:
                    addressBook.EditContact();
                    break;

                case 3:
                    addressBook.DeleteContact();
                    break;
                case 4:
                    addressBook.AddMultipleContacts();
                case 0:
                    Console.WriteLine("Exiting Address Book...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 0);
    }
}
