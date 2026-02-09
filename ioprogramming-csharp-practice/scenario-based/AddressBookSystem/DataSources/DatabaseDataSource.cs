using System.Collections.Generic;
using AddressBookSystem.Interfaces;
using AddressBookSystem.Models;

namespace AddressBookSystem.DataSources
{
    public class DatabaseDataSource : IDataSource
    {
        public void Write(string bookName, List<Contact> contacts)
        {
            // ADO.NET logic here (INSERT)
        }

        public List<Contact> Read(string bookName)
        {
            return new List<Contact>();
        }
    }
}
