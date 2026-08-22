using System.ComponentModel.DataAnnotations;

namespace Models.Entity;

public class Note
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    [Required]
    public int UserId { get; set; }

    public bool IsPinned { get; set; } = false;

    public bool IsArchived { get; set; } = false;

    public bool IsDeleted { get; set; } = false;

    public User User { get; set; } = null!;
    public ICollection<NoteLabel> NoteLabels { get; set; } = new List<NoteLabel>();
}