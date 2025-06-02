namespace QuizDuel.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для хранения подключенного пользователя.
    /// </summary>
    public interface IUserSessionService
    {
        Guid UserID { get; set; }
    }
}
