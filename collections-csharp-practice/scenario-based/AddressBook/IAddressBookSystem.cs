public interface IAddressBookSystem
{
   // UC6 Add New Address Book
    void AddAddressBook();
    void SwitchAddressBook();// UC6.1 switch between address books
    bool IsAddressBookSelected();//UC6.2 check if any address book is selected
    string GetCurrentAddressBookName();//UC6.3 get current address book name
}
