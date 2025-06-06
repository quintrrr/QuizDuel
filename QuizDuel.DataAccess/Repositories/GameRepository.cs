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
            var game = await GetGameByIdAsync(id);
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
            _gameDbContext.ChangeTracker.Clear();
            return await _gameDbContext.Games
                .FirstOrDefaultAsync(g => g.Id == id);
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
        public async Task AddSecondPlayerToGameAsync(Game game, Guid userId)
        {
            game.Player2Id = userId;
            await _gameDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Асихронно получает игру по id c раундами из базы данных.
        /// </summary>
        public async Task<Game?> GetGameByIdIncludeRoundsAsync(Guid id)
        {
            _gameDbContext.ChangeTracker.Clear();
            return await _gameDbContext.Games
                .Include(g => g.Rounds)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        /// <summary>
        /// Асихронно получает игру по id c раундами и вопросами из базы данных.
        /// </summary>
        public async Task<Game?> GetGameByIdIncludeRoundsAndQuestionsAsync(Guid id)
        {
            _gameDbContext.ChangeTracker.Clear();
            return await _gameDbContext.Games
                .Include(g => g.Rounds)
                .ThenInclude(r => r.RoundQuestions)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        /// <summary>
        /// Асихронно получает игру по id c раундами и ответами из базы данных.
        /// </summary>
        public async Task<Game?> GetGameByIdIncludeRoundsAndAnswersAsync(Guid id)
        {
            _gameDbContext.ChangeTracker.Clear();
            return await _gameDbContext.Games
                .Include(g => g.Rounds)
                .ThenInclude(r => r.PlayerAnswers)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        /// <summary>
        /// Получает последние завершенные игры по id пользователя.
        /// </summary>
        public async Task<List<Game>> GetLastFinishedGamesAsync(Guid userId, int amount)
        {
            return await _gameDbContext.Games
                .Where(g => g.FinishedAt != null
                         && (g.Player1Id == userId || g.Player2Id == userId))
                .OrderByDescending(g => g.FinishedAt)
                .Include(g => g.Rounds)
                .ThenInclude(r => r.PlayerAnswers)
                .AsNoTracking()
                .Take(amount)
                .ToListAsync();
        }
    }
}
