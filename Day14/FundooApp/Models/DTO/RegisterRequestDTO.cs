using System.ComponentModel.DataAnnotations;

namespace Models.DTO;

public class RegisterRequestDTO
{
    [Required(ErrorMessage = "First name is required.")]
    [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First name can contain only letters.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required.")]
    [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last name can contain only letters.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must contain at least 8 characters, one uppercase letter, one lowercase letter, one number, and one special character."
    )]
    public string Password { get; set; } = string.Empty;
}