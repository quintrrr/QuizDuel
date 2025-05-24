using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizDuel.Core.Interfaces;

namespace QuizDuel.UI.Classes
{
    public class WinFormsNotificationService : INotificationService
    {
        public void ShowError(string message)
        {
           MessageBox.Show(message, Resources.Notification_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccess(string message)
        {
            MessageBox.Show(message, Resources.Notification_Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
