using Castle.Core.Logging;
using QuizDuel.Core.DTO;
using QuizDuel.Core.Interfaces;

namespace QuizDuel.Core.Services
{
    /// <summary>
    /// Сервис для валидации данных при регистрации пользователя.
    /// </summary>
    public class RegisterValidator : IRegisterValidator
    {
        private readonly IPasswordValidator _passwordValidator;
        private readonly ILogger _logger;

        public RegisterValidator(IPasswordValidator passwordValidator, ILogger logger)
        {
            _passwordValidator = passwordValidator;
            _logger = logger;
        }

        /// <summary>
        /// Проверяет корректность введённых пользователем данных при регистрации.
        /// </summary>
        public bool ValidateInput(RegisterDTO registerDTO, out List<string> errorMessages)
        {
            errorMessages = [];

            if (string.IsNullOrEmpty(registerDTO.Username.Trim()))
            {
                errorMessages.Add("Register.EmptyUsername");
            }
            if (string.IsNullOrEmpty(registerDTO.Password.Trim()))
            {
                errorMessages.Add("Register.EmptyPassword");
            }
            if (string.IsNullOrEmpty(registerDTO.RepeatPassword.Trim()))
            {
                errorMessages.Add("Register.EmptyRepeatPassword");
            }

            if (errorMessages.Count > 0)
            {
                _logger.Warn($"Валидация регистрации не пройдена: {string.Join(", ", errorMessages)}");
                return false;
            }

            if (CalculateAge(registerDTO.Birthdate.ToUniversalTime()) < 4)
            {
                errorMessages.Add("Register.InvalidAge");
                _logger.Warn("Валидация регистрации: недопустимый возраст.");
                return false;
            }

            if (registerDTO.Password != registerDTO.RepeatPassword)
            {
                errorMessages.Add("Register.InvalidRepeatPassword");
                _logger.Warn("Валидация регистрации: пароль и повтор не совпадают.");
                return false;
            }

            if (!_passwordValidator.ValidatePassword(registerDTO.Password, out List<string> passwordErrorMessage))
            {
                errorMessages.AddRange(passwordErrorMessage);
                _logger.Warn($"Валидация регистрации: пароль не соответствует требованиям." +
                    $"Ошибки: {string.Join(", ", passwordErrorMessage)}");
                return false;
            }

            _logger.Debug("Данные регистрации успешно прошли валидацию.");
            return true;
        }

        /// <summary>
        /// Вычисляет полный возраст на основе даты рождения.
        /// </summary>
        private int CalculateAge(DateTime birthdate)
        {
            var today = DateTime.Today.ToUniversalTime();
            var age = today.Year - birthdate.Year;

            if (birthdate > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }


    }
}
