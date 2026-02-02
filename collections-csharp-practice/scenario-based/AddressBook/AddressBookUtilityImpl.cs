using System;
using System.IO;
using System.Collections.Generic;

// Implements address book operations
public class AddressBookUtilityImpl : IAddressBook, IAddressBookSystem
{
    // UC6: Multiple Address Books storage (Generic)
    private Dictionary<string, AddressBook<IContactEntity>> addressBooks =
        new Dictionary<string, AddressBook<IContactEntity>>();

    private AddressBook<IContactEntity> currentAddressBook = null;

    // UC2 + UC7: Add new contact with duplicate check
    public void AddContact()
    {
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();

        foreach (var c in currentAddressBook.Contacts)
        {
            if (c.FirstName.Equals(firstName))
            {
                Console.WriteLine("Duplicate entry! Contact already exists.");
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

        currentAddressBook.Contacts.Add(contact);
        Console.WriteLine("Contact added successfully!");
    }

    // UC3: Edit contact using First Name + Phone Number
    public void EditContact()
    {
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Phone Number: ");
        string phone = Console.ReadLine();

        foreach (var c in currentAddressBook.Contacts)
        {
            if (c.FirstName.Equals(firstName) && c.PhoneNumber.Equals(phone))
            {
                Console.Write("New City: ");
                c.City = Console.ReadLine();
                Console.Write("New State: ");
                c.State = Console.ReadLine();
                Console.WriteLine("Contact updated!");
                return;
            }
        }

        Console.WriteLine("Contact not found!");
    }

    // UC4: Delete contact
    public void DeleteContact()
    {
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Phone Number: ");
        string phone = Console.ReadLine();

        for (int i = 0; i < currentAddressBook.Contacts.Count; i++)
        {
            var c = currentAddressBook.Contacts[i];
            if (c.FirstName.Equals(firstName) && c.PhoneNumber.Equals(phone))
            {
                currentAddressBook.Contacts.RemoveAt(i);
                Console.WriteLine("Contact deleted!");
                return;
            }
        }

        Console.WriteLine("Contact not found!");
    }

    // UC5: Add multiple contacts
    public void AddMultipleContacts()
    {
        char ch;
        do
        {
            AddContact();
            Console.Write("Add another? (y/n): ");
            ch = Console.ReadLine().ToLower()[0];
        } while (ch == 'y');
    }

    // UC6: Add Address Book
    public void AddAddressBook()
    {
        Console.Write("Enter Address Book Name: ");
        string name = Console.ReadLine();

        if (addressBooks.ContainsKey(name))
        {
            Console.WriteLine("Address Book already exists!");
            return;
        }

        AddressBook<IContactEntity> book =
            new AddressBook<IContactEntity>(name);

        addressBooks[name] = book;
        currentAddressBook = book;

        Console.WriteLine($"Address Book '{name}' created and selected.");
    }

    // UC6.1: Switch Address Book
    public void SwitchAddressBook()
    {
        Console.Write("Enter Address Book Name: ");
        string name = Console.ReadLine();

        if (addressBooks.ContainsKey(name))
        {
            currentAddressBook = addressBooks[name];
            Console.WriteLine("Switched successfully.");
        }
        else
        {
            Console.WriteLine("Address Book not found.");
        }
    }

    public bool IsAddressBookSelected()
    {
        return currentAddressBook != null;
    }

    public string GetCurrentAddressBookName()
    {
        return currentAddressBook.Name;
    }

    // UC8: Search by City or State
    public void SearchPersonByCityOrState()
    {
        Console.Write("Enter City or State: ");
        string value = Console.ReadLine();

        foreach (var book in addressBooks.Values)
        {
            foreach (var c in book.Contacts)
            {
                if (c.City.Equals(value) || c.State.Equals(value))
                {
                    Console.WriteLine($"{c.FirstName} ({book.Name})");
                }
            }
        }
    }

    // UC9: View persons
    public void ViewPersonsByCityOrState()
    {
        foreach (var book in addressBooks.Values)
        {
            foreach (var c in book.Contacts)
            {
                Console.WriteLine($"{c.City} - {c.FirstName} ({book.Name})");
            }
        }
    }

    // UC10: Count persons
    public void CountPersonsByCityOrState()
    {
        Console.Write("Enter City or State: ");
        string value = Console.ReadLine();
        int count = 0;

        foreach (var book in addressBooks.Values)
        {
            foreach (var c in book.Contacts)
            {
                if (c.City.Equals(value) || c.State.Equals(value))
                    count++;
            }
        }

        Console.WriteLine($"Total persons: {count}");
    }

    // UC11: Sort by Name
    public void SortContactsByName()
    {
        currentAddressBook.Contacts.Sort(
            (a, b) => a.FirstName.CompareTo(b.FirstName)
        );
        Console.WriteLine("Sorted by name.");
    }

    // UC12: Sort by City / State / Zip
    public void SortContactsByCityStateOrZip()
    {
        Console.WriteLine("1.City  2.State  3.Zip");
        int ch = Convert.ToInt32(Console.ReadLine());

        currentAddressBook.Contacts.Sort((a, b) =>
        {
            if (ch == 1) return a.City.CompareTo(b.City);
            if (ch == 2) return a.State.CompareTo(b.State);
            return a.Zip.CompareTo(b.Zip);
        });

        Console.WriteLine("Sorted successfully.");
    }

    // UC13: Write to file
    public void WriteAddressBookToFile()
    {
        string file = currentAddressBook.Name + ".txt";

        using (StreamWriter w = new StreamWriter(file))
        {
            foreach (var c in currentAddressBook.Contacts)
            {
                w.WriteLine($"{c.FirstName},{c.LastName},{c.City},{c.State}");
            }
        }

        Console.WriteLine("Saved to file.");
    }

    public void ReadAddressBookFromFile()
    {
        string file = currentAddressBook.Name + ".txt";
        if (!File.Exists(file)) return;

        currentAddressBook.Contacts.Clear();

        foreach (var line in File.ReadAllLines(file))
        {
            string[] d = line.Split(',');
            currentAddressBook.Contacts.Add(
                new Address(d[0], d[1], "", d[2], d[3], "", "", "")
            );
        }

        Console.WriteLine("Loaded from file.");
    }

    // UC14: CSV
    public void WriteAddressBookToCSV()
    {
        string file = currentAddressBook.Name + ".csv";

        using (StreamWriter w = new StreamWriter(file))
        {
            w.WriteLine("FirstName,LastName,City,State");
            foreach (var c in currentAddressBook.Contacts)
            {
                w.WriteLine($"{c.FirstName},{c.LastName},{c.City},{c.State}");
            }
        }

        Console.WriteLine("CSV written.");
    }

    public void ReadAddressBookFromCSV()
    {
        string file = currentAddressBook.Name + ".csv";
        if (!File.Exists(file)) return;

        currentAddressBook.Contacts.Clear();
        bool header = true;

        foreach (var line in File.ReadAllLines(file))
        {
            if (header) { header = false; continue; }
            string[] d = line.Split(',');
            currentAddressBook.Contacts.Add(
                new Address(d[0], d[1], "", d[2], d[3], "", "", "")
            );
        }

        Console.WriteLine("CSV loaded.");
    }
}
