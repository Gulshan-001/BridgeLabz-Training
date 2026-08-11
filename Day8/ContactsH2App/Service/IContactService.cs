using ContactsH2App.Models;

namespace ContactsH2App.Service;

public interface IContactService
{
    List<Contact> GetAllContacts();

    Contact? GetContactById(int id);

    Contact AddContact(Contact contact);

    bool UpdateContact(int id, Contact contact);

    bool DeleteContact(int id);
}