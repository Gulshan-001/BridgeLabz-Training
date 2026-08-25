using System.ComponentModel.DataAnnotations;

namespace Models.Entity;

public class Label
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int UserId { get; set; }

    public User User { get; set; } = null!;
    public ICollection<NoteLabel> NoteLabels { get; set; } = new List<NoteLabel>();
}