using Business.Interface;
using Models.DTO;
using Models.Entity;
using Repository.Interface;

namespace Business.Service;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;

    public NoteService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<NoteResponseDTO> CreateNoteAsync(
        CreateNoteRequestDTO request,
        int userId)
    {
        var note = new Note
        {
            Title = request.Title,
            Content = request.Content,
            UserId = userId
        };

        var createdNote = await _noteRepository.CreateNoteAsync(note);

        return MapToResponse(createdNote);
    }

    public async Task<List<NoteResponseDTO>> GetAllNotesAsync(int userId)
    {
        var notes = await _noteRepository.GetAllNotesAsync(userId);

        return notes
            .Select(MapToResponse)
            .ToList();
    }

    public async Task<NoteResponseDTO?> GetNoteByIdAsync(
        int noteId,
        int userId)
    {
        var note = await _noteRepository
            .GetNoteByIdAsync(noteId, userId);

        return note == null ? null : MapToResponse(note);
    }

    public async Task<bool> DeleteNoteAsync(
        int noteId,
        int userId)
    {
        return await _noteRepository
            .DeleteNoteAsync(noteId, userId);
    }

    public async Task<NoteResponseDTO?> PinNoteAsync(
        int noteId,
        int userId)
    {
        var note = await _noteRepository
            .PinNoteAsync(noteId, userId);

        return note == null ? null : MapToResponse(note);
    }

    public async Task<NoteResponseDTO?> ArchiveNoteAsync(
        int noteId,
        int userId)
    {
        var note = await _noteRepository
            .ArchiveNoteAsync(noteId, userId);

        return note == null ? null : MapToResponse(note);
    }

    public async Task<List<NoteResponseDTO>> SearchNotesAsync(
        string title,
        int userId)
    {
        var notes = await _noteRepository
            .SearchNotesAsync(title, userId);

        return notes
            .Select(MapToResponse)
            .ToList();
    }

    private static NoteResponseDTO MapToResponse(Note note)
    {
        return new NoteResponseDTO
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content
        };
    }
}