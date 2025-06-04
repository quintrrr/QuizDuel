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
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger _logger;
        private Guid _gameId;

        /// <summary>
        /// Свойство текущей игры 
        /// </summary>
        public Guid GameId
        { 
            get
            {
                return _gameId;
            }
            set
            {
                _gameId = value;
                _logger.Info($"Установлен ID текущей игры: {value}");
            }

        }

        public GameService(
            IGameRepository gameRepository,
            ILogger logger,
            IUserRepository userRepository,
            IUserSessionService userSessionService,
            ICategoryRepository categoryRepository)
        {
            _gameRepository = gameRepository;
            _logger = logger; 
            _userRepository = userRepository;
            _userSessionService = userSessionService;
            _categoryRepository = categoryRepository;
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
        public async Task<OperationResultDTO> JoinGameAsync()
        {
            var result = new OperationResultDTO();
            try
            {
                var game = await _gameRepository.GetGameByIdAsync(_gameId);

                if (game is null)
                {
                    result.MessageKeys.Add("Game.IsNotFound");
                    _logger.Error($"Игра с {_gameId} не найдена.");
                    return result;
                }

                if (game.Player1Id == _userSessionService.UserID)
                {
                    result.MessageKeys.Add("Game.SamePlayers");
                    _logger.Warn($"Подключение игрока {_userSessionService.UserID} к своей игре.");
                    return result;
                }

                await _gameRepository
                    .AddSecondPlayerToGameAsync(game, _userSessionService.UserID);
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                _logger.Error($"Ошибка подключения к игре", ex);
                result.MessageKeys.Add("Game.JoinError");
                return result;
            }
        }

        /// <summary>
        /// Возвращает список случайных категорий.
        /// </summary>
        public async Task<List<Category>> GetRandomCategoriesAsync(int amount)
        {
            try
            {
                return await _categoryRepository.GetRandomCategoriesAsync(amount);
            }
            catch (Exception ex)
            {
                _logger.Error("Не удалось получить категории", ex);
                throw;
            }
        }
    }
}
