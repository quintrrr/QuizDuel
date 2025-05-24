using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizDuel.Core.DTO;

namespace QuizDuel.Core.Interfaces
{
    public interface IRegisterValidator
    {
        bool ValidateInput(RegisterDTO registerDTO, out List<string> errorMessage);
    }
}
