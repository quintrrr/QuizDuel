﻿using QuizDuel.Core.DTO;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса управления игрой.
    /// </summary>
    public interface IGameService
    {
        Guid GameId { get; set; }

        /// <summary>
        /// Создает новую игру с одним игроком.
        /// </summary>
        Task<Guid> CreateGameAsync(Guid player1Id);

        /// <summary>
        /// Удаляет игру.
        /// </summary>
        Task DeleteGameAsync();

        /// <summary>
        /// Возвращает имена пользьзователей игроков.
        /// </summary>
        Task<(string? Player1, string? Player2)> GetUsernamesAsync();

        /// <summary>
        /// Возвращает статус игры.
        /// </summary>
        Task<GameStateDTO> GetGameStateAsync();

        /// <summary>
        /// Возвращает список неначатых игр.
        /// </summary>
        Task<List<OpenedGameDTO>> GetOpenedGamesAsync();

        /// <summary>
        /// Присоединяет второго игрока к игре.
        /// </summary>
        Task<OperationResultDTO> JoinGameAsync();

        /// <summary>
        /// Возвращает список случайных категорий.
        /// </summary>
        Task<List<Category>> GetRandomCategoriesAsync(int amount);

        /// <summary>
        /// Выбирает категорию.
        /// </summary>
        Task SelectCategoryAsync(Guid categoryId);

        /// <summary>
        /// Возвращает список вопросов с перемешанными ответами. 
        /// </summary>
        Task<List<ShuffledQuestionDTO>> GetShuffledQuestionsAsync(int amount);

        /// <summary>
        /// Подтверждает ответ пользователя.
        /// </summary>
        Task<AnswerResultDTO> SubmitAnswerAsync(Guid userId, SubmittedAnswerDTO answer);

        /// <summary>
        /// Возвращает счет игроков
        /// </summary>
        Task<(int player1Score, int player2Score)> GetScoresAsync();

        /// <summary>
        /// Передает ход следующему игроку
        /// </summary>
        Task PassTurnAsync();

        /// <summary>
        /// Возвращает победителя
        /// </summary>
        Task<string?> GetWinnerAsync();

        /// <summary>
        /// Возвращает текущую категорию
        /// </summary>
        Task<(string category, int round)> GetCurrentCategoryAndRoundAsync();

        /// <summary>
        /// Возвращает список лидеров
        /// </summary>
        Task<List<LeaderboardEntryDTO>> GetLeaderboardAsync();

        /// <summary>
        /// Возвращает историю игр
        /// </summary>
        Task<List<GameHistoryDTO>> GetGameHistoryAsync(int amount);
    }
}
