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
            Console.WriteLine("1. Add Contact"); //UC2
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    addressBook.AddContact();
                    break;

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
