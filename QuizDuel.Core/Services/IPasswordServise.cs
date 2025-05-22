using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDuel.Core.Services
{
    public interface IPasswordServise
    {
        string GenerateSalt();

        string HashPassword(string password, string salt);
    }
}
