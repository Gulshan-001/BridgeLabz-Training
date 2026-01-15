public interface IAddressBookSystem
{
   // UC6 Add New Address Book
    void AddAddressBook();
    void SwitchAddressBook();// UC6.1 switch between address books
    bool IsAddressBookSelected();
    string GetCurrentAddressBookName();
}
