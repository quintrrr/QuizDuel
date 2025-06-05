namespace QuizDuel.Core.DTO
{
    /// <summary>
    /// Объект передачи данных для регистрации нового пользователя.
    /// </summary>
    public class RegisterDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RepeatPassword { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
    }
}
