namespace QuizDuel.Core.DTO
{
    /// <summary>
    /// Объект передачи данных для авторизации пользователя.
    /// </summary>
    public class LoginDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
