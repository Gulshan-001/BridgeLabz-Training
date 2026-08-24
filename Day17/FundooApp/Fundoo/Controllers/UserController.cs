using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;

namespace Fundoo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDTO request)
    {
        var result = await _userService.RegisterUserAsync(request);

        if (!result)
        {
            return Conflict("User with this email already exists.");
        }

        return Ok("User registered successfully.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDTO request)
    {
        var response = await _userService.LoginUserAsync(request);

        if (response == null)
        {
            return Unauthorized("Invalid email or password.");
        }

        return Ok(response);
    }

    [Authorize]
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        var userId = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

        var email = User.FindFirst(JwtRegisteredClaimNames.Email)?.Value;

        var name = User.FindFirst(ClaimTypes.Name)?.Value;

        return Ok(new
        {
            UserId = userId,
            Name = name,
            Email = email
        });
    }
}