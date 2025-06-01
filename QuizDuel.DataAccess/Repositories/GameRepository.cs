using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Асихронно удаляет игру из базы данных.
        /// </summary>
        public async Task DeleteAsync(Guid id)
        {
            var game = await _gameDbContext.Games.FirstOrDefaultAsync(g => g.Id == id);
            if (game is not null)
            {
                _gameDbContext.Games.Remove(game);
                await _gameDbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Асихронно получает игру по id из базы данных.
        /// </summary>
        public async Task<Game?> GetGameByIdAsync(Guid id)
        {
            return await _gameDbContext.Games.FirstOrDefaultAsync(g => g.Id == id);
        }

        /// <summary>
        /// Возвращает список неначатых игр.
        /// </summary>
        public async Task<List<Game>> GetOpenedGamesAsync()
        {
            return await _gameDbContext.Games
                .Where(g => g.Player2Id == default && g.FinishedAt == null)
                .OrderByDescending(g => g.CreatedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Асихронно добавляет второго игрока в игру.
        /// </summary>
        public async Task AddSecondPlayerToGameAsync(Guid gameId, Guid userId)
        {
            var game = await GetGameByIdAsync(gameId);
            if (game is not null)
            {
                game.Player2Id = userId;
                await _gameDbContext.SaveChangesAsync();
            }
        }
    }
}
