using Business.Interface;
using Models.DTO;
using Models.Entity;
using Repository.Interface;

namespace Business.Service;

public class NoteService : INoteService
{
private readonly INoteRepository _noteRepository;
private readonly ILabelRepository _labelRepository;
    public NoteService(
    INoteRepository noteRepository,
    ILabelRepository labelRepository)
{
    _noteRepository = noteRepository;
    _labelRepository = labelRepository;
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
    public async Task<bool> AddLabelToNoteAsync(
    int noteId,
    int labelId,
    int userId)
{
    var note = await _noteRepository
        .GetNoteByIdAsync(noteId, userId);

    if (note == null)
        return false;

    var label = await _labelRepository
        .GetLabelByIdAsync(labelId, userId);

    if (label == null)
        return false;

    var noteLabel = new NoteLabel
    {
        NoteId = noteId,
        LabelId = labelId
    };

    await _noteRepository.AddLabelToNoteAsync(noteLabel);

    return true;
}
    public async Task<bool> RemoveLabelFromNoteAsync(
    int noteId,
    int labelId,
    int userId)
{
    return await _noteRepository
        .RemoveLabelFromNoteAsync(
            noteId,
            labelId,
            userId);
}
public async Task<List<LabelResponseDTO>>
    GetLabelsByNoteIdAsync(
        int noteId,
        int userId)
{
    var labels = await _noteRepository
        .GetLabelsByNoteIdAsync(noteId, userId);

    return labels.Select(label => new LabelResponseDTO
    {
        Id = label.Id,
        Name = label.Name
    }).ToList();
}
    public async Task<List<NoteResponseDTO>>
    GetNotesByLabelIdAsync(
        int labelId,
        int userId)
{
    var notes = await _noteRepository
        .GetNotesByLabelIdAsync(labelId, userId);

    return notes.Select(note => new NoteResponseDTO
    {
        Id = note.Id,
        Title = note.Title,
        Content = note.Content
    }).ToList();
}
    public async Task<NoteResponseDTO?> SetReminderAsync(
    int noteId,
    int userId,
    DateTime reminderTime)
{
    var note = await _noteRepository
        .SetReminderAsync(
            noteId,
            userId,
            reminderTime);

    return note == null
        ? null
        : MapToResponse(note);
}
}