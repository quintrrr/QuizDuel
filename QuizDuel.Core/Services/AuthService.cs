using Castle.Core.Logging;
using QuizDuel.Core.DTO;
using QuizDuel.Core.Interfaces;
using QuizDuel.DataAccess.Interfaces;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.Core.Services
{
    /// <summary>
    /// Сервис для регистрации и аутентификации пользователей.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IRegisterValidator _registerValidator;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ILogger _logger;
        private readonly IUserSessionService _userSessionService;

        public AuthService(
            IRegisterValidator registerValidator,
            IUserRepository userRepository,
            IPasswordService passwordService,
            ILogger logger,
            IUserSessionService userSessionService)
        {
            _registerValidator = registerValidator;
            _userRepository = userRepository;
            _passwordService = passwordService;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        /// <summary>
        /// Выполняет вход пользователя по имени и паролю.
        /// </summary>
        public async Task<OperationResultDTO> LoginAsync(LoginDTO loginDTO)
        {
            var result = new OperationResultDTO();

            if (IsUsernameEmpty(loginDTO.Username))
            {
                _logger.Warn("Попытка входа с пустым именем пользователя.");
                result.MessageKeys.Add("Login.EmptyUsername");
                return result;
            }
            try
            {
                var user = await _userRepository.GetByUsername(loginDTO.Username);

                if (user == null)
                {
                    _logger.Warn($"Пользователь с именем '{loginDTO.Username}' не найден.");
                    result.MessageKeys.Add("Login.NonExistingUser");
                    return result;
                }

                var inputHash = _passwordService.HashPassword(loginDTO.Password, user.Salt);

                if (inputHash != user.PasswordHash)
                {
                    _logger.Warn($"Неверный пароль для пользователя '{loginDTO.Username}'.");
                    result.MessageKeys.Add("Login.WrongPassword");
                    return result;
                }

                _userSessionService.UserID = user.Id;

                _logger.Info($"Пользователь '{loginDTO.Username}' успешно вошёл в систему.");
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                _logger.Error($"Ошибка при входе пользователя '{loginDTO.Username}': {ex.Message}", ex);
                result.MessageKeys.Add(ex.Message);
                return result;
            }
        }

        /// <summary>
        /// Выполняет регистрацию нового пользователя.
        /// </summary>
        public async Task<OperationResultDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            var result = new OperationResultDTO();

            if (!_registerValidator.ValidateInput(registerDTO, out var errorMessages))
            {
                _logger.Warn($"Регистрация не прошла валидацию для пользователя '{registerDTO.Username}'." +
                    $" Ошибки: {string.Join(", ", errorMessages)}");
                result.MessageKeys.AddRange(errorMessages);
                return result;
            }
            try
            {
                if (await _userRepository.IsUserExistsByUsername(registerDTO.Username))
                {
                    _logger.Warn($"Попытка регистрации с уже существующим " +
                        $"именем пользователя: '{registerDTO.Username}'.");
                    result.MessageKeys.Add("Register.ExistingUser");
                    return result;
                }

                var salt = _passwordService.GenerateSalt();
                var passwordHash = _passwordService.HashPassword(registerDTO.Password, salt);
                var newUser = new User
                {
                    Id = Guid.NewGuid(),
                    Username = registerDTO.Username,
                    PasswordHash = passwordHash,
                    Salt = salt,
                    Birthdate = registerDTO.Birthdate.ToUniversalTime(),
                };

                await _userRepository.AddUser(newUser);
                _logger.Info($"Пользователь '{registerDTO.Username}' успешно зарегистрирован.");
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                _logger.Error($"Ошибка при регистрации пользователя " +
                    $"'{registerDTO.Username}': {ex.Message}", ex);
                result.MessageKeys.Add(ex.Message);
                return result;
            }
        }        

        private bool IsUsernameEmpty(string username)
        {
            return string.IsNullOrEmpty(username);
        }
    }
}
