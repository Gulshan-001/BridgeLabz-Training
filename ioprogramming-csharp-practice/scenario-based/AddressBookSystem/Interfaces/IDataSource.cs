using System.Collections.Generic;
using AddressBookSystem.Models;

namespace AddressBookSystem.Interfaces
{
    public interface IDataSource
    {
        void Write(string bookName, List<Contact> contacts);
        List<Contact> Read(string bookName);
    }
}
