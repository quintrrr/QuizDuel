using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Repositories
{ 
    public interface IUserRepository
    {
        Task<User?> GetByUsername(string username);

        Task<bool> IsUserExistsByUsername(string username);

        Task AddUser(User user);
    }
}
