using ContactsEFCoreApp.Models;
using ContactsEFCoreApp.Repository;

namespace ContactsEFCoreApp.Service;

public class ContactService : IContactService
{
    private readonly IContactRepository _repository;

    public ContactService(IContactRepository repository)
    {
        _repository = repository;
    }

    public List<Contact> GetAllContacts()
    {
        return _repository.GetAll();
    }

    public Contact? GetContactById(int id)
    {
        return _repository.GetById(id);
    }

    public Contact AddContact(Contact contact)
    {
        return _repository.Add(contact);
    }

    public bool UpdateContact(int id, Contact contact)
    {
        return _repository.Update(id, contact);
    }

    public bool DeleteContact(int id)
    {
        return _repository.Delete(id);
    }
}