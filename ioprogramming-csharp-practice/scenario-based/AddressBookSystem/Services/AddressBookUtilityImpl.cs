using System;
using System.Collections.Generic;
using System.Reflection;
using AddressBookSystem.Interfaces;
using AddressBookSystem.Models;
using AddressBookSystem.Attributes;
using AddressBookSystem.Utils;
using AddressBookSystem.DataSources;

namespace AddressBookSystem.Services
{
    [UniqueContact]
    public class AddressBookUtilityImpl : IAddressBookSystem, IAddressBook
    {
        private Dictionary<string, List<Contact>> books = new Dictionary<string, List<Contact>>();
        private string currentBook;

        private IDataSource csv = new CsvDataSource();
        private IDataSource jsonFile = new JsonFileDataSource();
        private IDataSource jsonServer = new JsonServerDataSource();
        private IDataSource database = new DatabaseDataSource();

        /* SYSTEM LEVEL */
        public void AddAddressBook()
        {
            Console.Write("Enter Address Book Name: ");
            string name = Console.ReadLine();
            if (books.ContainsKey(name))
            {
                Console.WriteLine("Already exists");
                return;
            }
            books[name] = new List<Contact>();
            Console.WriteLine("Created");
        }

        public void SwitchAddressBook()
        {
            Console.Write("Enter Address Book Name: ");
            string name = Console.ReadLine();
            if (!books.ContainsKey(name))
            {
                Console.WriteLine("Not found");
                return;
            }
            currentBook = name;
        }

        public bool IsAddressBookSelected() => currentBook != null;
        public string GetCurrentAddressBookName() => currentBook;

        /* CONTACT CRUD */
        public void AddContact()
        {
            Contact c = ReadContact();

            foreach (var x in books[currentBook])
                if (x.FullName() == c.FullName())
                {
                    Console.WriteLine("Duplicate");
                    return;
                }

            books[currentBook].Add(c);
        }

        public void AddMultipleContacts()
        {
            Console.Write("How many: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++) AddContact();
        }

        public void EditContact()
        {
            Console.Write("Full Name: ");
            string name = Console.ReadLine();
            foreach (var c in books[currentBook])
                if (c.FullName() == name)
                {
                    Console.Write("New City: ");
                    c.City = Console.ReadLine();
                    return;
                }
        }

        public void DeleteContact()
        {
            Console.Write("Full Name: ");
            string name = Console.ReadLine();
            for (int i = 0; i < books[currentBook].Count; i++)
                if (books[currentBook][i].FullName() == name)
                {
                    books[currentBook].RemoveAt(i);
                    return;
                }
        }

        /* SEARCH / VIEW / COUNT */
        public void SearchPersonByCityOrState()
        {
            Console.Write("City/State: ");
            string key = Console.ReadLine();
            foreach (var b in books.Values)
                foreach (var c in b)
                    if (c.City == key || c.State == key)
                        Console.WriteLine(c.FullName());
        }

        public void ViewPersonsByCityOrState() => SearchPersonByCityOrState();

        public void CountPersonsByCityOrState()
        {
            Console.Write("City/State: ");
            string key = Console.ReadLine();
            int count = 0;
            foreach (var b in books.Values)
                foreach (var c in b)
                    if (c.City == key || c.State == key) count++;
            Console.WriteLine("Count: " + count);
        }

        /* SORTING – DSA */
        public void SortContactsByName()
        {
            var list = books[currentBook];
            for (int i = 0; i < list.Count - 1; i++)
                for (int j = i + 1; j < list.Count; j++)
                    if (string.Compare(list[i].FirstName, list[j].FirstName) > 0)
                    {
                        var t = list[i]; list[i] = list[j]; list[j] = t;
                    }
        }

        public void SortContactsByCityStateOrZip()
        {
            var list = books[currentBook];
            for (int i = 0; i < list.Count - 1; i++)
                for (int j = i + 1; j < list.Count; j++)
                    if (string.Compare(list[i].City, list[j].City) > 0)
                    {
                        var t = list[i]; list[i] = list[j]; list[j] = t;
                    }
        }

        /* ASYNC IO */
        public void WriteAddressBookToCSV() =>
            AsyncHelper.RunAsync(() => csv.Write(currentBook, books[currentBook]));

        public void ReadAddressBookFromCSV() =>
            AsyncHelper.RunAsync(() => books[currentBook] = csv.Read(currentBook));

        public void WriteAddressBookToJSON() =>
            AsyncHelper.RunAsync(() => jsonFile.Write(currentBook, books[currentBook]));

        public void ReadAddressBookFromJSON() =>
            AsyncHelper.RunAsync(() => books[currentBook] = jsonFile.Read(currentBook));

        public void WriteAddressBookToJsonServer() =>
            AsyncHelper.RunAsync(() => jsonServer.Write(currentBook, books[currentBook]));

        public void ReadAddressBookFromJsonServer() =>
            AsyncHelper.RunAsync(() => books[currentBook] = jsonServer.Read(currentBook));

        public void SaveAddressBookToDatabase() =>
            AsyncHelper.RunAsync(() => database.Write(currentBook, books[currentBook]));

        private Contact ReadContact()
        {
            Contact c = new Contact();
            Console.Write("First Name: "); c.FirstName = Console.ReadLine();
            Console.Write("Last Name: "); c.LastName = Console.ReadLine();
            Console.Write("City: "); c.City = Console.ReadLine();
            Console.Write("State: "); c.State = Console.ReadLine();
            return c;
        }
    }
}
