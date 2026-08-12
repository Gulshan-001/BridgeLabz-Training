using ContactsEFCoreApp.Models;

namespace ContactsEFCoreApp.Repository;

public interface IContactRepository
{
    List<Contact> GetAll();

    Contact? GetById(int id);

    Contact Add(Contact contact);

    bool Update(int id, Contact contact);

    bool Delete(int id);
}