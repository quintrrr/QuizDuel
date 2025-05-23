using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDuel.Core.Interfaces
{
    public interface IErrorService
    {
        void SendError(string message);
    }
}
