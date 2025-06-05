using Microsoft.EntityFrameworkCore;
using QuizDuel.DataAccess.Interfaces;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GameDbContext _db;

        public UserRepository(GameDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Возвращает пользователя по имени и базы данных
        /// </summary>
        public async Task<User?> GetByUsername(string username)
        {
            return await _db.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        /// <summary>
        ///  Возвращает результат существования пользователя по имени.
        /// </summary>
        public async Task<bool> IsUserExistsByUsername(string username)
        {
            return await _db.Users
                .AnyAsync(u => u.Username == username);
        }

        /// <summary>
        /// Добавляет пользователя в базу данных
        /// </summary>
        public async Task AddUser(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Возвращает имя пользователя по id из базы данных
        /// </summary>
        public async Task<string?> GetUsernameById(Guid id)
        {
            return await _db.Users.Where(u => u.Id == id).Select(u => u.Username).FirstOrDefaultAsync();
        }
    }
}
