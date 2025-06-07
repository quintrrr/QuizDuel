using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностями игры.
    /// </summary>
    public interface IGameRepository
    {
        /// <summary>
        /// Асихронно добавляет игру в базу данных.
        /// </summary>
        Task AddAsync(Game game);

        /// <summary>
        /// Асихронно удаляет игру из базы данных.
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Асихронно получает игру по id из базы данных.
        /// </summary>
        Task<Game?> GetGameByIdAsync(Guid id);

        /// <summary>
        /// Асихронно возвращает список неначатых игр из базы данных.
        /// </summary>
        Task<List<Game>> GetOpenedGamesAsync();

        /// <summary>
        /// Асихронно добавляет второго игрока в игру.
        /// </summary>
        Task AddSecondPlayerToGameAsync(Game game, Guid userId);

        /// <summary>
        /// Асихронно получает игру по id c раундами из базы данных.
        /// </summary>
        Task<Game?> GetGameByIdIncludeRoundsAsync(Guid id);

        /// <summary>
        /// Асихронно получает игру по id c раундами и вопросами из базы данных.
        /// </summary>
        Task<Game?> GetGameByIdIncludeRoundsAndQuestionsAsync(Guid id);

        /// <summary>
        /// Асихронно получает игру по id c раундами и ответами из базы данных.
        /// </summary>
        Task<Game?> GetGameByIdIncludeRoundsAndAnswersAsync(Guid id);

        /// <summary>
        /// Получает последние завершенные игры по id пользователя.
        /// </summary>
        Task<List<Game>> GetLastFinishedGamesAsync(Guid userId, int amount);
    }
}
