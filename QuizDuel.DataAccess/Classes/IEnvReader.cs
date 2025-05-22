using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDuel.DataAccess.Classes
{
    public interface IEnvReader
    {
        bool TryLoad(string filePath);
    }
}
