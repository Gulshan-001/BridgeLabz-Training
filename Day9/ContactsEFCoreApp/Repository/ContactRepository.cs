using ContactsEFCoreApp.Data;
using ContactsEFCoreApp.Models;

namespace ContactsEFCoreApp.Repository;

public class ContactRepository : IContactRepository
{
    private readonly AppDbContext _context;

    public ContactRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Contact> GetAll()
    {
        return _context.Contacts.ToList();
    }

    public Contact? GetById(int id)
    {
        return _context.Contacts.Find(id);
    }

    public Contact Add(Contact contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();

        return contact;
    }

    public bool Update(int id, Contact contact)
    {
        var existingContact = _context.Contacts.Find(id);

        if (existingContact == null)
        {
            return false;
        }

        existingContact.Name = contact.Name;
        existingContact.Email = contact.Email;
        existingContact.Phone = contact.Phone;

        _context.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        var contact = _context.Contacts.Find(id);

        if (contact == null)
        {
            return false;
        }

        _context.Contacts.Remove(contact);
        _context.SaveChanges();

        return true;
    }
}