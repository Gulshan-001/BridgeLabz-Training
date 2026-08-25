using System.ComponentModel.DataAnnotations;

namespace Models.Entity;

public class NoteLabel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int NoteId { get; set; }

    [Required]
    public int LabelId { get; set; }

    public Note Note { get; set; } = null!;

    public Label Label { get; set; } = null!;
}