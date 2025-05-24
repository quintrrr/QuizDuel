using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDuel.Core.DTO
{
    public class OperationResultDTO
    {
        public bool Success { get; set; }

        public List<string> MessageKeys { get; set; } = [];
    }
}
