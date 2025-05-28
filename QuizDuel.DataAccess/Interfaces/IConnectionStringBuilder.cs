namespace QuizDuel.DataAccess.Interfaces
{
    /// <summary>
    /// Интерфейс для генерации строки подключения к базе данных.
    /// </summary>
    public interface IConnectionStringBuilder
    {
        /// <summary>
        /// Создаёт строку подключения к базе данных.
        /// </summary>
        string CreateConnectionString();
    }
}
