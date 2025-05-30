namespace QuizDuel.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для хранения подключенного пользователя.
    /// </summary>
    public interface IUserSessionService
    {
        Guid? UserID { get; }

        /// <summary>
        /// Устанавливает текущего пользователя
        /// </summary>
        void SetUser(Guid userID);
    }
}
