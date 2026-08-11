using ContactsH2App.Models;
using ContactsH2App.Repository;
using ContactsH2App.Service;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();


// GET: /api/contacts
app.MapGet("/api/contacts", (IContactService service) =>
{
    var contacts = service.GetAllContacts();

    return Results.Ok(contacts);
});


// GET: /api/contacts/{id}
app.MapGet("/api/contacts/{id}", (int id, IContactService service) =>
{
    var contact = service.GetContactById(id);

    if (contact == null)
    {
        return Results.NotFound("Contact not found");
    }

    return Results.Ok(contact);
});


// POST: /api/contacts
app.MapPost("/api/contacts", (Contact contact, IContactService service) =>
{
    var createdContact = service.AddContact(contact);

    return Results.Created(
        $"/api/contacts/{createdContact.Id}",
        createdContact
    );
});


// PUT: /api/contacts/{id}
app.MapPut("/api/contacts/{id}", (int id, Contact contact, IContactService service) =>
{
    var updated = service.UpdateContact(id, contact);

    if (!updated)
    {
        return Results.NotFound("Contact not found");
    }

    return Results.Ok("Contact updated successfully");
});


// DELETE: /api/contacts/{id}
app.MapDelete("/api/contacts/{id}", (int id, IContactService service) =>
{
    var deleted = service.DeleteContact(id);

    if (!deleted)
    {
        return Results.NotFound("Contact not found");
    }

    return Results.Ok("Contact deleted successfully");
});


app.Run();