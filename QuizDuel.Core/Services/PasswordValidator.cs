using System.Text.RegularExpressions;
using Castle.Core.Logging;
using QuizDuel.Core.Interfaces;

namespace QuizDuel.Core.Services
{
    /// <summary>
    /// Сервис для проверки пароля на соответствие требованиям безопасности.
    /// </summary>
    public class PasswordValidator: IPasswordValidator
    {
        private readonly ILogger _logger;

        public PasswordValidator(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Проверяет пароль на наличие всех необходимых признаков:
        /// длины, регистра, цифр, символов и латинских символов.
        /// </summary>
        public bool ValidatePassword(string password, out List<string> errorMessages)
        {
            errorMessages = [];

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,20}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            var isLatinOnly = new Regex(@"^[\x21-\x7E]+$");

            if (!hasMiniMaxChars.IsMatch(password))
            {
                errorMessages.Add("Password.MinMaxChar");
            }
            if (!hasLowerChar.IsMatch(password))
            {
                errorMessages.Add("Password.HasLowerChar");
            }
            if (!hasUpperChar.IsMatch(password))
            {
                errorMessages.Add("Password.HasUpperChar");
            }
            if (!hasNumber.IsMatch(password))
            {
                errorMessages.Add("Password.HasNumber");
            }
            if (!hasSymbols.IsMatch(password))
            {
                errorMessages.Add("Password.HasSymbols");
            }
            if (!isLatinOnly.IsMatch(password))
            {
                errorMessages.Add("Password.IsLatinOnly");
            }

            if (errorMessages.Count == 0)
            {
                _logger.Debug("Пароль прошёл проверку.");
                return true;
            }

            _logger.Warn($"Пароль не прошёл проверку. Ошибки: {string.Join(", ", errorMessages)}");
            return false;
        }
    }
}
