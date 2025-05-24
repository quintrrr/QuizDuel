using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDuel.Core.Interfaces
{
    public interface INotificationService
    {
        void ShowError(string message);
        void ShowSuccess(string message);
    }
}
