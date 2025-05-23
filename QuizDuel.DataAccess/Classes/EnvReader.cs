using System.Diagnostics;
using QuizDuel.DataAccess.Interfaces;

namespace QuizDuel.DataAccess.Classes
{
    /// <summary>
    /// Вспомогательный класс для чтения переменных окружения из файла .env
    /// </summary>
    public class EnvReader : IEnvReader
    {
        /// <summary>
        /// Загружает переменные окружения из указанного файла
        /// </summary>
        public bool TryLoad(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                {
                    continue;
                }

                var parts = line.Split('=', 2);
                if (parts.Length != 2)
                {
                    continue;
                }

                var key = parts[0].Trim();
                var value = parts[1].Trim();
                Environment.SetEnvironmentVariable(key, value);
            }

            return true;
        }
    }
}
