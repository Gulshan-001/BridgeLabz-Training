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
            .Where(note =>
                note.UserId == userId &&
                !note.IsDeleted &&
                !note.IsArchived)
            .ToListAsync();
    }

    public async Task<Note?> GetNoteByIdAsync(int noteId, int userId)
    {
        return await _context.Notes
            .FirstOrDefaultAsync(note =>
                note.Id == noteId &&
                note.UserId == userId &&
                !note.IsDeleted);
    }

    public async Task<bool> DeleteNoteAsync(int noteId, int userId)
    {
        var note = await _context.Notes
            .FirstOrDefaultAsync(note =>
                note.Id == noteId &&
                note.UserId == userId &&
                !note.IsDeleted);

        if (note == null)
        {
            return false;
        }

        note.IsDeleted = true;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Note?> PinNoteAsync(int noteId, int userId)
    {
        var note = await _context.Notes
            .FirstOrDefaultAsync(note =>
                note.Id == noteId &&
                note.UserId == userId &&
                !note.IsDeleted);

        if (note == null)
        {
            return null;
        }

        note.IsPinned = !note.IsPinned;

        await _context.SaveChangesAsync();

        return note;
    }

    public async Task<Note?> ArchiveNoteAsync(int noteId, int userId)
    {
        var note = await _context.Notes
            .FirstOrDefaultAsync(note =>
                note.Id == noteId &&
                note.UserId == userId &&
                !note.IsDeleted);

        if (note == null)
        {
            return null;
        }

        note.IsArchived = !note.IsArchived;

        await _context.SaveChangesAsync();

        return note;
    }

    public async Task<List<Note>> SearchNotesAsync(string title, int userId)
    {
        return await _context.Notes
            .Where(note =>
                note.UserId == userId &&
                !note.IsDeleted &&
                note.Title.Contains(title))
            .ToListAsync();
    }
    public async Task<NoteLabel> AddLabelToNoteAsync(
    NoteLabel noteLabel)
{
    _context.NoteLabels.Add(noteLabel);

    await _context.SaveChangesAsync();

    return noteLabel;
}
    public async Task<bool> RemoveLabelFromNoteAsync(
    int noteId,
    int labelId,
    int userId)
{
    var noteLabel = await _context.NoteLabels
        .Include(nl => nl.Note)
        .FirstOrDefaultAsync(nl =>
            nl.NoteId == noteId &&
            nl.LabelId == labelId &&
            nl.Note.UserId == userId);

    if (noteLabel == null)
        return false;

    _context.NoteLabels.Remove(noteLabel);

    await _context.SaveChangesAsync();

    return true;
}
    public async Task<List<Label>> GetLabelsByNoteIdAsync(
    int noteId,
    int userId)
{
    return await _context.NoteLabels
        .Include(nl => nl.Note)
        .Include(nl => nl.Label)
        .Where(nl =>
            nl.NoteId == noteId &&
            nl.Note.UserId == userId)
        .Select(nl => nl.Label)
        .ToListAsync();
}
    public async Task<List<Note>> GetNotesByLabelIdAsync(
    int labelId,
    int userId)
{
    return await _context.NoteLabels
        .Include(nl => nl.Note)
        .Include(nl => nl.Label)
        .Where(nl =>
            nl.LabelId == labelId &&
            nl.Note.UserId == userId &&
            !nl.Note.IsDeleted)
        .Select(nl => nl.Note)
        .ToListAsync();
}
}