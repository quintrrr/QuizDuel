using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDuel.Core.Services
{
    public interface IPasswordValidator
    {
        bool ValidatePassword(string password, out string errorMessage);
    }
}
