using Castle.Core.Logging;
using Moq;
using QuizDuel.Core.DTO;
using QuizDuel.Core.Interfaces;
using QuizDuel.Core.Services;
using QuizDuel.DataAccess.Interfaces;
using QuizDuel.DataAccess.Models;

[TestClass]
public class AuthServiceTests
{
    private Mock<IRegisterValidator> _registerValidatorMock;
    private Mock<IUserRepository> _userRepositoryMock;
    private Mock<IPasswordService> _passwordServiceMock;
    private Mock<ILogger> _loggerMock;
    private Mock<IUserSessionService> _sessionMock;
    private AuthService _authService;

    [TestInitialize]
    public void Setup()
    {
        _registerValidatorMock = new Mock<IRegisterValidator>();
        _userRepositoryMock = new Mock<IUserRepository>();
        _passwordServiceMock = new Mock<IPasswordService>();
        _loggerMock = new Mock<ILogger>();
        _sessionMock = new Mock<IUserSessionService>();

        _authService = new AuthService(
            _registerValidatorMock.Object,
            _userRepositoryMock.Object,
            _passwordServiceMock.Object,
            _loggerMock.Object,
            _sessionMock.Object);
    }

    [TestMethod]
    public async Task LoginAsync_EmptyUsername_ReturnsError()
    {
        var dto = new LoginDTO { Username = "", Password = "123" };

        var result = await _authService.LoginAsync(dto);

        Assert.IsFalse(result.Success);
        CollectionAssert.Contains(result.MessageKeys, "Login.EmptyUsername");
    }

    [TestMethod]
    public async Task LoginAsync_NonExistingUser_ReturnsError()
    {
        var dto = new LoginDTO { Username = "user", Password = "123" };
        _userRepositoryMock.Setup(r => r.GetByUsername("user"))
                           .ReturnsAsync((User)null);

        var result = await _authService.LoginAsync(dto);

        Assert.IsFalse(result.Success);
        CollectionAssert.Contains(result.MessageKeys, "Login.NonExistingUser");
    }

    [TestMethod]
    public async Task LoginAsync_WrongPassword_ReturnsError()
    {
        var dto = new LoginDTO { Username = "user", Password = "wrong" };
        var user = new User { Username = "user", PasswordHash = "hashed", Salt = "salt" };

        _userRepositoryMock.Setup(r => r.GetByUsername("user"))
                           .ReturnsAsync(user);
        _passwordServiceMock.Setup(p => p.HashPassword("wrong", "salt"))
                            .Returns("incorrect");

        var result = await _authService.LoginAsync(dto);

        Assert.IsFalse(result.Success);
        CollectionAssert.Contains(result.MessageKeys, "Login.WrongPassword");
    }

    [TestMethod]
    public async Task LoginAsync_CorrectCredentials_ReturnsSuccess()
    {
        var dto = new LoginDTO { Username = "user", Password = "pass" };
        var user = new User { Id = Guid.NewGuid(), Username = "user", Salt = "salt", PasswordHash = "hash" };

        _userRepositoryMock.Setup(r => r.GetByUsername("user"))
                           .ReturnsAsync(user);
        _passwordServiceMock.Setup(p => p.HashPassword("pass", "salt"))
                            .Returns("hash");

        var result = await _authService.LoginAsync(dto);

        Assert.IsTrue(result.Success);
    }

    [TestMethod]
    public async Task RegisterAsync_InvalidInput_ReturnsValidationErrors()
    {
        var dto = new RegisterDTO { Username = "bad" };
        var errors = new List<string> { "Username.TooShort" };

        _registerValidatorMock.Setup(v => v.ValidateInput(dto, out errors))
                              .Returns(false);

        var result = await _authService.RegisterAsync(dto);

        Assert.IsFalse(result.Success);
        CollectionAssert.Contains(result.MessageKeys, "Username.TooShort");
    }

    [TestMethod]
    public async Task RegisterAsync_ExistingUser_ReturnsError()
    {
        var registerDto = new RegisterDTO
        {
            Username = "existingUser",
            Password = "Password123",
            Birthdate = DateTime.UtcNow.AddYears(-20)
        };

        var errorMessages = new List<string>();
        _registerValidatorMock
            .Setup(v => v.ValidateInput(registerDto, out errorMessages))
            .Returns(true);

        _userRepositoryMock
            .Setup(r => r.IsUserExistsByUsername(registerDto.Username))
            .ReturnsAsync(true);

        var result = await _authService.RegisterAsync(registerDto);

        Assert.IsFalse(result.Success);
        CollectionAssert.Contains(result.MessageKeys, "Register.ExistingUser");
    }


    [TestMethod]
    public async Task RegisterAsync_ValidInput_ReturnsSuccess()
    {
        var registerDto = new RegisterDTO
        {
            Username = "newUser",
            Password = "SecurePass123",
            Birthdate = new DateTime(2000, 1, 1)
        };

        var errorMessages = new List<string>();
        _registerValidatorMock
            .Setup(v => v.ValidateInput(registerDto, out errorMessages))
            .Returns(true);

        _userRepositoryMock
            .Setup(r => r.IsUserExistsByUsername(registerDto.Username))
            .ReturnsAsync(false);

        _passwordServiceMock
            .Setup(p => p.GenerateSalt())
            .Returns("mock_salt");

        _passwordServiceMock
            .Setup(p => p.HashPassword(registerDto.Password, "mock_salt"))
            .Returns("mock_hash");

        _userRepositoryMock
            .Setup(r => r.AddUser(It.IsAny<User>()))
            .Returns(Task.CompletedTask);

        var result = await _authService.RegisterAsync(registerDto);

        Assert.IsTrue(result.Success);
        Assert.AreEqual(0, result.MessageKeys.Count);
    }
}