using System;
using System.IO;
using System.Collections.Generic;

// Implements address book operations
public class AddressBookUtilityImpl : IAddressBook, IAddressBookSystem
{
    // UC6: Multiple Address Books storage (using Dictionary)
    private Dictionary<string, AddressBook> addressBooks =
        new Dictionary<string, AddressBook>();

    private AddressBook currentAddressBook = null;

    // UC2 + UC7: Add new contact with duplicate check
    public void AddContact()
    {
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();

        // UC7: Duplicate check based on First Name
        if (currentAddressBook.Contacts.Exists(c => c.FirstName.Equals(firstName)))
        {
            Console.WriteLine("Duplicate entry! Contact with this name already exists.");
            return;
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

        currentAddressBook.Contacts.Add(contact);

        Console.WriteLine("Contact added successfully!");
    }

    // UC3: Edit contact using First Name + Phone Number
    public void EditContact()
    {
        Console.Write("\nEnter First Name of contact: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Phone Number of contact: ");
        string phoneNumber = Console.ReadLine();

        Address contact = currentAddressBook.Contacts
            .Find(c => c.FirstName.Equals(firstName) &&
                       c.PhoneNumber.Equals(phoneNumber));

        if (contact == null)
        {
            Console.WriteLine("X Contact not found!");
            return;
        }

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

        currentAddressBook.Contacts.Remove(contact);

        currentAddressBook.Contacts.Add(new Address(
            firstName, lastName, addressLine,
            city, state, zip, newPhone, email
        ));

        Console.WriteLine("Contact updated successfully!");
    }

    // UC4: Delete contact using First Name + Phone Number
    public void DeleteContact()
    {
        Console.Write("\nEnter First Name of contact: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Phone Number of contact: ");
        string phoneNumber = Console.ReadLine();

        Address contact = currentAddressBook.Contacts
            .Find(c => c.FirstName.Equals(firstName) &&
                       c.PhoneNumber.Equals(phoneNumber));

        if (contact != null)
        {
            currentAddressBook.Contacts.Remove(contact);
            Console.WriteLine("Contact deleted successfully!");
        }
        else
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
            AddContact();
            Console.Write("\nDo you want to add another contact? (y/n): ");
            choice = Convert.ToChar(Console.ReadLine().ToLower());
        } while (choice == 'y');
    }

    // UC6: Add new Address Book
    public void AddAddressBook()
    {
        Console.Write("Enter Address Book Name: ");
        string name = Console.ReadLine();

        if (addressBooks.ContainsKey(name))
        {
            Console.WriteLine("Address Book with this name already exists!");
            return;
        }

        AddressBook book = new AddressBook(name);
        addressBooks[name] = book;
        currentAddressBook = book;

        Console.WriteLine($"Address Book '{name}' created and selected.");
    }

