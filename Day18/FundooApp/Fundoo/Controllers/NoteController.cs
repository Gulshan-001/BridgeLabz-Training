using System.Security.Claims;
using Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;

namespace Fundoo.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;

    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNote(
        CreateNoteRequestDTO request)
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized("Invalid user.");

        var note = await _noteService.CreateNoteAsync(
            request, userId.Value);

        return Ok(note);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNotes()
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized("Invalid user.");

        var notes = await _noteService.GetAllNotesAsync(userId.Value);

        return Ok(notes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNoteById(int id)
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized("Invalid user.");

        var note = await _noteService.GetNoteByIdAsync(
            id, userId.Value);

        if (note == null)
            return NotFound("Note not found.");

        return Ok(note);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNote(int id)
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized("Invalid user.");

        var result = await _noteService.DeleteNoteAsync(
            id, userId.Value);

        if (!result)
            return NotFound("Note not found.");

        return Ok("Note moved to trash successfully.");
    }

    [HttpPut("{id}/pin")]
    public async Task<IActionResult> PinNote(int id)
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized("Invalid user.");

        var note = await _noteService.PinNoteAsync(
            id, userId.Value);

        if (note == null)
            return NotFound("Note not found.");

        return Ok(note);
    }

    [HttpPut("{id}/archive")]
    public async Task<IActionResult> ArchiveNote(int id)
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized("Invalid user.");

        var note = await _noteService.ArchiveNoteAsync(
            id, userId.Value);

        if (note == null)
            return NotFound("Note not found.");

        return Ok(note);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchNotes(
        [FromQuery] string title)
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized("Invalid user.");

        var notes = await _noteService.SearchNotesAsync(
            title, userId.Value);

        return Ok(notes);
    }
    [HttpPost("{noteId}/label/{labelId}")]
public async Task<IActionResult> AddLabelToNote(
    int noteId,
    int labelId)
{
    var userId = GetUserId();

    if (userId == null)
        return Unauthorized("Invalid user.");

    var result = await _noteService.AddLabelToNoteAsync(
        noteId,
        labelId,
        userId.Value);

    if (!result)
        return NotFound("Note or Label not found.");

    return Ok("Label added to note successfully.");
}
    [HttpDelete("{noteId}/label/{labelId}")]
public async Task<IActionResult> RemoveLabelFromNote(
    int noteId,
    int labelId)
{
    var userId = GetUserId();

    if (userId == null)
        return Unauthorized("Invalid user.");

    var result = await _noteService.RemoveLabelFromNoteAsync(
        noteId,
        labelId,
        userId.Value);

    if (!result)
        return NotFound("Label is not associated with this note.");

    return Ok("Label removed from note successfully.");
}
    [HttpGet("{noteId}/labels")]
public async Task<IActionResult> GetLabelsByNoteId(
    int noteId)
{
    var userId = GetUserId();

    if (userId == null)
        return Unauthorized("Invalid user.");

    var labels = await _noteService.GetLabelsByNoteIdAsync(
        noteId,
        userId.Value);

    return Ok(labels);
}
    [HttpGet("label/{labelId}")]
public async Task<IActionResult> GetNotesByLabelId(
    int labelId)
{
    var userId = GetUserId();

    if (userId == null)
        return Unauthorized("Invalid user.");

    var notes = await _noteService.GetNotesByLabelIdAsync(
        labelId,
        userId.Value);

    return Ok(notes);
}
    [HttpPut("{id}/reminder")]
public async Task<IActionResult> SetReminder(
    int id,
    SetReminderRequestDTO request)
{
    var userId = GetUserId();

    if (userId == null)
        return Unauthorized("Invalid user.");

    if (request.ReminderTime <= DateTime.Now)
        return BadRequest("Reminder time must be in the future.");

    var note = await _noteService.SetReminderAsync(
        id,
        userId.Value,
        request.ReminderTime);

    if (note == null)
        return NotFound("Note not found.");

    return Ok(note);
}
    private int? GetUserId()
    {
        var userIdClaim =
            User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (int.TryParse(userIdClaim, out var userId))
            return userId;

        return null;
    }
}