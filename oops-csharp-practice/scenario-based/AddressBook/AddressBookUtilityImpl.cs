using System;

// Implements address book operations
public class AddressBookUtilityImpl : IAddressBook, IAddressBookSystem
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

    // UC6.2: Check if an Address Book is selected
    public bool IsAddressBookSelected()
    {
        return currentAddressBook != null;
    }

    // UC6.3: Get current Address Book name
    public string GetCurrentAddressBookName()
    {
        return currentAddressBook.Name;
    }

    // UC8: Search person by City or State across multiple Address Books
public void SearchPersonByCityOrState()
{
    if (addressBookCount == 0)
    {
        Console.WriteLine("No Address Books available.");
        return;
    }

    Console.WriteLine("\nSearch by:");
    Console.WriteLine("1. City");
    Console.WriteLine("2. State");
    Console.Write("Enter choice: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter value to search: ");
    string searchValue = Console.ReadLine();

    bool found = false;

    Console.WriteLine("\n--- Search Results ---");

    for (int i = 0; i < addressBookCount; i++)
    {
        AddressBook book = addressBooks[i];

        for (int j = 0; j < book.ContactCount; j++)
        {
            Address person = book.Contacts[j];

            if ((choice == 1 && person.City.Equals(searchValue)) ||
                (choice == 2 && person.State.Equals(searchValue)))
            {
                Console.WriteLine(
                    $"[AddressBook: {book.Name}] " +
                    $"{person.FirstName} {person.LastName}, " +
                    $"{person.City}, {person.State}, {person.PhoneNumber}"
                );

                found = true;
            }
        }
    }

    if (!found)
    {
        Console.WriteLine("No persons found for given City/State.");
    }
}
    // UC9: View persons by City or State across multiple Address Books
    public void ViewPersonsByCityOrState()
    {
        for (int i = 0; i < addressBookCount; i++)
        {
            AddressBook b = addressBooks[i];
            for (int j = 0; j < b.ContactCount; j++)
            {
                Address a = b.Contacts[j];
                Console.WriteLine($"{a.City} - {a.FirstName} ({b.Name})");
            }
        }
    }
    // UC10: Count persons by City or State across all Address Books
    public void CountPersonsByCityOrState()
    {
    if (addressBookCount == 0)
    {
        Console.WriteLine("No Address Books available.");
        return;
    }

    Console.WriteLine("\nCount by:");
    Console.WriteLine("1. City");
    Console.WriteLine("2. State");
    Console.Write("Enter choice: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter City/State name: ");
    string value = Console.ReadLine();

    int count = 0;

    for (int i = 0; i < addressBookCount; i++)
    {
        AddressBook book = addressBooks[i];

        for (int j = 0; j < book.ContactCount; j++)
        {
            Address person = book.Contacts[j];

            if ((choice == 1 && person.City.Equals(value)) ||
                (choice == 2 && person.State.Equals(value)))
            {
                count++;
            }
        }
    }

    Console.WriteLine($"\nTotal persons in {value}: {count}");
}
    // UC11: Sort contacts alphabetically by First Name
    public void SortContactsByName()
    {
    if (currentAddressBook == null)
    {
        Console.WriteLine("No Address Book selected.");
        return;
    }

    int n = currentAddressBook.ContactCount;

    if (n == 0)
    {
        Console.WriteLine("No contacts to sort.");
        return;
    }

    // Simple Bubble Sort (easy to understand)
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (string.Compare(
                    currentAddressBook.Contacts[j].FirstName,
                    currentAddressBook.Contacts[j + 1].FirstName) > 0)
            {
                // swap
                Address temp = currentAddressBook.Contacts[j];
                currentAddressBook.Contacts[j] = currentAddressBook.Contacts[j + 1];
                currentAddressBook.Contacts[j + 1] = temp;
            }
        }
    }

    Console.WriteLine("\nContacts sorted alphabetically by name:\n");

    // Display sorted contacts
    for (int i = 0; i < n; i++)
    {
        Address a = currentAddressBook.Contacts[i];
        Console.WriteLine($"{a.FirstName} {a.LastName} - {a.PhoneNumber}");
    }
}
}
