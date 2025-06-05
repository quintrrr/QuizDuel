using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Interfaces
{
    public interface IQuestionRepository
    {
        /// <summary>
        /// Возвращает вопрос по id.
        /// </summary>
        Task<Question?> GetByIdAsync(Guid id);

        /// <summary>
        /// Возвращает список вопросов по их id.
        /// </summary>
        Task<List<Question>> GetQuestionsByIdsAsync(List<Guid> ids);

        /// <summary>
        /// Возвращает список случайных вопросов по id категории.
        /// </summary>
        Task<List<Question>> GetRandomByCategoryIdAsync(Guid categoryId, int amount);
    }
}
