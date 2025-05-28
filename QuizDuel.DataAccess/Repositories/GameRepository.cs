using QuizDuel.DataAccess.Interfaces;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями игры.
    /// </summary>
    public class GameRepository : IGameRepository
    {
        private readonly GameDbContext _gameDbContext;

        public GameRepository(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        /// <summary>
        /// Асихронно добавляет игру в базу данных.
        /// </summary>
        public async Task AddAsync(Game game)
        {
            await _gameDbContext.AddAsync(game);
            await _gameDbContext.SaveChangesAsync();
        }
    }
}
