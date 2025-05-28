using QuizDuel.Core.Interfaces;

namespace QuizDuel.UI.Classes
{
    /// <summary>
    /// Сервис уведомлений для отображения сообщений в WinForms-интерфейсе.
    /// </summary>
    public class WinFormsNotificationService : INotificationService
    {
        /// <summary>
        /// Отображает сообщение об ошибке в виде всплывающего окна.
        /// </summary>
        public void ShowError(string message)
        {
           MessageBox.Show(message, Resources.Notification_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Отображает сообщение об успешной операции в виде всплывающего окна.
        /// </summary>
        public void ShowSuccess(string message)
        {
            MessageBox.Show(message, Resources.Notification_Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
