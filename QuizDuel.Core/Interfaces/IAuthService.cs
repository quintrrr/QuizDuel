using QuizDuel.Core.DTO;

namespace QuizDuel.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса аутентификации и регистрации пользователей.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Выполняет регистрацию нового пользователя.
        /// </summary>
        Task<OperationResultDTO> RegisterAsync(RegisterDTO registerDTO);
        /// <summary>
        /// Выполняет вход пользователя в систему.
        /// </summary>
        Task<OperationResultDTO> LoginAsync(LoginDTO loginDTO);
    }
}
