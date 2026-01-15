// Interface for Address Book operations
public interface IAddressBook
{
    // UC2 Add Contact
    void AddContact();

    // UC3 Edit Existing Contact
    void EditContact();

    // UC4 Delete Contact
    void DeleteContact();

    // UC5 Add Multiple Contacts at Once
    void AddMultipleContacts();

    //UC8 Search Person by City or State across multiple Address Books
    void SearchPersonByCityOrState();
    
    //UC9 View Persons by City or State across multiple Address Books
    void ViewPersonsByCityOrState();

}
