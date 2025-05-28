namespace QuizDuel.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для проверки корректности пароля.
    /// </summary>
    public interface IPasswordValidator
    {
        /// <summary>
        /// Проверяет пароль на соответствие установленным требованиям.
        /// </summary>
        bool ValidatePassword(string password, out List<string> errorMessages);
    }
}
