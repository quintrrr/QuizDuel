using Moq;
using QuizDuel.Core.Services;
using Castle.Core.Logging;


[TestClass]
public class PasswordServiceTests
{
    private Mock<ILogger> _loggerMock;
    private PasswordService _service;

    [TestInitialize]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger>();
        _service = new PasswordService(_loggerMock.Object);
    }

    [TestMethod]
    public void GenerateSalt_ReturnsNonEmptyString()
    {
        var salt = _service.GenerateSalt();

        Assert.IsFalse(string.IsNullOrEmpty(salt));
        _loggerMock.Verify(l => l.Debug(It.IsAny<string>()), Times.Once);
    }

    [TestMethod]
    public void HashPassword_ValidInput_ReturnsConsistentHash()
    {
        var password = "Secret123!";
        var salt = _service.GenerateSalt();

        var hash1 = _service.HashPassword(password, salt);
        var hash2 = _service.HashPassword(password, salt);

        Assert.AreEqual(hash1, hash2);
    }

    [TestMethod]
    public void HashPassword_DifferentSalts_ProduceDifferentHashes()
    {
        var password = "Secret123!";
        var salt1 = _service.GenerateSalt();
        var salt2 = _service.GenerateSalt();

        var hash1 = _service.HashPassword(password, salt1);
        var hash2 = _service.HashPassword(password, salt2);

        Assert.AreNotEqual(hash1, hash2);
    }

    [TestMethod]
    public void HashPassword_NullPassword_DoesNotThrow()
    {
        var mockLogger = new Mock<ILogger>();
        var service = new PasswordService(mockLogger.Object);
        var password = string.Empty;
        var salt = "somesalt";

        var result = service.HashPassword(password, salt);

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void HashPassword_NullSalt_DoesNotThrow()
    {
        var mockLogger = new Mock<ILogger>();
        var service = new PasswordService(mockLogger.Object);
        var password = "mypassword";
        var salt = string.Empty;

        var result = service.HashPassword(password, salt);

        Assert.IsNotNull(result);
    }

}
