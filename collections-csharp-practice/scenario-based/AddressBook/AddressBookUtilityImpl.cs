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
        try
        {
            if (currentAddressBook == null)
            {
                Console.WriteLine("Please create or switch to an Address Book first.");
                return;
            }

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
        catch (Exception ex)
        {
            Console.WriteLine("Error while adding contact: " + ex.Message);
        }
    }

    // UC3: Edit contact using First Name + Phone Number
    public void EditContact()
    {
        try
        {
            if (currentAddressBook == null)
            {
                Console.WriteLine("Please create or switch to an Address Book first.");
                return;
            }

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
        catch (Exception ex)
        {
            Console.WriteLine("Error while editing contact: " + ex.Message);
        }
    }

    // UC4: Delete contact
    public void DeleteContact()
    {
        try
        {
            if (currentAddressBook == null)
            {
                Console.WriteLine("Please create or switch to an Address Book first.");
                return;
            }

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
        catch (Exception ex)
        {
            Console.WriteLine("Error while deleting contact: " + ex.Message);
        }
    }

    // UC5: Add multiple contacts
    public void AddMultipleContacts()
    {
        try
        {
            char ch;
            do
            {
                AddContact();
                Console.Write("Add another? (y/n): ");
                ch = Console.ReadLine().ToLower()[0];
            } while (ch == 'y');
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while adding multiple contacts: " + ex.Message);
        }
    }

    // UC6: Add Address Book
    public void AddAddressBook()
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine("Error while creating Address Book: " + ex.Message);
        }
    }

    // UC6.1: Switch Address Book
    public void SwitchAddressBook()
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine("Error while switching Address Book: " + ex.Message);
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
        try
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
        catch (Exception ex)
        {
            Console.WriteLine("Error during search: " + ex.Message);
        }
    }

    // UC9: View persons
    public void ViewPersonsByCityOrState()
    {
        try
        {
            foreach (var book in addressBooks.Values)
            {
                foreach (var c in book.Contacts)
                {
                    Console.WriteLine($"{c.City} - {c.FirstName} ({book.Name})");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while viewing persons: " + ex.Message);
        }
    }

    // UC10: Count persons
    public void CountPersonsByCityOrState()
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine("Error while counting persons: " + ex.Message);
        }
    }

    // UC11: Sort by Name
    public void SortContactsByName()
    {
        try
        {
            currentAddressBook.Contacts.Sort(
                (a, b) => a.FirstName.CompareTo(b.FirstName)
            );
            Console.WriteLine("Sorted by name.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while sorting: " + ex.Message);
        }
    }

    // UC12: Sort by City / State / Zip
    public void SortContactsByCityStateOrZip()
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine("Error while sorting: " + ex.Message);
        }
    }

    // UC13: Write to file
    public void WriteAddressBookToFile()
    {
        try
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
        catch (IOException)
        {
            Console.WriteLine("File write error.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while writing file: " + ex.Message);
        }
    }

    public void ReadAddressBookFromFile()
    {
        try
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
        catch (IOException)
        {
            Console.WriteLine("File read error.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while reading file: " + ex.Message);
        }
    }

    // UC14: CSV
    public void WriteAddressBookToCSV()
    {
        try
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
        catch (IOException)
        {
            Console.WriteLine("CSV write error.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while writing CSV: " + ex.Message);
        }
    }

    public void ReadAddressBookFromCSV()
    {
        try
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
        catch (IOException)
        {
            Console.WriteLine("CSV read error.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while reading CSV: " + ex.Message);
        }
    }
}
