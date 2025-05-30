using Castle.Core.Logging;
using QuizDuel.Core.Interfaces;
using QuizDuel.DataAccess.Interfaces;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.Core.Services
{
    /// <summary>
    /// Cервис управления игрой.
    /// </summary>
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly ILogger _logger;

        public GameService(IGameRepository gameRepository, ILogger logger)
        {
            _gameRepository = gameRepository;
            _logger = logger;  
        }

        /// <summary>
        /// Создает новую игру с одним игроком и сохраняет ее в базе данных.
        /// </summary>
        public async Task CreateGameAsync(Guid player1Id)
        {
            var newGame = new Game
            {
                Id = Guid.NewGuid(),
                Player1Id = player1Id,
            };
            
            for (var i = 0; i < 6; i++)
            {
                newGame.Rounds.Add(new Round
                {
                    Id = Guid.NewGuid(),
                    GameId = newGame.Id,
                    Index = i,
                });
            }

            try
            {
                await _gameRepository.AddAsync(newGame);
                _logger.Info($"Создана новая игра с ID {newGame.Id} " +
                    $"игроком {player1Id} ");
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка при добавлении игры в базу данных", ex);
                throw;
            }
        }
    }
}
