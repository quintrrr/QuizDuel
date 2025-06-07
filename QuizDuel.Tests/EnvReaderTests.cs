using QuizDuel.DataAccess.Classes;

[TestClass]
public class EnvReaderTests
{
    private string _currentTestFile;

    [TestInitialize]
    public void Setup()
    {
        _currentTestFile = $"test_{Guid.NewGuid()}.env";

        Environment.SetEnvironmentVariable("TEST_KEY", null);
        Environment.SetEnvironmentVariable("KEY1", null);
        Environment.SetEnvironmentVariable("KEY2", null);
        Environment.SetEnvironmentVariable("DUPLICATE_KEY", null);
        Environment.SetEnvironmentVariable("EMPTY_VALUE", null);
    }

    [TestCleanup]
    public void Cleanup()
    {
        if (File.Exists(_currentTestFile))
        {
            try
            {
                File.Delete(_currentTestFile);
            }
            catch (IOException)
            {
                Thread.Sleep(100);
                File.Delete(_currentTestFile);
            }
        }
    }

    [TestMethod]
    public void TryLoad_FileDoesNotExist_ReturnsFalse()
    {
        var reader = new EnvReader();

        var result = reader.TryLoad("nonexistent.env");

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TryLoad_ValidFile_SetsEnvironmentVariablesAndReturnsTrue()
    {
        File.WriteAllText(_currentTestFile, "TEST_KEY=some_value\n# Comment line\nINVALIDLINE");

        var reader = new EnvReader();

        var result = reader.TryLoad(_currentTestFile);

        Assert.IsTrue(result);
        Assert.AreEqual("some_value", Environment.GetEnvironmentVariable("TEST_KEY"));
    }

    [TestMethod]
    public void TryLoad_EmptyFile_ReturnsTrue()
    {
        File.WriteAllText(_currentTestFile, "");

        var reader = new EnvReader();

        var result = reader.TryLoad(_currentTestFile);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TryLoad_OnlyComments_ReturnsTrue()
    {
        File.WriteAllText(_currentTestFile, "# Just a comment\n# Another one");

        var reader = new EnvReader();

        var result = reader.TryLoad(_currentTestFile);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TryLoad_KeyWithoutValue_SetsEmptyString()
    {
        File.WriteAllText(_currentTestFile, "EMPTY_VALUE=");

        var reader = new EnvReader();

        var result = reader.TryLoad(_currentTestFile);

        Assert.IsTrue(result);
        Assert.IsNull(Environment.GetEnvironmentVariable("EMPTY_VALUE"));
    }

    [TestMethod]
    public void TryLoad_MultipleVariables_AllSetCorrectly()
    {
        File.WriteAllText(_currentTestFile, "KEY1=val1\nKEY2=val2");

        var reader = new EnvReader();

        var result = reader.TryLoad(_currentTestFile);

        Assert.IsTrue(result);
        Assert.AreEqual("val1", Environment.GetEnvironmentVariable("KEY1"));
        Assert.AreEqual("val2", Environment.GetEnvironmentVariable("KEY2"));
    }

    [TestMethod]
    public void TryLoad_DuplicateKeys_LastOneWins()
    {
        File.WriteAllText(_currentTestFile, "DUPLICATE_KEY=first\nDUPLICATE_KEY=second");

        var reader = new EnvReader();

        var result = reader.TryLoad(_currentTestFile);

        Assert.IsTrue(result);
        Assert.AreEqual("second", Environment.GetEnvironmentVariable("DUPLICATE_KEY"));
    }
}
