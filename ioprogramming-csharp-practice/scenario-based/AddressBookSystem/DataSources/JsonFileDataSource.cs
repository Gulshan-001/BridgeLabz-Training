using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using AddressBookSystem.Interfaces;
using AddressBookSystem.Models;

namespace AddressBookSystem.DataSources
{
    public class JsonFileDataSource : IDataSource
    {
        public void Write(string bookName, List<Contact> contacts)
        {
            File.WriteAllText(bookName + ".json",
                JsonSerializer.Serialize(contacts));
        }

        public List<Contact> Read(string bookName)
        {
            string file = bookName + ".json";
            if (!File.Exists(file)) return new List<Contact>();
            return JsonSerializer.Deserialize<List<Contact>>(File.ReadAllText(file));
        }
    }
}
