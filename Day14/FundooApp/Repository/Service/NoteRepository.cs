using Microsoft.EntityFrameworkCore;
using Models.Entity;
using Repository.Context;
using Repository.Interface;

namespace Repository.Service;

public class NoteRepository : INoteRepository
{
    private readonly ApplicationDbContext _context;

    public NoteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Note> CreateNoteAsync(Note note)
    {
        _context.Notes.Add(note);

        await _context.SaveChangesAsync();

        return note;
    }

    public async Task<List<Note>> GetAllNotesAsync(int userId)
    {
        return await _context.Notes
            .Where(note => note.UserId == userId)
            .ToListAsync();
    }

    public async Task<Note?> GetNoteByIdAsync(int noteId, int userId)
    {
        return await _context.Notes
            .FirstOrDefaultAsync(note =>
                note.Id == noteId &&
                note.UserId == userId);
    }

    public async Task<bool> DeleteNoteAsync(int noteId, int userId)
    {
        var note = await _context.Notes
            .FirstOrDefaultAsync(note =>
                note.Id == noteId &&
                note.UserId == userId);

        if (note == null)
        {
            return false;
        }

        _context.Notes.Remove(note);

        await _context.SaveChangesAsync();

        return true;
    }
}