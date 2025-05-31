using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностями игры.
    /// </summary>
    public interface IGameRepository
    {
        /// <summary>
        /// Асихронно добавляет игру в базу данных.
        /// </summary>
        Task AddAsync(Game game);

        /// <summary>
        /// Асихронно удаляет игру из базы данных.
        /// </summary>
        Task DeleteAsync(Guid id);


    }
}
