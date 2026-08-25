using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.DTO;
using Models.Entity;
using Repository.Interface;

namespace Business.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordHasher<User> _passwordHasher;
    private readonly IConfiguration _configuration;

    public UserService(
        IUserRepository userRepository,
        IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _passwordHasher = new PasswordHasher<User>();
    }

    public async Task<bool> RegisterUserAsync(RegisterRequestDTO request)
    {
        var existingUser = await _userRepository
            .GetUserByEmailAsync(request.Email);

        if (existingUser != null)
        {
            return false;
        }

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };

        user.PasswordHash = _passwordHasher
            .HashPassword(user, request.Password);

        await _userRepository.AddUserAsync(user);

        return true;
    }

    public async Task<AuthResponseDTO?> LoginUserAsync(LoginRequestDTO request)
    {
        var user = await _userRepository
            .GetUserByEmailAsync(request.Email);

        if (user == null)
        {
            return null;
        }

        var passwordResult = _passwordHasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            request.Password
        );

        if (passwordResult == PasswordVerificationResult.Failed)
        {
            return null;
        }

        var token = GenerateJwtToken(user);

        return new AuthResponseDTO
        {
            Token = token,
            UserId = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
    }

    private string GenerateJwtToken(User user)
    {
        var jwtSettings = _configuration.GetSection("Jwt");

        var key = jwtSettings["Key"]
            ?? throw new InvalidOperationException("JWT key is missing.");

        var issuer = jwtSettings["Issuer"]
            ?? throw new InvalidOperationException("JWT issuer is missing.");

        var audience = jwtSettings["Audience"]
            ?? throw new InvalidOperationException("JWT audience is missing.");

        var expiryMinutes = int.Parse(
            jwtSettings["ExpiryMinutes"] ?? "60"
        );

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
        };

        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key)
        );

        var credentials = new SigningCredentials(
            securityKey,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}