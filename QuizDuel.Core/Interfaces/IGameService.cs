namespace QuizDuel.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса управления игрой.
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Создает новую игру с одним игроком.
        /// </summary>
        Task CreateGameAsync(Guid player1Id);
    }
}
