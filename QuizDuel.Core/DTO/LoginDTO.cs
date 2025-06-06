namespace QuizDuel.Core.DTO
{
    /// <summary>
    /// DTO для передачи данных при авторизации пользователя.
    /// Используется при входе в систему.
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}