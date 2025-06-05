namespace QuizDuel.DataAccess.Interfaces
{
    /// <summary>
    /// Интерфейс для загрузки переменных окружения из файла.
    /// </summary>
    public interface IEnvReader
    {
        /// <summary>
        /// Загружает переменные окружения из указанного файла.
        /// </summary>
        bool TryLoad(string filePath);
    }
}
