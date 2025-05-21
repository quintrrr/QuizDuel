using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDuel.DataAccess
{
    /// <summary>
    /// Вспомогательный класс для чтения переменных окружения из файла .env
    /// </summary>
    class EnvReader
    {
        /// <summary>
        /// Загружает переменные окружения из указанного файла
        /// </summary>
        public static bool TryLoad(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Process.GetCurrentProcess().Kill();
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
