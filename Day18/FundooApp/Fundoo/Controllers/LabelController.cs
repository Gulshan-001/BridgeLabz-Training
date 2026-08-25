using System.Security.Claims;
using Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;

namespace Fundoo.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class LabelController : ControllerBase
{
    private readonly ILabelService _labelService;

    public LabelController(ILabelService labelService)
    {
        _labelService = labelService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLabel(
        CreateLabelRequestDTO request)
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized("Invalid user.");

        var label = await _labelService.CreateLabelAsync(
            request, userId.Value);

        return Ok(label);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLabels()
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized("Invalid user.");

        var labels = await _labelService
            .GetAllLabelsAsync(userId.Value);

        return Ok(labels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLabelById(int id)
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized("Invalid user.");

        var label = await _labelService
            .GetLabelByIdAsync(id, userId.Value);

        if (label == null)
            return NotFound("Label not found.");

        return Ok(label);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLabel(
        int id,
        UpdateLabelRequestDTO request)
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized("Invalid user.");

        var label = await _labelService.UpdateLabelAsync(
            id, request, userId.Value);

        if (label == null)
            return NotFound("Label not found.");

        return Ok(label);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLabel(int id)
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized("Invalid user.");

        var result = await _labelService.DeleteLabelAsync(
            id, userId.Value);

        if (!result)
            return NotFound("Label not found.");

        return Ok("Label deleted successfully.");
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