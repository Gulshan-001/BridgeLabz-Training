using System.Collections.Generic;
using System.IO;
using AddressBookSystem.Interfaces;
using AddressBookSystem.Models;

namespace AddressBookSystem.DataSources
{
    public class CsvDataSource : IDataSource
    {
        public void Write(string bookName, List<Contact> contacts)
        {
            using (StreamWriter sw = new StreamWriter(bookName + ".csv"))
            {
                foreach (Contact c in contacts)
                    sw.WriteLine($"{c.FirstName},{c.LastName},{c.City},{c.State}");
            }
        }

        public List<Contact> Read(string bookName)
        {
            List<Contact> list = new List<Contact>();
            string file = bookName + ".csv";
            if (!File.Exists(file)) return list;

            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] d = line.Split(',');
                    list.Add(new Contact { FirstName = d[0], LastName = d[1], City = d[2], State = d[3] });
                }
            }
            return list;
        }
    }
}
