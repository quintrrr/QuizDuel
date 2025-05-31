using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Interfaces
{ 
    /// <summary>
    /// Интерфейс 
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Возвращает пользователя по имени и базы данных
        /// </summary>
        Task<User?> GetByUsername(string username);

        /// <summary>
        ///  Возвращает результат существования пользователя по имени.
        /// </summary>
        Task<bool> IsUserExistsByUsername(string username);

        /// <summary>
        /// Добавляет пользователя в базу данных
        /// </summary>
        Task AddUser(User user);

        /// <summary>
        /// Возвращает имя пользователя по id из базы данных
        /// </summary>
        Task<string?> GetUsernameById(Guid id);
    }
}
