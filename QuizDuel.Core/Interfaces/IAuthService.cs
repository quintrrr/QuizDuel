using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizDuel.Core.DTO;

namespace QuizDuel.Core.Interfaces
{
    public interface IAuthService
    {
        Task<OperationResultDTO> RegisterAsync(RegisterDTO registerDTO);
        Task<OperationResultDTO> LoginAsync(LoginDTO loginDTO);
    }
}
