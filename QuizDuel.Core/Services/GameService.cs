using Castle.Core.Logging;
using QuizDuel.Core.DTO;
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
        private readonly IUserRepository _userRepository;
        private readonly IUserSessionService _userSessionService;
        private readonly ILogger _logger;
        private Guid _gameId;
        public Guid GameId => _gameId;

        public GameService(
            IGameRepository gameRepository,
            ILogger logger,
            IUserRepository userRepository,
            IUserSessionService userSessionService)
        {
            _gameRepository = gameRepository;
            _logger = logger; 
            _userRepository = userRepository;
            _userSessionService = userSessionService;
        }

        /// <summary>
        /// Создает новую игру с одним игроком и сохраняет ее в базе данных, возвращает id игры
        /// </summary>
        public async Task<Guid> CreateGameAsync(Guid player1Id)
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
                return newGame.Id;
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка при добавлении игры в базу данных", ex);
                throw;
            }
        }

        /// <summary>
        /// Устанавливает текущий id игры
        /// </summary>
        public void SetGameId(Guid gameId)
        {
            _gameId = gameId;
            _logger.Info($"Установлен ID текущей игры: {gameId}");
        }

        /// <summary>
        /// Удаляет игру.
        /// </summary>
        public async Task DeleteGameAsync()
        {
            try
            {
                await _gameRepository.DeleteAsync(_gameId);
                _logger.Info($"Удалена игра с ID: {_gameId}");  
            }
            catch (Exception ex)
            {
                _logger.Error($"Ошибка при удалении игры из базы данных", ex);
            }
            finally
            {
                _gameId = default;
            }
        }

        /// <summary>
        /// Возвращает имена пользьзователей игроков.
        /// </summary>
        public async Task<(string? Player1, string? Player2)> GetUsernamesAsync()
        {
            var game = await _gameRepository.GetGameByIdAsync(_gameId);

            if (game is null)
            {
                return (null, null);
            }
            
            var player1Username = await _userRepository.GetUsernameById(game.Player1Id);
            var player2Username = await _userRepository.GetUsernameById(game.Player2Id);
            return (player1Username, player2Username);
        }

        /// <summary>
        /// Возвращает статус игры.
        /// </summary>
        public async Task<GameStateDTO> GetGameStateAsync()
        {
            var game = await _gameRepository.GetGameByIdAsync(_gameId);

            if (game is null)
            {
                throw new Exception($"Игра с {_gameId} не найдена.");
            }

            return new GameStateDTO
            {
                CurrentRound = game.CurrentRound,
                Turn = game.Turn,
                IsStarted = game.Player1Id != default && game.Player2Id != default,
                IsFinished = game.FinishedAt is not null,
            };
        }

        /// <summary>
        /// Возвращает список неначатых игр.
        /// </summary>
        public async Task<List<OpenedGameDTO>> GetOpenedGamesAsync()
        {
            var openedGames = await _gameRepository.GetOpenedGamesAsync() ?? [];
            var openedGamesDTO = new List<OpenedGameDTO>();
            foreach (var game in openedGames)
            {
                openedGamesDTO.Add(new OpenedGameDTO
                {
                    GameId = game.Id,
                    HostUsername = await _userRepository.GetUsernameById(game.Player1Id) ?? "",
                });
            }
            return openedGamesDTO;
        }

        /// <summary>
        /// Присоединяет второго игрока к игре.
        /// </summary>
        public async Task JoinGameAsync()
        {
            try
            {
                await _gameRepository.AddSecondPlayerToGameAsync(_gameId, _userSessionService.UserID);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
