using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Repositories
{ 
    public interface IUserRepository
    {
        public Task<User?> GetByUsername(string username);
    }
}
