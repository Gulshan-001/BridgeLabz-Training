using Microsoft.EntityFrameworkCore;
using Models.Entity;

namespace Repository.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Note> Notes { get; set; }

    public DbSet<Label> Labels { get; set; }
    public DbSet<NoteLabel> NoteLabels { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<NoteLabel>()
        .HasOne(noteLabel => noteLabel.Note)
        .WithMany(note => note.NoteLabels)
        .HasForeignKey(noteLabel => noteLabel.NoteId)
        .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<NoteLabel>()
        .HasOne(noteLabel => noteLabel.Label)
        .WithMany(label => label.NoteLabels)
        .HasForeignKey(noteLabel => noteLabel.LabelId)
        .OnDelete(DeleteBehavior.NoAction);
}
}