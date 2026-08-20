using Models.DTO;

namespace Business.Interface;

public interface INoteService
{
    Task<NoteResponseDTO> CreateNoteAsync(
        CreateNoteRequestDTO request,
        int userId);

    Task<List<NoteResponseDTO>> GetAllNotesAsync(int userId);

    Task<NoteResponseDTO?> GetNoteByIdAsync(
        int noteId,
        int userId);

    Task<bool> DeleteNoteAsync(
        int noteId,
        int userId);

    Task<NoteResponseDTO?> PinNoteAsync(
        int noteId,
        int userId);

    Task<NoteResponseDTO?> ArchiveNoteAsync(
        int noteId,
        int userId);

    Task<List<NoteResponseDTO>> SearchNotesAsync(
        string title,
        int userId);
}