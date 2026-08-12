using ContactsEFCoreApp.Models;
using ContactsEFCoreApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace ContactsEFCoreApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactService _service;

    public ContactController(IContactService service)
    {
        _service = service;
    }

    // GET: api/Contact
    [HttpGet]
    public IActionResult GetAllContacts()
    {
        var contacts = _service.GetAllContacts();

        return Ok(contacts);
    }

    // GET: api/Contact/1
    [HttpGet("{id}")]
    public IActionResult GetContactById(int id)
    {
        var contact = _service.GetContactById(id);

        if (contact == null)
        {
            return NotFound("Contact not found");
        }

        return Ok(contact);
    }

    // POST: api/Contact
    [HttpPost]
    public IActionResult AddContact(Contact contact)
    {
        var createdContact = _service.AddContact(contact);

        return CreatedAtAction(
            nameof(GetContactById),
            new { id = createdContact.Id },
            createdContact
        );
    }

    // PUT: api/Contact/1
    [HttpPut("{id}")]
    public IActionResult UpdateContact(int id, Contact contact)
    {
        var updated = _service.UpdateContact(id, contact);

        if (!updated)
        {
            return NotFound("Contact not found");
        }

        return Ok("Contact updated successfully");
    }

    // DELETE: api/Contact/1
    [HttpDelete("{id}")]
    public IActionResult DeleteContact(int id)
    {
        var deleted = _service.DeleteContact(id);

        if (!deleted)
        {
            return NotFound("Contact not found");
        }

        return Ok("Contact deleted successfully");
    }
}