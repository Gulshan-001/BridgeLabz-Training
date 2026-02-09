using System.Collections.Generic;
using System.IO;
using AddressBookSystem.Interfaces;
using AddressBookSystem.Models;

namespace AddressBookSystem.DataSources
{
    public class JsonServerDataSource : IDataSource
    {
        private const string DIR = "JsonServer";

        public JsonServerDataSource()
        {
            if (!Directory.Exists(DIR)) Directory.CreateDirectory(DIR);
        }

        public void Write(string bookName, List<Contact> contacts)
        {
            using (StreamWriter sw = new StreamWriter($"{DIR}/{bookName}.server"))
                foreach (var c in contacts)
                    sw.WriteLine($"{c.FirstName}|{c.LastName}|{c.City}|{c.State}");
        }

        public List<Contact> Read(string bookName)
        {
            List<Contact> list = new List<Contact>();
            string path = $"{DIR}/{bookName}.server";
            if (!File.Exists(path)) return list;

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var d = line.Split('|');
                    list.Add(new Contact { FirstName = d[0], LastName = d[1], City = d[2], State = d[3] });
                }
            }
            return list;
        }
    }
}
