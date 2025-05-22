using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Repositories
{ 
    public interface IUserRepository
    {
        public Task<User?> GetByUsername(string username);
    }
}
