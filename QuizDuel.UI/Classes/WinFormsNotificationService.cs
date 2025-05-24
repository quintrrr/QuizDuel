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
           MessageBox.Show(message, "ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccess(string message)
        {
            MessageBox.Show(message, "успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
