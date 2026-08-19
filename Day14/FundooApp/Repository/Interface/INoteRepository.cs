using Models.Entity;

namespace Repository.Interface;

public interface INoteRepository
{
    Task<Note> CreateNoteAsync(Note note);

    Task<List<Note>> GetAllNotesAsync(int userId);

    Task<Note?> GetNoteByIdAsync(int noteId, int userId);

    Task<bool> DeleteNoteAsync(int noteId, int userId);
}