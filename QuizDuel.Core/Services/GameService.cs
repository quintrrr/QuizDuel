using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using QuizDuel.Core.DTO;
using QuizDuel.Core.Interfaces;
using QuizDuel.DataAccess;
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
        private readonly IQuestionRepository _questionRepository;
        private readonly IRoundQuestionRepository _roundQuestionRepository;
        private readonly ILogger _logger;
        private readonly GameDbContext _gameDbContext;
        private readonly QuestionsDbContext _questionsDbContext;

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
            ICategoryRepository categoryRepository,
            IQuestionRepository questionRepository,
            IRoundQuestionRepository roundQuestionRepository,
            GameDbContext gameDbContext,
            QuestionsDbContext questionsDbContext)
        {
            _gameRepository = gameRepository;
            _logger = logger;
            _userRepository = userRepository;
            _userSessionService = userSessionService;
            _categoryRepository = categoryRepository;
            _questionRepository = questionRepository;
            _roundQuestionRepository = roundQuestionRepository;
            _gameDbContext = gameDbContext;
            _questionsDbContext = questionsDbContext;
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
                CurrentTurnPlayerId = game.Turn == 0 ? game.Player1Id : game.Player2Id,
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

        /// <summary>
        /// Выбирает категорию.
        /// </summary>
        public async Task SelectCategoryAsync(Guid categoryId)
        {
            try
            {
                var game = await _gameRepository.GetGameByIdIncludeRoundsAsync(_gameId);
                if (game is null)
                {
                    throw new Exception($"Игра с {_gameId} не найдена.");
                }

                var round = game.Rounds.FirstOrDefault(r => r.Index == game.CurrentRound);

                if (round is null)
                {
                    throw new Exception("Раунд не найден");
                }

                round.CategoryId = categoryId;
                await _gameDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.Error("Не удалось выбрать категорию", ex);
                throw;
            }
        }

        /// <summary>
        /// Возвращает список вопросов с перемешанными ответами. 
        /// </summary>
        public async Task<List<ShuffledQuestionDTO>> GetShuffledQuestionsAsync(int amount)
        {
            try
            {
                var game = await _gameRepository.GetGameByIdIncludeRoundsAndQuestionsAsync(_gameId);

                if (game is null)
                {
                    throw new Exception($"Игра с {_gameId} не найдена.");
                }

                var round = game.Rounds.FirstOrDefault(r => r.Index == game.CurrentRound);

                if (round is null)
                {
                    throw new Exception("Раунд не найден");
                }

                if (round.RoundQuestions.Count != 0)
                {
                    var ids = round.RoundQuestions.Select(q => q.QuestionId).ToList();
                    var questions = await _questionRepository.GetQuestionsByIdsAsync(ids);
                    return questions.Select(q => ShuffleAnswers(q)).OrderBy(q => q.QuestionId).ToList();
                }

                var newQuestions = await _questionRepository.GetRandomByCategoryIdAsync(round.CategoryId, 3);
                var newRoundQuestions = newQuestions.Select((q, index) => new RoundQuestion
                {
                    Id = Guid.NewGuid(),
                    RoundId = round.Id,
                    QuestionId = q.Id,
                    QuestionIndex = index,
                }).ToList();

                foreach (var roundQuestion in newRoundQuestions)
                {
                    await _roundQuestionRepository.AddAsync(roundQuestion);
                }

                return newQuestions.Select(q => ShuffleAnswers(q)).OrderBy(q => q.QuestionId).ToList();
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка при получении вопросов", ex);
                throw;
            }
        }

        /// <summary>
        /// Подтверждает ответ пользователя.
        /// </summary>
        public async Task<AnswerResultDTO> SubmitAnswerAsync(Guid playerId, SubmittedAnswerDTO answer)
        {
            try
            {
                var game = await _gameRepository.GetGameByIdIncludeRoundsAndAnswersAsync(_gameId);

                if (game is null)
                {
                    throw new Exception($"Игра с {_gameId} не найдена.");
                }

                var round = game.Rounds.FirstOrDefault(r => r.Index == game.CurrentRound);

                if (round is null)
                {
                    throw new Exception("Раунд не найден");
                }

                if (round.PlayerAnswers.Any(a => a.UserId == playerId && a.QuestionId == answer.Id))
                {
                    throw new Exception("Игрок уже ответил на этот вопрос");
                }

                var question = await _questionRepository.GetByIdAsync(answer.Id);
                if (question == null)
                    throw new Exception("Вопрос не найден");

                var correctAnswer = question.CorrectAnswer;
                var correctIndex = answer.Answers.FindIndex(o => o == correctAnswer);
                var isCorrect = correctIndex == answer.SelectedIndex;

                var roundAnswer = new PlayerAnswer
                {
                    Id = Guid.NewGuid(),
                    RoundId = round.Id,
                    UserId = playerId,
                    QuestionId = answer.Id,
                    Selected = answer.SelectedIndex,
                    IsCorrect = isCorrect,
                };

                await _gameDbContext.PlayerAnswers.AddAsync(roundAnswer);
                await _gameDbContext.SaveChangesAsync();

                return new AnswerResultDTO
                {
                    IsCorrect = isCorrect,
                    CorrectOptionIndex = correctIndex
                };
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка при ответе на вопрос", ex);
                throw;
            }
        }

        private static ShuffledQuestionDTO ShuffleAnswers(Question question)
        {
            var answers = new List<AnswerDTO>
            {
                new AnswerDTO { Text =  question.CorrectAnswer, IsCorrect = true },
                new AnswerDTO { Text =  question.Incorrect1 },
                new AnswerDTO { Text =  question.Incorrect2 },
                new AnswerDTO { Text =  question.Incorrect3 },
            };

            var shuffled = answers.OrderBy(a => Guid.NewGuid()).ToList();

            return new ShuffledQuestionDTO
            {
                QuestionId = question.Id,
                Text = question.Text,
                Answers = shuffled.Select(a => a.Text).ToList(),
                CorrectAnswerIndex = shuffled.FindIndex(a => a.IsCorrect)
            };
        }

        /// <summary>
        /// Возвращает счет игроков
        /// </summary>
        public async Task<(int player1Score, int player2Score)> GetScoresAsync()
        {
            try
            {
                var game = await _gameRepository.GetGameByIdIncludeRoundsAndAnswersAsync(_gameId);

                if (game == null) throw new Exception("Игра не найдена");

                int p1 = 0, p2 = 0;

                foreach (var round in game.Rounds)
                {
                    p1 += round.PlayerAnswers.Count(a => a.UserId == game.Player1Id && a.IsCorrect);
                    p2 += round.PlayerAnswers.Count(a => a.UserId == game.Player2Id && a.IsCorrect);
                }

                return (p1, p2);
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка при получении счета", ex);
                throw;
            }
        }

        /// <summary>
        /// Передает ход следующему игроку
        /// </summary>
        public async Task PassTurnAsync()
        {
            try
            {
                var game = await _gameRepository.GetGameByIdAsync(_gameId);
                if (game == null) 
                { 
                    throw new Exception("Игра не найдена"); 
                }

                if (game.FinishedAt != null) 
                { 
                    throw new Exception("Игра уже завершена"); 
                }

                bool isEvenRound = game.CurrentRound % 2 == 0;

                if (game.Turn == 0)
                {
                    if (isEvenRound)
                    {
                        game.Turn = 1;
                    }
                    else
                    {
                        game.CurrentRound++;

                        if (game.CurrentRound >= 6)
                        {
                            game.FinishedAt = DateTime.UtcNow.ToUniversalTime();
                        }
                    }
                }
                else
                {
                    if (isEvenRound)
                    {
                        game.CurrentRound++;
                    }
                    else
                    {
                        game.Turn = 0;
                    }
                }

                await _gameDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                {
                    _logger.Error("Ошибка при передачи хода", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Возвращает победителя
        /// </summary>
        public async Task<string?> GetWinnerAsync()
        {
            try
            {
                var game = await _gameRepository.GetGameByIdIncludeRoundsAndAnswersAsync(_gameId);

                if (game == null)
                    throw new Exception("Игра не найдена");

                var winnerId = GetWinnerId(game);

                if (winnerId == null)
                {
                    return null;
                }

                return await _userRepository.GetUsernameById(winnerId.Value);
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка при выявлении победителя", ex);
                throw;
            }
        }

        /// <summary>
        /// Возвращает текущую категорию
        /// </summary>
        public async Task<(string category, int round)> GetCurrentCategoryAndRoundAsync()
        {
            try
            {
                var game = await _gameRepository.GetGameByIdIncludeRoundsAsync(_gameId);
                if (game is null)
                {
                    throw new Exception($"Игра с {_gameId} не найдена.");
                }

                var round = game.Rounds.FirstOrDefault(r => r.Index == game.CurrentRound);

                if (round is null)
                {
                    throw new Exception("Раунд не найден");
                }

                var category = await _questionsDbContext.Categories
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == round.CategoryId);

                if (category is null)
                {
                    throw new Exception("Категория не найдена");
                }

                return (category.Name, game.CurrentRound);
            } catch (Exception ex)
            {
                _logger.Error("Не удалось получить категорию", ex);
                throw;
            }
        }

        /// <summary>
        /// Возвращает список лидеров
        /// </summary>
        public async Task<List<LeaderboardEntryDTO>> GetLeaderboardAsync()
        {
            return await _gameDbContext.PlayerAnswers
                .Where(a => a.IsCorrect)
                .GroupBy(a => a.UserId)
                .Select(g => new
                {
                    UserId = g.Key,
                    CorrectAnswers = g.Count()
                })
                .Join(_gameDbContext.Users,
                    g => g.UserId,
                    u => u.Id,
                    (g, u) => new LeaderboardEntryDTO
                    {
                        Username = u.Username,
                        CorrectAnswers = g.CorrectAnswers
                    })
                .OrderByDescending(x => x.CorrectAnswers)
                .Take(100)
                .ToListAsync();
        }

        /// <summary>
        /// Возвращает историю игр
        /// </summary>
        public async Task<List<GameHistoryDTO>> GetGameHistoryAsync(int amount)
        {
            try
            {
                var games = await _gameRepository.GetLastFinishedGamesAsync(_userSessionService.UserID, amount);

                List<GameHistoryDTO> gameHistory = [];

                foreach (var game in games)
                {
                    var opponentId = _userSessionService.UserID == game.Player1Id
                        ? game.Player2Id
                        : game.Player1Id;

                    var opponentUsername = await _userRepository
                        .GetUsernameById(opponentId)
                        ?? string.Empty;

                    gameHistory.Add(new GameHistoryDTO
                    {
                        EndTime = game.FinishedAt!.Value,
                        WinnerId = GetWinnerId(game),
                        OpponentUsername = opponentUsername
                    });
                }

                return gameHistory;
            }
            catch (Exception ex) {
                _logger.Error("Ошибка при загрузке истории игр", ex);
                throw;
            }
        }

        private static Guid? GetWinnerId(Game game)
        {
            int player1Score = 0;
            int player2Score = 0;

            foreach (var round in game.Rounds)
            {
                player1Score += round.PlayerAnswers
                    .Count(a => a.UserId == game.Player1Id && a.IsCorrect);
                player2Score += round.PlayerAnswers
                    .Count(a => a.UserId == game.Player2Id && a.IsCorrect);
            }

            if (player1Score > player2Score)
            {
                return game.Player1Id;
            } 
            else if (player1Score < player2Score)
            {
                return game.Player2Id;
            } 
            else
            {
                return null;
            }
        }
    }
}