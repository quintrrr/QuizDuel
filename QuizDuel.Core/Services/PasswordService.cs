using System.Security.Cryptography;
using System.Text;
using Castle.Core.Logging;
using QuizDuel.Core.Interfaces;

namespace QuizDuel.Core.Services
{
    /// <summary>
    /// Сервис для генерации соли и хэширования паролей.
    /// </summary>
    public class PasswordService : IPasswordService
    {
        private readonly ILogger _logger;
        public PasswordService(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Генерирует криптографическую соль.
        /// </summary>
        public string GenerateSalt()
        {
            try
            {
                var salt = new byte[32];
                using (var rand = RandomNumberGenerator.Create())
                {
                    rand.GetBytes(salt);
                }
                var saltString = Convert.ToBase64String(salt);
                _logger.Debug("Сгенерирована новая соль.");
                return saltString;
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка при генерации соли.", ex);
                throw;
            }
        }

        /// <summary>
        /// Вычисляет хэш пароля с использованием указанной соли.
        /// </summary>
        public string HashPassword(string password, string salt)
        {
            try
            { 
                using (var sha256 = SHA256.Create())
                {
                    var saltedPassword = password + salt;
                    var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                    var hashResult = Convert.ToBase64String(bytes);
                    return hashResult;
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка при хэшировании пароля.", ex);
                throw;
            }
        }
    }
}
