using ContactsH2App.Models;

namespace ContactsH2App.Repository;

public interface IContactRepository
{
    List<Contact> GetAll();

    Contact? GetById(int id);

    Contact Add(Contact contact);

    bool Update(int id, Contact contact);

    bool Delete(int id);
}