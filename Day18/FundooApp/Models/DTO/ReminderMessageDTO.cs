namespace Models.DTO;

public class ReminderMessageDTO
{
    public int NoteId { get; set; }

    public int UserId { get; set; }

    public string Email { get; set; } = string.Empty;

    public string NoteTitle { get; set; } = string.Empty;

    public DateTime ReminderTime { get; set; }
}