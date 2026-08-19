using System.IdentityModel.Tokens.Jwt;
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
        {
            return Unauthorized("Invalid user.");
        }

        var note = await _noteService.CreateNoteAsync(
            request,
            userId.Value);

        return Ok(note);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNotes()
    {
        var userId = GetUserId();

        if (userId == null)
        {
            return Unauthorized("Invalid user.");
        }

        var notes = await _noteService.GetAllNotesAsync(
            userId.Value);

        return Ok(notes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNoteById(int id)
    {
        var userId = GetUserId();

        if (userId == null)
        {
            return Unauthorized("Invalid user.");
        }

        var note = await _noteService.GetNoteByIdAsync(
            id,
            userId.Value);

        if (note == null)
        {
            return NotFound("Note not found.");
        }

        return Ok(note);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNote(int id)
    {
        var userId = GetUserId();

        if (userId == null)
        {
            return Unauthorized("Invalid user.");
        }

        var result = await _noteService.DeleteNoteAsync(
            id,
            userId.Value);

        if (!result)
        {
            return NotFound("Note not found.");
        }

        return Ok("Note deleted successfully.");
    }

    private int? GetUserId()
{
    var userIdClaim = User.FindFirst(
        ClaimTypes.NameIdentifier)?.Value;

    if (int.TryParse(userIdClaim, out var userId))
    {
        return userId;
    }

    return null;
}
}