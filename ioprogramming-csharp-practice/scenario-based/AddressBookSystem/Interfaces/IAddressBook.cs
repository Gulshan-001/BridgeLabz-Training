namespace AddressBookSystem.Interfaces
{
    public interface IAddressBook
    {
        void AddContact();
        void AddMultipleContacts();
        void EditContact();
        void DeleteContact();

        void SearchPersonByCityOrState();
        void ViewPersonsByCityOrState();
        void CountPersonsByCityOrState();

        void SortContactsByName();
        void SortContactsByCityStateOrZip();

        void WriteAddressBookToCSV();
        void ReadAddressBookFromCSV();

        void WriteAddressBookToJSON();
        void ReadAddressBookFromJSON();

        void WriteAddressBookToJsonServer();
        void ReadAddressBookFromJsonServer();

        void SaveAddressBookToDatabase();
    }
}