    // UC6.1: Switch current Address Book
    public void SwitchAddressBook()
    {
        if (addressBooks.Count == 0)
        {
            Console.WriteLine("No Address Books available.");
            return;
        }

        Console.WriteLine("\nAvailable Address Books:");
        foreach (string name in addressBooks.Keys)
        {
            Console.WriteLine("- " + name);
        }

        Console.Write("\nEnter Address Book name to switch: ");
        string input = Console.ReadLine();

        if (addressBooks.ContainsKey(input))
        {
            currentAddressBook = addressBooks[input];
            Console.WriteLine($"Switched to Address Book: {input}");
        }
        else
        {
            Console.WriteLine("Address Book not found.");
        }
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
        Console.Write("Enter City or State: ");
        string value = Console.ReadLine();

        bool found = false;

        foreach (var book in addressBooks.Values)
        {
            foreach (var person in book.Contacts)
            {
                if (person.City.Equals(value) || person.State.Equals(value))
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
        foreach (var book in addressBooks.Values)
        {
            foreach (var person in book.Contacts)
            {
                Console.WriteLine($"{person.City} - {person.FirstName} ({book.Name})");
            }
        }
    }

    // UC10: Count persons by City or State across all Address Books
    public void CountPersonsByCityOrState()
    {
        Console.Write("Enter City or State: ");
        string value = Console.ReadLine();

        int count = 0;

        foreach (var book in addressBooks.Values)
        {
            count += book.Contacts.FindAll(
                p => p.City.Equals(value) || p.State.Equals(value)).Count;
        }

        Console.WriteLine($"Total persons in {value}: {count}");
    }

    // UC11: Sort contacts alphabetically by First Name
    public void SortContactsByName()
    {
        currentAddressBook.Contacts.Sort(
            (a, b) => a.FirstName.CompareTo(b.FirstName));

        Console.WriteLine("Contacts sorted alphabetically by name.");
    }

    // UC12: Sort contacts by City, State, or Zip
    public void SortContactsByCityStateOrZip()
    {
        Console.WriteLine("\nSort by:");
        Console.WriteLine("1. City");
        Console.WriteLine("2. State");
        Console.WriteLine("3. Zip");

        int choice = Convert.ToInt32(Console.ReadLine());

        currentAddressBook.Contacts.Sort((a, b) =>
        {
            if (choice == 1) return a.City.CompareTo(b.City);
            if (choice == 2) return a.State.CompareTo(b.State);
            return a.Zip.CompareTo(b.Zip);
        });

        Console.WriteLine("Contacts sorted successfully.");
    }

    // UC13: Write Address Book to file
    public void WriteAddressBookToFile()
    {
        string fileName = currentAddressBook.Name + ".txt";

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var a in currentAddressBook.Contacts)
            {
                writer.WriteLine(
                    $"{a.FirstName},{a.LastName},{a.AddressLine}," +
                    $"{a.City},{a.State},{a.Zip},{a.PhoneNumber},{a.Email}");
            }
        }

        Console.WriteLine($"Address Book saved to file: {fileName}");
    }

    // UC13: Read Address Book from file
    public void ReadAddressBookFromFile()
    {
        string fileName = currentAddressBook.Name + ".txt";

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        currentAddressBook.Contacts.Clear();

        foreach (string line in File.ReadAllLines(fileName))
        {
            string[] data = line.Split(',');

            currentAddressBook.Contacts.Add(new Address(
                data[0], data[1], data[2],
                data[3], data[4], data[5],
                data[6], data[7]
            ));
        }

        Console.WriteLine($"Address Book loaded from file: {fileName}");
    }

    // UC14: Write Address Book to CSV file
    public void WriteAddressBookToCSV()
    {
        string fileName = currentAddressBook.Name + ".csv";

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("FirstName,LastName,Address,City,State,Zip,Phone,Email");

            foreach (var a in currentAddressBook.Contacts)
            {
                writer.WriteLine(
                    $"{a.FirstName},{a.LastName},{a.AddressLine}," +
                    $"{a.City},{a.State},{a.Zip},{a.PhoneNumber},{a.Email}");
            }
        }

        Console.WriteLine($"Address Book exported to CSV file: {fileName}");
    }

    // UC14: Read Address Book from CSV file
    public void ReadAddressBookFromCSV()
    {
        string fileName = currentAddressBook.Name + ".csv";

        if (!File.Exists(fileName))
        {
            Console.WriteLine("CSV file does not exist.");
            return;
        }

        currentAddressBook.Contacts.Clear();

        bool isHeader = true;

        foreach (string line in File.ReadAllLines(fileName))
        {
            if (isHeader)
            {
                isHeader = false;
                continue;
            }

            string[] data = line.Split(',');

            currentAddressBook.Contacts.Add(new Address(
                data[0], data[1], data[2],
                data[3], data[4], data[5],
                data[6], data[7]
            ));
        }

        Console.WriteLine($"Address Book loaded from CSV file: {fileName}");
    }
}
