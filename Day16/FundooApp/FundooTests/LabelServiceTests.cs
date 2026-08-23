using Business.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.DTO;
using Models.Entity;
using Moq;
using Repository.Interface;

namespace FundooTests;

[TestClass]
public class LabelServiceTests
{
    private Mock<ILabelRepository> _labelRepositoryMock = null!;
    private LabelService _labelService = null!;

    [TestInitialize]
    public void Setup()
    {
        _labelRepositoryMock = new Mock<ILabelRepository>();

        _labelService = new LabelService(
            _labelRepositoryMock.Object);
    }

    [TestMethod]
    public async Task CreateLabelAsync_ShouldCreateAndReturnLabel()
    {
        // Arrange
        var request = new CreateLabelRequestDTO
        {
            Name = "Work"
        };

        var userId = 1;

        var label = new Label
        {
            Id = 1,
            Name = request.Name,
            UserId = userId
        };

        _labelRepositoryMock
            .Setup(repository =>
                repository.CreateLabelAsync(It.IsAny<Label>()))
            .ReturnsAsync(label);

        // Act
        var result = await _labelService
            .CreateLabelAsync(request, userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(label.Id, result.Id);
        Assert.AreEqual(request.Name, result.Name);

        _labelRepositoryMock.Verify(
            repository =>
                repository.CreateLabelAsync(
                    It.Is<Label>(label =>
                        label.Name == request.Name &&
                        label.UserId == userId)),
            Times.Once);
    }

    [TestMethod]
    public async Task GetLabelByIdAsync_WhenLabelExists_ShouldReturnLabel()
    {
        // Arrange
        var label = new Label
        {
            Id = 1,
            Name = "Work",
            UserId = 1
        };

        _labelRepositoryMock
            .Setup(repository =>
                repository.GetLabelByIdAsync(1, 1))
            .ReturnsAsync(label);

        // Act
        var result = await _labelService
            .GetLabelByIdAsync(1, 1);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(label.Id, result.Id);
        Assert.AreEqual(label.Name, result.Name);

        _labelRepositoryMock.Verify(
            repository =>
                repository.GetLabelByIdAsync(1, 1),
            Times.Once);
    }

    [TestMethod]
    public async Task GetLabelByIdAsync_WhenLabelDoesNotExist_ShouldReturnNull()
    {
        // Arrange
        _labelRepositoryMock
            .Setup(repository =>
                repository.GetLabelByIdAsync(99, 1))
            .ReturnsAsync((Label?)null);

        // Act
        var result = await _labelService
            .GetLabelByIdAsync(99, 1);

        // Assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public async Task GetAllLabelsAsync_WhenLabelsExist_ShouldReturnAllLabels()
    {
        // Arrange
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
                Name = "Personal",
                UserId = userId
            }
        };

        _labelRepositoryMock
            .Setup(repository =>
                repository.GetAllLabelsAsync(userId))
            .ReturnsAsync(labels);

        // Act
        var result = await _labelService
            .GetAllLabelsAsync(userId);

        // Assert
        Assert.HasCount(2, result);
        Assert.AreEqual("Work", result[0].Name);
        Assert.AreEqual("Personal", result[1].Name);

        _labelRepositoryMock.Verify(
            repository =>
                repository.GetAllLabelsAsync(userId),
            Times.Once);
    }

    [TestMethod]
    public async Task GetAllLabelsAsync_WhenNoLabelsExist_ShouldReturnEmptyList()
    {
        // Arrange
        var userId = 1;

        _labelRepositoryMock
            .Setup(repository =>
                repository.GetAllLabelsAsync(userId))
            .ReturnsAsync(new List<Label>());

        // Act
        var result = await _labelService
            .GetAllLabelsAsync(userId);

        // Assert
        Assert.IsEmpty(result);
    }

    [TestMethod]
    public async Task UpdateLabelAsync_WhenLabelExists_ShouldReturnUpdatedLabel()
    {
        // Arrange
        var labelId = 1;
        var userId = 1;

        var request = new UpdateLabelRequestDTO
        {
            Name = "Updated Work"
        };

        var updatedLabel = new Label
        {
            Id = labelId,
            Name = request.Name,
            UserId = userId
        };

        _labelRepositoryMock
            .Setup(repository =>
                repository.UpdateLabelAsync(It.IsAny<Label>()))
            .ReturnsAsync(updatedLabel);

        // Act
        var result = await _labelService
            .UpdateLabelAsync(labelId, request, userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(labelId, result.Id);
        Assert.AreEqual(request.Name, result.Name);

        _labelRepositoryMock.Verify(
            repository =>
                repository.UpdateLabelAsync(
                    It.Is<Label>(label =>
                        label.Id == labelId &&
                        label.Name == request.Name &&
                        label.UserId == userId)),
            Times.Once);
    }

    [TestMethod]
    public async Task UpdateLabelAsync_WhenLabelDoesNotExist_ShouldReturnNull()
    {
        // Arrange
        var labelId = 99;
        var userId = 1;

        var request = new UpdateLabelRequestDTO
        {
            Name = "Updated Label"
        };

        _labelRepositoryMock
            .Setup(repository =>
                repository.UpdateLabelAsync(It.IsAny<Label>()))
            .ReturnsAsync((Label?)null);

        // Act
        var result = await _labelService
            .UpdateLabelAsync(labelId, request, userId);

        // Assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public async Task DeleteLabelAsync_WhenLabelExists_ShouldReturnTrue()
    {
        // Arrange
        var labelId = 1;
        var userId = 1;

        _labelRepositoryMock
            .Setup(repository =>
                repository.DeleteLabelAsync(labelId, userId))
            .ReturnsAsync(true);

        // Act
        var result = await _labelService
            .DeleteLabelAsync(labelId, userId);

        // Assert
        Assert.IsTrue(result);

        _labelRepositoryMock.Verify(
            repository =>
                repository.DeleteLabelAsync(labelId, userId),
            Times.Once);
    }

    [TestMethod]
    public async Task DeleteLabelAsync_WhenLabelDoesNotExist_ShouldReturnFalse()
    {
        // Arrange
        var labelId = 99;
        var userId = 1;

        _labelRepositoryMock
            .Setup(repository =>
                repository.DeleteLabelAsync(labelId, userId))
            .ReturnsAsync(false);

        // Act
        var result = await _labelService
            .DeleteLabelAsync(labelId, userId);

        // Assert
        Assert.IsFalse(result);
    }
}