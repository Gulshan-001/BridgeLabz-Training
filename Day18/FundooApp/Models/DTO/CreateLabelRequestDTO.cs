using System.ComponentModel.DataAnnotations;

namespace Models.DTO;

public class CreateLabelRequestDTO
{
    [Required(ErrorMessage = "Label name is required.")]
    [StringLength(50, ErrorMessage = "Label name cannot exceed 50 characters.")]
    public string Name { get; set; } = string.Empty;
}