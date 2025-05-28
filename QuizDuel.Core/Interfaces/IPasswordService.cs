namespace QuizDuel.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с паролями и хэшированием.
    /// </summary>
    public interface IPasswordService
    {
        /// <summary>
        /// Генерирует криптографическую соль.
        /// </summary>
        string GenerateSalt();
        /// <summary>
        /// Вычисляет хэш пароля с использованием указанной соли.
        /// </summary>
        string HashPassword(string password, string salt);
    }
}
