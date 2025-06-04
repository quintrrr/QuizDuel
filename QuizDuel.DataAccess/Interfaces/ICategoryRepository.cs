using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Interfaces
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Возвращает список случайных категорий из базы данных.
        /// </summary>
        Task<List<Category>> GetRandomCategoriesAsync(int amount);
    }
}
