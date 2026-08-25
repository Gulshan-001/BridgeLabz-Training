using Business.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.DTO;
using Models.Entity;
using Moq;
using Repository.Interface;

namespace FundooTests;

[TestClass]
public class NoteServiceTests
{
    private Mock<INoteRepository> _noteRepositoryMock = null!;
    private Mock<ILabelRepository> _labelRepositoryMock = null!;
    private NoteService _noteService = null!;

    [TestInitialize]
    public void Setup()
    {
        _noteRepositoryMock = new Mock<INoteRepository>();
        _labelRepositoryMock = new Mock<ILabelRepository>();

        _noteService = new NoteService(
            _noteRepositoryMock.Object,
            _labelRepositoryMock.Object);
    }

    [TestMethod]
    public async Task CreateNoteAsync_ShouldCreateAndReturnNote()
    {
        // Arrange
        var request = new CreateNoteRequestDTO
        {
            Title = "Test Note",
            Content = "This is a test note."
        };

        var userId = 1;

        var note = new Note
        {
            Id = 1,
            Title = request.Title,
            Content = request.Content,
            UserId = userId
        };

        _noteRepositoryMock
            .Setup(repository =>
                repository.CreateNoteAsync(It.IsAny<Note>()))
            .ReturnsAsync(note);

        // Act
        var result = await _noteService
            .CreateNoteAsync(request, userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(note.Id, result.Id);
        Assert.AreEqual(request.Title, result.Title);
        Assert.AreEqual(request.Content, result.Content);

        _noteRepositoryMock.Verify(
            repository =>
                repository.CreateNoteAsync(
                    It.Is<Note>(n =>
                        n.Title == request.Title &&
                        n.Content == request.Content &&
                        n.UserId == userId)),
            Times.Once);
    }

    [TestMethod]
    public async Task GetNoteByIdAsync_WhenNoteExists_ShouldReturnNote()
    {
        // Arrange
        var note = new Note
        {
            Id = 1,
            Title = "Test Note",
            Content = "Test Content",
            UserId = 1
        };

        _noteRepositoryMock
            .Setup(repository =>
                repository.GetNoteByIdAsync(1, 1))
            .ReturnsAsync(note);

        // Act
        var result = await _noteService
            .GetNoteByIdAsync(1, 1);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(note.Id, result.Id);
        Assert.AreEqual(note.Title, result.Title);
        Assert.AreEqual(note.Content, result.Content);

        _noteRepositoryMock.Verify(
            repository =>
                repository.GetNoteByIdAsync(1, 1),
            Times.Once);
    }

    [TestMethod]
    public async Task GetNoteByIdAsync_WhenNoteDoesNotExist_ShouldReturnNull()
    {
        // Arrange
        _noteRepositoryMock
            .Setup(repository =>
                repository.GetNoteByIdAsync(99, 1))
            .ReturnsAsync((Note?)null);

        // Act
        var result = await _noteService
            .GetNoteByIdAsync(99, 1);

        // Assert
        Assert.IsNull(result);

        _noteRepositoryMock.Verify(
            repository =>
                repository.GetNoteByIdAsync(99, 1),
            Times.Once);
    }

    [TestMethod]
    public async Task PinNoteAsync_WhenNoteExists_ShouldReturnPinnedNote()
    {
        // Arrange
        var noteId = 1;
        var userId = 1;

        var pinnedNote = new Note
        {
            Id = noteId,
            Title = "Test Note",
            Content = "Test Content",
            UserId = userId,
            IsPinned = true
        };

        _noteRepositoryMock
            .Setup(repository =>
                repository.PinNoteAsync(noteId, userId))
            .ReturnsAsync(pinnedNote);

        // Act
        var result = await _noteService
            .PinNoteAsync(noteId, userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(noteId, result.Id);
        Assert.AreEqual("Test Note", result.Title);

        _noteRepositoryMock.Verify(
            repository =>
                repository.PinNoteAsync(noteId, userId),
            Times.Once);
    }

    [TestMethod]
    public async Task PinNoteAsync_WhenNoteDoesNotExist_ShouldReturnNull()
    {
        // Arrange
        var noteId = 99;
        var userId = 1;

        _noteRepositoryMock
            .Setup(repository =>
                repository.PinNoteAsync(noteId, userId))
            .ReturnsAsync((Note?)null);

        // Act
        var result = await _noteService
            .PinNoteAsync(noteId, userId);

        // Assert
        Assert.IsNull(result);

        _noteRepositoryMock.Verify(
            repository =>
                repository.PinNoteAsync(noteId, userId),
            Times.Once);
    }

    [TestMethod]
    public async Task ArchiveNoteAsync_WhenNoteExists_ShouldReturnArchivedNote()
    {
        // Arrange
        var noteId = 1;
        var userId = 1;

        var archivedNote = new Note
        {
            Id = noteId,
            Title = "Archived Note",
            Content = "Test Content",
            UserId = userId,
            IsArchived = true
        };

        _noteRepositoryMock
            .Setup(repository =>
                repository.ArchiveNoteAsync(noteId, userId))
            .ReturnsAsync(archivedNote);

        // Act
        var result = await _noteService
            .ArchiveNoteAsync(noteId, userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(noteId, result.Id);
        Assert.AreEqual("Archived Note", result.Title);

        _noteRepositoryMock.Verify(
            repository =>
                repository.ArchiveNoteAsync(noteId, userId),
            Times.Once);
    }

    [TestMethod]
    public async Task ArchiveNoteAsync_WhenNoteDoesNotExist_ShouldReturnNull()
    {
        // Arrange
        var noteId = 99;
        var userId = 1;

        _noteRepositoryMock
            .Setup(repository =>
                repository.ArchiveNoteAsync(noteId, userId))
            .ReturnsAsync((Note?)null);

        // Act
        var result = await _noteService
            .ArchiveNoteAsync(noteId, userId);

        // Assert
        Assert.IsNull(result);

        _noteRepositoryMock.Verify(
            repository =>
                repository.ArchiveNoteAsync(noteId, userId),
            Times.Once);
    }

    [TestMethod]
    public async Task DeleteNoteAsync_WhenNoteExists_ShouldReturnTrue()
    {
        // Arrange
        var noteId = 1;
        var userId = 1;

        _noteRepositoryMock
            .Setup(repository =>
                repository.DeleteNoteAsync(noteId, userId))
            .ReturnsAsync(true);

        // Act
        var result = await _noteService
            .DeleteNoteAsync(noteId, userId);

        // Assert
        Assert.IsTrue(result);

        _noteRepositoryMock.Verify(
            repository =>
                repository.DeleteNoteAsync(noteId, userId),
            Times.Once);
    }

    [TestMethod]
    public async Task DeleteNoteAsync_WhenNoteDoesNotExist_ShouldReturnFalse()
    {
        // Arrange
        var noteId = 99;
        var userId = 1;

        _noteRepositoryMock
            .Setup(repository =>
                repository.DeleteNoteAsync(noteId, userId))
            .ReturnsAsync(false);

        // Act
        var result = await _noteService
            .DeleteNoteAsync(noteId, userId);

        // Assert
        Assert.IsFalse(result);

        _noteRepositoryMock.Verify(
            repository =>
                repository.DeleteNoteAsync(noteId, userId),
            Times.Once);
    }

    [TestMethod]
    public async Task SearchNotesAsync_WhenNotesExist_ShouldReturnMatchingNotes()
    {
        // Arrange
        var title = "Fundoo";
        var userId = 1;

        var notes = new List<Note>
        {
            new Note
            {
                Id = 1,
                Title = "Fundoo Project",
                Content = "Backend development",
                UserId = userId
            },
            new Note
            {
                Id = 2,
                Title = "Fundoo Testing",
                Content = "MSTest implementation",
                UserId = userId
            }
        };

        _noteRepositoryMock
            .Setup(repository =>
                repository.SearchNotesAsync(title, userId))
            .ReturnsAsync(notes);

        // Act
        var result = await _noteService
            .SearchNotesAsync(title, userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);

        _noteRepositoryMock.Verify(
            repository =>
                repository.SearchNotesAsync(title, userId),
            Times.Once);
    }

    [TestMethod]
    public async Task SearchNotesAsync_WhenNoNotesExist_ShouldReturnEmptyList()
    {
        // Arrange
        var title = "NonExistingNote";
        var userId = 1;

        _noteRepositoryMock
            .Setup(repository =>
                repository.SearchNotesAsync(title, userId))
            .ReturnsAsync(new List<Note>());

        // Act
        var result = await _noteService
            .SearchNotesAsync(title, userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);

        _noteRepositoryMock.Verify(
            repository =>
                repository.SearchNotesAsync(title, userId),
            Times.Once);
    }

    [TestMethod]
    public async Task AddLabelToNoteAsync_WhenNoteAndLabelExist_ShouldReturnTrue()
    {
        // Arrange
        var noteId = 1;
        var labelId = 1;
        var userId = 1;

        var note = new Note
        {
            Id = noteId,
            Title = "Fundoo Project",
            Content = "Test Content",
            UserId = userId
        };

        var label = new Label
        {
            Id = labelId,
            Name = "Work",
            UserId = userId
        };

        _noteRepositoryMock
            .Setup(repository =>
                repository.GetNoteByIdAsync(noteId, userId))
            .ReturnsAsync(note);

        _labelRepositoryMock
            .Setup(repository =>
                repository.GetLabelByIdAsync(labelId, userId))
            .ReturnsAsync(label);

        _noteRepositoryMock
            .Setup(repository =>
                repository.AddLabelToNoteAsync(It.IsAny<NoteLabel>()))
            .ReturnsAsync(new NoteLabel
            {
                Id = 1,
                NoteId = noteId,
                LabelId = labelId
            });

        // Act
        var result = await _noteService
            .AddLabelToNoteAsync(noteId, labelId, userId);

        // Assert
        Assert.IsTrue(result);

        _noteRepositoryMock.Verify(
            repository =>
                repository.AddLabelToNoteAsync(
                    It.Is<NoteLabel>(nl =>
                        nl.NoteId == noteId &&
                        nl.LabelId == labelId)),
            Times.Once);
    }

    [TestMethod]
    public async Task AddLabelToNoteAsync_WhenNoteDoesNotExist_ShouldReturnFalse()
    {
        // Arrange
        var noteId = 99;
        var labelId = 1;
        var userId = 1;

        _noteRepositoryMock
            .Setup(repository =>
                repository.GetNoteByIdAsync(noteId, userId))
            .ReturnsAsync((Note?)null);

        // Act
        var result = await _noteService
            .AddLabelToNoteAsync(noteId, labelId, userId);

        // Assert
        Assert.IsFalse(result);

        _labelRepositoryMock.Verify(
            repository =>
                repository.GetLabelByIdAsync(
                    It.IsAny<int>(),
                    It.IsAny<int>()),
            Times.Never);

        _noteRepositoryMock.Verify(
            repository =>
                repository.AddLabelToNoteAsync(
                    It.IsAny<NoteLabel>()),
            Times.Never);
    }

    [TestMethod]
    public async Task AddLabelToNoteAsync_WhenLabelDoesNotExist_ShouldReturnFalse()
    {
        // Arrange
        var noteId = 1;
        var labelId = 99;
        var userId = 1;

        var note = new Note
        {
            Id = noteId,
            Title = "Test Note",
            Content = "Test Content",
            UserId = userId
        };

        _noteRepositoryMock
            .Setup(repository =>
                repository.GetNoteByIdAsync(noteId, userId))
            .ReturnsAsync(note);

        _labelRepositoryMock
            .Setup(repository =>
                repository.GetLabelByIdAsync(labelId, userId))
            .ReturnsAsync((Label?)null);

        // Act
        var result = await _noteService
            .AddLabelToNoteAsync(noteId, labelId, userId);

        // Assert
        Assert.IsFalse(result);

        _noteRepositoryMock.Verify(
            repository =>
                repository.AddLabelToNoteAsync(
                    It.IsAny<NoteLabel>()),
            Times.Never);
    }

    [TestMethod]
    public async Task RemoveLabelFromNoteAsync_WhenAssociationExists_ShouldReturnTrue()
    {
        // Arrange
        var noteId = 1;
        var labelId = 1;
        var userId = 1;

        _noteRepositoryMock
            .Setup(repository =>
                repository.RemoveLabelFromNoteAsync(
                    noteId,
                    labelId,
                    userId))
            .ReturnsAsync(true);

        // Act
        var result = await _noteService
            .RemoveLabelFromNoteAsync(
                noteId,
                labelId,
                userId);

        // Assert
        Assert.IsTrue(result);

        _noteRepositoryMock.Verify(
            repository =>
                repository.RemoveLabelFromNoteAsync(
                    noteId,
                    labelId,
                    userId),
            Times.Once);
    }

    [TestMethod]
    public async Task RemoveLabelFromNoteAsync_WhenAssociationDoesNotExist_ShouldReturnFalse()
    {
        // Arrange
        var noteId = 1;
        var labelId = 99;
        var userId = 1;

        _noteRepositoryMock
            .Setup(repository =>
                repository.RemoveLabelFromNoteAsync(
                    noteId,
                    labelId,
                    userId))
            .ReturnsAsync(false);

        // Act
        var result = await _noteService
            .RemoveLabelFromNoteAsync(
                noteId,
                labelId,
                userId);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public async Task GetLabelsByNoteIdAsync_WhenLabelsExist_ShouldReturnLabels()
    {
        // Arrange
        var noteId = 1;
        var userId = 1;

        var labels = new List<Label>
        {
            new Label
            {
                Id = 1,
                Name = "Work",
                UserId = userId
            },
            new Label
            {
                Id = 2,
                Name = "College",
                UserId = userId
            }
        };

        _noteRepositoryMock
            .Setup(repository =>
                repository.GetLabelsByNoteIdAsync(noteId, userId))
            .ReturnsAsync(labels);

        // Act
        var result = await _noteService
            .GetLabelsByNoteIdAsync(noteId, userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Work", result[0].Name);
        Assert.AreEqual("College", result[1].Name);
    }

    [TestMethod]
    public async Task GetNotesByLabelIdAsync_WhenNotesExist_ShouldReturnNotes()
    {
        // Arrange
        var labelId = 1;
        var userId = 1;

        var notes = new List<Note>
        {
            new Note
            {
                Id = 1,
                Title = "Fundoo Project",
                Content = "Test Content",
                UserId = userId
            },
            new Note
            {
                Id = 2,
                Title = "Testing",
                Content = "MSTest",
                UserId = userId
            }
        };

        _noteRepositoryMock
            .Setup(repository =>
                repository.GetNotesByLabelIdAsync(labelId, userId))
            .ReturnsAsync(notes);

        // Act
        var result = await _noteService
            .GetNotesByLabelIdAsync(labelId, userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Fundoo Project", result[0].Title);
        Assert.AreEqual("Testing", result[1].Title);
    }
}