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

        return new NoteResponseDTO
        {
            Id = createdNote.Id,
            Title = createdNote.Title,
            Content = createdNote.Content
        };
    }

    public async Task<List<NoteResponseDTO>> GetAllNotesAsync(int userId)
    {
        var notes = await _noteRepository.GetAllNotesAsync(userId);

        return notes.Select(note => new NoteResponseDTO
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content
        }).ToList();
    }

    public async Task<NoteResponseDTO?> GetNoteByIdAsync(
        int noteId,
        int userId)
    {
        var note = await _noteRepository
            .GetNoteByIdAsync(noteId, userId);

        if (note == null)
        {
            return null;
        }

        return new NoteResponseDTO
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content
        };
    }

    public async Task<bool> DeleteNoteAsync(
        int noteId,
        int userId)
    {
        return await _noteRepository
            .DeleteNoteAsync(noteId, userId);
    }
}