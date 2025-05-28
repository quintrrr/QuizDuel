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
        /// Создает новую игру и сохраняет ее в базе данных.
        /// </summary>
        public async Task CreateGameAsync(Guid player1Id, Guid player2Id)
        {
            var newGame = new Game
            {
                Id = Guid.NewGuid(),
                Player1Id = player1Id,
                Player2Id = player2Id
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
                    $"между игроками {player1Id} и {player2Id}.");
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка при добавлении игры в базу данных", ex);
                throw;
            }
        }
    }
}
