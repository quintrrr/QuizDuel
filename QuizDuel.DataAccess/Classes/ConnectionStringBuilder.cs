using Castle.Core.Logging;
using QuizDuel.DataAccess.Interfaces;

namespace QuizDuel.DataAccess.Classes
{
    /// <summary>
    /// Сервис для построения строки подключения к базе данных на основе переменных окружения.
    /// </summary>
    public class ConnectionStringBuilder : IConnectionStringBuilder
    {
        private readonly IEnvReader _envReader;
        private readonly ILogger _logger;

        public ConnectionStringBuilder(IEnvReader envReader, ILogger logger)
        {
            _envReader = envReader;
            _logger = logger;
        }

        /// <summary>
        /// Создаёт строку подключения к базе данных, загружая параметры из файла .env.
        /// </summary>
        public string CreateGameConnectionString()
        {
            if (!_envReader.TryLoad("../../../../.env"))
            {
                _logger.Fatal($"Не удалось загрузить файл .env");
                throw new Exception("Не удалось загрузить данные из файла .env");
            }

            var host = Environment.GetEnvironmentVariable("DB_HOST");
            var port = Environment.GetEnvironmentVariable("DB_PORT");
            var username = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var database = Environment.GetEnvironmentVariable("DB_NAME");

            _logger.Debug("Переменные окружения успешно загружены из .env.");

            return $"Host={host};Port={port};Username={username};" +
                                    $"Password={password};Database={database}";
        }

        /// <summary>
        /// Создаёт строку подключения к базе данных вопросов, загружая параметры из файла .env.
        /// </summary>
        public string CreateQuestionsConnectionString()
        {
            if (!_envReader.TryLoad("../../../../.env"))
            {
                _logger.Fatal($"Не удалось загрузить файл .env");
                throw new Exception("Не удалось загрузить данные из файла .env");
            }

            var host = Environment.GetEnvironmentVariable("QUESTIONS_DB_HOST");
            var port = Environment.GetEnvironmentVariable("QUESTIONS_DB_PORT");
            var username = Environment.GetEnvironmentVariable("QUESTIONS_DB_USER");
            var password = Environment.GetEnvironmentVariable("QUESTIONS_DB_PASSWORD");
            var database = Environment.GetEnvironmentVariable("QUESTIONS_DB_NAME");

            _logger.Debug("Переменные окружения успешно загружены из .env.");

            return $"Host={host};Port={port};Username={username};" +
                                    $"Password={password};Database={database}";
        }
    }
}
