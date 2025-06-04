using QuizDuel.Core.DTO;
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
    }
}
