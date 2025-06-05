namespace QuizDuel.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса отображения уведомлений пользователю.
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Отображает сообщение об ошибке.
        /// </summary>
        void ShowError(string message);
        /// <summary>
        /// Отображает сообщение об успешной операции.
        /// </summary>
        void ShowSuccess(string message);

        /// <summary>
        /// Отобращает сообщение с информацией для пользователя.
        /// </summary>
        void ShowInfo(string message);
    }
}
