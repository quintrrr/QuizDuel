using Moq;
using Castle.Core.Logging;
using QuizDuel.Core.DTO;
using QuizDuel.Core.Interfaces;
using QuizDuel.Core.Services;

[TestClass]
public class RegisterValidatorTests
{
    private Mock<IPasswordValidator> _passwordValidatorMock;
    private Mock<ILogger> _loggerMock;
    private RegisterValidator _registerValidator;

    [TestInitialize]
    public void Setup()
    {
        _passwordValidatorMock = new Mock<IPasswordValidator>();
        _loggerMock = new Mock<ILogger>();
        _registerValidator = new RegisterValidator(_passwordValidatorMock.Object, _loggerMock.Object);
    }

    [TestMethod]
    public void ValidateInput_EmptyUsername_ReturnsFalse()
    {
        var dto = new RegisterDTO
        {
            Username = " ",
            Password = "Password123",
            RepeatPassword = "Password123",
            Birthdate = DateTime.UtcNow.AddYears(-20)
        };

        var result = _registerValidator.ValidateInput(dto, out var errors);

        Assert.IsFalse(result);
        CollectionAssert.Contains(errors, "Register.EmptyUsername");
    }

    [TestMethod]
    public void ValidateInput_EmptyPassword_ReturnsFalse()
    {
        var dto = new RegisterDTO
        {
            Username = "user",
            Password = " ",
            RepeatPassword = "Password123",
            Birthdate = DateTime.UtcNow.AddYears(-20)
        };

        var result = _registerValidator.ValidateInput(dto, out var errors);

        Assert.IsFalse(result);
        CollectionAssert.Contains(errors, "Register.EmptyPassword");
    }

    [TestMethod]
    public void ValidateInput_EmptyRepeatPassword_ReturnsFalse()
    {
        var dto = new RegisterDTO
        {
            Username = "user",
            Password = "Password123",
            RepeatPassword = " ",
            Birthdate = DateTime.UtcNow.AddYears(-20)
        };

        var result = _registerValidator.ValidateInput(dto, out var errors);

        Assert.IsFalse(result);
        CollectionAssert.Contains(errors, "Register.EmptyRepeatPassword");
    }

    [TestMethod]
    public void ValidateInput_InvalidAge_ReturnsFalse()
    {
        var dto = new RegisterDTO
        {
            Username = "user",
            Password = "Password123",
            RepeatPassword = "Password123",
            Birthdate = DateTime.UtcNow.AddYears(-2)
        };

        var result = _registerValidator.ValidateInput(dto, out var errors);

        Assert.IsFalse(result);
        CollectionAssert.Contains(errors, "Register.InvalidAge");
    }

    [TestMethod]
    public void ValidateInput_PasswordMismatch_ReturnsFalse()
    {
        var dto = new RegisterDTO
        {
            Username = "user",
            Password = "Password123",
            RepeatPassword = "Password321",
            Birthdate = DateTime.UtcNow.AddYears(-20)
        };

        var result = _registerValidator.ValidateInput(dto, out var errors);

        Assert.IsFalse(result);
        CollectionAssert.Contains(errors, "Register.InvalidRepeatPassword");
    }

    [TestMethod]
    public void ValidateInput_InvalidPassword_ReturnsFalse()
    {
        var dto = new RegisterDTO
        {
            Username = "user",
            Password = "short",
            RepeatPassword = "short",
            Birthdate = DateTime.UtcNow.AddYears(-20)
        };

        _passwordValidatorMock
            .Setup(p => p.ValidatePassword(dto.Password, out It.Ref<List<string>>.IsAny))
            .Callback((string password, out List<string> errors) =>
            {
                errors = new List<string> { "Password.TooShort" };
            })
            .Returns(false);

        var result = _registerValidator.ValidateInput(dto, out var errors);

        Assert.IsFalse(result);
        CollectionAssert.Contains(errors, "Password.TooShort");
    }

    [TestMethod]
    public void ValidateInput_ValidData_ReturnsTrue()
    {
        var dto = new RegisterDTO
        {
            Username = "validuser",
            Password = "ValidPassword123!",
            RepeatPassword = "ValidPassword123!",
            Birthdate = DateTime.UtcNow.AddYears(-25)
        };

        _passwordValidatorMock
            .Setup(p => p.ValidatePassword(dto.Password, out It.Ref<List<string>>.IsAny))
            .Callback((string password, out List<string> errors) =>
            {
                errors = new List<string>();
            })
            .Returns(true);

        var result = _registerValidator.ValidateInput(dto, out var errors);

        Assert.IsTrue(result);
        Assert.AreEqual(0, errors.Count);
    }
}
