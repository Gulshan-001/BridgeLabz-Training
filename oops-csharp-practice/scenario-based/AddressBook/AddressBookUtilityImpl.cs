using System;

// Implements address book operations
public class AddressBookUtilityImpl : IAddressBook
{
    // UC6: Multiple Address Books storage
    private AddressBook[] addressBooks = new AddressBook[10];
    private int addressBookCount = 0;
    private AddressBook currentAddressBook = null;

    // Existing single-address-book storage (kept as-is)
    private Address[] contacts = new Address[100];
    private int contactCount = 0;

    // UC2 + UC7: Add new contact with duplicate check
    public void AddContact()
    {
        if (contactCount >= 100)
        {
            Console.WriteLine("Address Book is full!");
            return;
        }

        Console.Write("First Name: ");
        string firstName = Console.ReadLine();

        // UC7: Duplicate check based on First Name
        for (int i = 0; i < contactCount; i++)
        {
            if (contacts[i].FirstName.Equals(firstName))
            {
                Console.WriteLine("Duplicate entry! Contact with this name already exists.");
                return;
            }
        }

        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Address: ");
        string addressLine = Console.ReadLine();

        Console.Write("City: ");
        string city = Console.ReadLine();

        Console.Write("State: ");
        string state = Console.ReadLine();

        Console.Write("Zip: ");
        string zip = Console.ReadLine();

        Console.Write("Phone Number: ");
        string phone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Address contact = new Address(
            firstName, lastName, addressLine,
            city, state, zip, phone, email
        );

        contacts[contactCount] = contact;
        contactCount++;

        Console.WriteLine("Contact added successfully!");
    }

    // UC3: Edit contact using First Name + Phone Number
    public void EditContact()
    {
        Console.Write("\nEnter First Name of contact: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Phone Number of contact: ");
        string phoneNumber = Console.ReadLine();

        bool found = false;

        for (int i = 0; i < contactCount; i++)
        {
            if (contacts[i].FirstName.Equals(firstName)
                && contacts[i].PhoneNumber.Equals(phoneNumber))
            {
                Console.WriteLine("\nContact found. Enter new details:");

                Console.Write("New Last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("New Address: ");
                string addressLine = Console.ReadLine();

                Console.Write("New City: ");
                string city = Console.ReadLine();

                Console.Write("New State: ");
                string state = Console.ReadLine();

                Console.Write("New Zip: ");
                string zip = Console.ReadLine();

                Console.Write("New Phone Number: ");
                string newPhone = Console.ReadLine();

                Console.Write("New Email: ");
                string email = Console.ReadLine();

                // Replace old contact with updated one
                contacts[i] = new Address(
                    firstName, lastName, addressLine,
                    city, state, zip, newPhone, email
                );

                Console.WriteLine("Contact updated successfully!");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("X Contact not found!");
        }
    }

    // UC4: Delete contact using First Name + Phone Number
    public void DeleteContact()
    {
        Console.Write("\nEnter First Name of contact: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Phone Number of contact: ");
        string phoneNumber = Console.ReadLine();

        bool found = false;

        for (int i = 0; i < contactCount; i++)
        {
            if (contacts[i].FirstName.Equals(firstName)
                && contacts[i].PhoneNumber.Equals(phoneNumber))
            {
                // Shift elements to left to fill the gap
                for (int j = i; j < contactCount - 1; j++)
                {
                    contacts[j] = contacts[j + 1];
                }

                contacts[contactCount - 1] = null;
                contactCount--;

                Console.WriteLine("Contact deleted successfully!");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Contact not found!");
        }
    }

    // UC5: Add multiple contacts one by one
    public void AddMultipleContacts()
    {
        char choice;

        do
        {
            AddContact(); // reuse UC2 logic (duplicate check applies)

            Console.Write("\nDo you want to add another contact? (y/n): ");
            choice = Convert.ToChar(Console.ReadLine().ToLower());

        } while (choice == 'y');
    }

    // UC6: Add new Address Book
    public void AddAddressBook()
    {
        if (addressBookCount >= 10)
        {
            Console.WriteLine("Cannot add more Address Books.");
            return;
        }

        Console.Write("Enter Address Book Name: ");
        string name = Console.ReadLine();

        // Check for unique name
        for (int i = 0; i < addressBookCount; i++)
        {
            if (addressBooks[i].Name.Equals(name))
            {
                Console.WriteLine("Address Book with this name already exists!");
                return;
            }
        }

        AddressBook book = new AddressBook(name);
        addressBooks[addressBookCount++] = book;
        currentAddressBook = book;

        Console.WriteLine($"Address Book '{name}' created and selected.");
    }

    // UC6.1: Switch current Address Book
    public void SwitchAddressBook()
    {
        if (addressBookCount == 0)
        {
            Console.WriteLine("No Address Books available.");
            return;
        }

        Console.WriteLine("\nAvailable Address Books:");
        for (int i = 0; i < addressBookCount; i++)
        {
            Console.WriteLine("- " + addressBooks[i].Name);
        }

        Console.Write("\nEnter Address Book name to switch: ");
        string name = Console.ReadLine();

        for (int i = 0; i < addressBookCount; i++)
        {
            if (addressBooks[i].Name.Equals(name))
            {
                currentAddressBook = addressBooks[i];
                Console.WriteLine($"Switched to Address Book: {name}");
                return;
            }
        }

        Console.WriteLine("Address Book not found.");
    }
}
