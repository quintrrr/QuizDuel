using QuizDuel.DataAccess.Interfaces;

namespace QuizDuel.DataAccess.Classes
{
    public class ConnectionStringBuilder : IConnectionStringBuilder
    {
        private readonly IEnvReader _envReader;

        public ConnectionStringBuilder(IEnvReader envReader)
        {
            _envReader = envReader;
        }

        public string CreateConnectionString()
        {
            if (!_envReader.TryLoad("../../../../.env"))
            {
                throw new Exception("Не удалось загрузить данные из файла .env");
            }

            var host = Environment.GetEnvironmentVariable("DB_HOST");
            var port = Environment.GetEnvironmentVariable("DB_PORT");
            var username = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var database = Environment.GetEnvironmentVariable("DB_NAME");
            return $"Host={host};Port={port};Username={username};" +
                                    $"Password={password};Database={database}";
        }
    }
}
