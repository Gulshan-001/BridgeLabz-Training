using Business.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.DTO;
using Models.Entity;
using Moq;
using Repository.Interface;

namespace FundooTests;

[TestClass]
public class UserServiceTests
{
    private Mock<IUserRepository> _userRepositoryMock = null!;
    private Mock<IConfiguration> _configurationMock = null!;
    private UserService _userService = null!;

    [TestInitialize]
    public void Setup()
    {
        _userRepositoryMock = new Mock<IUserRepository>();

        var configurationData = new Dictionary<string, string?>
        {
            { "Jwt:Key", "ThisIsASuperSecretKeyForFundooApplication12345" },
            { "Jwt:Issuer", "FundooApp" },
            { "Jwt:Audience", "FundooUsers" },
            { "Jwt:ExpiryMinutes", "60" }
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(configurationData)
            .Build();

        _configurationMock = new Mock<IConfiguration>();

        _userService = new UserService(
            _userRepositoryMock.Object,
            configuration);
    }

    [TestMethod]
    public async Task RegisterUserAsync_WhenEmailDoesNotExist_ShouldReturnTrue()
    {
        // Arrange
        var request = new RegisterRequestDTO
        {
            FirstName = "Gulshan",
            LastName = "Thakur",
            Email = "gulshan@test.com",
            Password = "Password123"
        };

        _userRepositoryMock
            .Setup(repository =>
                repository.GetUserByEmailAsync(request.Email))
            .ReturnsAsync((User?)null);

        _userRepositoryMock
            .Setup(repository =>
                repository.AddUserAsync(It.IsAny<User>()))
            .ReturnsAsync((User user) => user);

        // Act
        var result = await _userService.RegisterUserAsync(request);

        // Assert
        Assert.IsTrue(result);

        _userRepositoryMock.Verify(
            repository =>
                repository.GetUserByEmailAsync(request.Email),
            Times.Once);

        _userRepositoryMock.Verify(
            repository =>
                repository.AddUserAsync(
                    It.Is<User>(user =>
                        user.FirstName == request.FirstName &&
                        user.LastName == request.LastName &&
                        user.Email == request.Email &&
                        !string.IsNullOrEmpty(user.PasswordHash))),
            Times.Once);
    }

    [TestMethod]
    public async Task RegisterUserAsync_WhenEmailAlreadyExists_ShouldReturnFalse()
    {
        // Arrange
        var request = new RegisterRequestDTO
        {
            FirstName = "Gulshan",
            LastName = "Thakur",
            Email = "gulshan@test.com",
            Password = "Password123"
        };

        var existingUser = new User
        {
            Id = 1,
            FirstName = "Gulshan",
            LastName = "Thakur",
            Email = request.Email,
            PasswordHash = "ExistingHash"
        };

        _userRepositoryMock
            .Setup(repository =>
                repository.GetUserByEmailAsync(request.Email))
            .ReturnsAsync(existingUser);

        // Act
        var result = await _userService.RegisterUserAsync(request);

        // Assert
        Assert.IsFalse(result);

        _userRepositoryMock.Verify(
            repository =>
                repository.AddUserAsync(It.IsAny<User>()),
            Times.Never);
    }

    [TestMethod]
    public async Task LoginUserAsync_WhenUserDoesNotExist_ShouldReturnNull()
    {
        // Arrange
        var request = new LoginRequestDTO
        {
            Email = "unknown@test.com",
            Password = "Password123"
        };

        _userRepositoryMock
            .Setup(repository =>
                repository.GetUserByEmailAsync(request.Email))
            .ReturnsAsync((User?)null);

        // Act
        var result = await _userService.LoginUserAsync(request);

        // Assert
        Assert.IsNull(result);

        _userRepositoryMock.Verify(
            repository =>
                repository.GetUserByEmailAsync(request.Email),
            Times.Once);
    }

    [TestMethod]
public async Task LoginUserAsync_WhenPasswordIsIncorrect_ShouldReturnNull()
{
    // Arrange

    var passwordHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();

    var user = new User
    {
        Id = 1,
        FirstName = "Gulshan",
        LastName = "Thakur",
        Email = "gulshan@test.com"
    };

    // Create a REAL valid password hash
    user.PasswordHash = passwordHasher
        .HashPassword(user, "CorrectPassword123");

    var request = new LoginRequestDTO
    {
        Email = user.Email,
        Password = "WrongPassword123"
    };

    _userRepositoryMock
        .Setup(repository =>
            repository.GetUserByEmailAsync(request.Email))
        .ReturnsAsync(user);

    // Act

    var result = await _userService.LoginUserAsync(request);

    // Assert

    Assert.IsNull(result);

    _userRepositoryMock.Verify(
        repository =>
            repository.GetUserByEmailAsync(request.Email),
        Times.Once);
}

    [TestMethod]
    public async Task LoginUserAsync_WhenCredentialsAreValid_ShouldReturnAuthResponse()
    {
        // Arrange
        var passwordHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();

        var user = new User
        {
            Id = 1,
            FirstName = "Gulshan",
            LastName = "Thakur",
            Email = "gulshan@test.com"
        };

        user.PasswordHash = passwordHasher
            .HashPassword(user, "Password123");

        var request = new LoginRequestDTO
        {
            Email = user.Email,
            Password = "Password123"
        };

        _userRepositoryMock
            .Setup(repository =>
                repository.GetUserByEmailAsync(request.Email))
            .ReturnsAsync(user);

        // Act
        var result = await _userService.LoginUserAsync(request);

        // Assert
        Assert.IsNotNull(result);

        Assert.AreEqual(user.Id, result.UserId);
        Assert.AreEqual(user.FirstName, result.FirstName);
        Assert.AreEqual(user.LastName, result.LastName);
        Assert.AreEqual(user.Email, result.Email);

        Assert.IsFalse(string.IsNullOrEmpty(result.Token));

        _userRepositoryMock.Verify(
            repository =>
                repository.GetUserByEmailAsync(request.Email),
            Times.Once);
    }
}