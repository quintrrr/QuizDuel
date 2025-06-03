namespace QuizDuel.DataAccess.Interfaces
{
    /// <summary>
    /// Интерфейс для генерации строки подключения к базе данных.
    /// </summary>
    public interface IConnectionStringBuilder
    {
        /// <summary>
        /// Создаёт строку подключения к базе данных игры.
        /// </summary>
        string CreateGameConnectionString();
        
        /// <summary>
        /// Создаёт строку подключения к базе данных вопросов.
        /// </summary>
        string CreateQuestionsConnectionString();
    }
}
