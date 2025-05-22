using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizDuel.Core.DTO;

namespace QuizDuel.Core.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDTO registerDTO);
        Task LoginAsync(LoginDTO loginDTO);
    }
}
