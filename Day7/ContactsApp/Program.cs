using ContactsApp.Data;
using ContactsApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<ContactDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();


// GET: Get all contacts
app.MapGet("/api/contacts", async (ContactDbContext db) =>
{
    var contacts = await db.Contacts.ToListAsync();

    return Results.Ok(contacts);
});


// GET: Get contact by ID
app.MapGet("/api/contacts/{id}", async (int id, ContactDbContext db) =>
{
    var contact = await db.Contacts.FindAsync(id);

    if (contact == null)
    {
        return Results.NotFound("Contact not found");
    }

    return Results.Ok(contact);
});


// POST: Create contact
app.MapPost("/api/contacts", async (Contact contact, ContactDbContext db) =>
{
    db.Contacts.Add(contact);

    await db.SaveChangesAsync();

    return Results.Created(
        $"/api/contacts/{contact.Id}",
        contact
    );
});


// PUT: Update contact
app.MapPut("/api/contacts/{id}", async (int id, Contact updatedContact, ContactDbContext db) =>
{
    var contact = await db.Contacts.FindAsync(id);

    if (contact == null)
    {
        return Results.NotFound("Contact not found");
    }

    contact.Name = updatedContact.Name;
    contact.Email = updatedContact.Email;
    contact.Phone = updatedContact.Phone;

    await db.SaveChangesAsync();

    return Results.Ok(contact);
});


// DELETE: Delete contact
app.MapDelete("/api/contacts/{id}", async (int id, ContactDbContext db) =>
{
    var contact = await db.Contacts.FindAsync(id);

    if (contact == null)
    {
        return Results.NotFound("Contact not found");
    }

    db.Contacts.Remove(contact);

    await db.SaveChangesAsync();

    return Results.Ok("Contact deleted successfully");
});


app.Run();