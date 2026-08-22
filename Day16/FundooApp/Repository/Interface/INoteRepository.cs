using Models.Entity;

namespace Repository.Interface;

public interface INoteRepository
{
    Task<Note> CreateNoteAsync(Note note);

    Task<List<Note>> GetAllNotesAsync(int userId);

    Task<Note?> GetNoteByIdAsync(int noteId, int userId);

    Task<bool> DeleteNoteAsync(int noteId, int userId);

    Task<Note?> PinNoteAsync(int noteId, int userId);

    Task<Note?> ArchiveNoteAsync(int noteId, int userId);

    Task<List<Note>> SearchNotesAsync(string title, int userId);
    Task<NoteLabel> AddLabelToNoteAsync(NoteLabel noteLabel);

Task<bool> RemoveLabelFromNoteAsync(
    int noteId,
    int labelId,
    int userId);

Task<List<Label>> GetLabelsByNoteIdAsync(
    int noteId,
    int userId);

Task<List<Note>> GetNotesByLabelIdAsync(
    int labelId,
    int userId);
}