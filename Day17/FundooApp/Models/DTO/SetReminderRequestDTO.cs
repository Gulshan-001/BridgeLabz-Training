using System.ComponentModel.DataAnnotations;

namespace Models.DTO;

public class SetReminderRequestDTO
{
    [Required]
    public DateTime ReminderTime { get; set; }
}