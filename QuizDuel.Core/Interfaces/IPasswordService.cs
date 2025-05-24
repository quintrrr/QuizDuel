using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDuel.Core.Interfaces
{
    public interface IPasswordService
    {
        string GenerateSalt();

        string HashPassword(string password, string salt);
    }
}
