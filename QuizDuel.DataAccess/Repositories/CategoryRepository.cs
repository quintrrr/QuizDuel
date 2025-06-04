using Microsoft.EntityFrameworkCore;
using QuizDuel.DataAccess.Interfaces;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly QuestionsDbContext _db;
        public CategoryRepository(QuestionsDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Возвращает список случайных категорий из базы данных.
        /// </summary>
        public async Task<List<Category>> GetRandomCategoriesAsync(int amount)
        {
            return await _db.Categories
                .OrderBy(c => Guid.NewGuid())
                .Take(amount)
                .ToListAsync();
        }
    }
}
