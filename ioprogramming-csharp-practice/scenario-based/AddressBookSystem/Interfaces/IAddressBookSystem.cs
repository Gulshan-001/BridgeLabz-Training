namespace AddressBookSystem.Interfaces
{
    public interface IAddressBookSystem
    {
        void AddAddressBook();
        void SwitchAddressBook();
        bool IsAddressBookSelected();
        string GetCurrentAddressBookName();
    }
}
