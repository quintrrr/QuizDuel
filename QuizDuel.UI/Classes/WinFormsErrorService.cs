using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizDuel.Core.Interfaces;

namespace QuizDuel.UI.Classes
{
    public class WinFormsErrorService : IErrorService
    {
        public void SendError(string message)
        {
            MessageBox.Show(message);
        }
    }
}
