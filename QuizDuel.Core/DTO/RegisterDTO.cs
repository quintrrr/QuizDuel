namespace QuizDuel.Core.DTO
{
    /// <summary>
    /// DTO, содержащий данные для регистрации нового пользователя.
    /// Используется при создании аккаунта.
    /// </summary>
    public class RegisterDTO
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Пароль, заданный пользователем.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Повторный ввод пароля для подтверждения.
        /// </summary>
        public string RepeatPassword { get; set; } = string.Empty;

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        public DateTime Birthdate { get; set; }
    }
}