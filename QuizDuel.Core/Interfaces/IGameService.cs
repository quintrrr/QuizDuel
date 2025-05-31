namespace QuizDuel.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса управления игрой.
    /// </summary>
    public interface IGameService
    {
        Guid GameId { get; }
        /// <summary>
        /// Создает новую игру с одним игроком.
        /// </summary>
        Task<Guid> CreateGameAsync(Guid player1Id);

        /// <summary>
        /// Устанавливает текущий id игры.
        /// </summary>
        void SetGameId(Guid gameId);

        /// <summary>
        /// Удаляет игру.
        /// </summary>
        Task DeleteGameAsync();

        /// <summary>
        /// Возвращает имена пользьзователей игроков.
        /// </summary>
        Task<(string Player1, string Player2)> GetUsernamesAsync();
    }
}
