using Microsoft.EntityFrameworkCore;
using QuizDuel.DataAccess.Interfaces;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuestionsDbContext _questionsDbContext;

        public QuestionRepository(QuestionsDbContext questionsDbContext)
        {
            _questionsDbContext = questionsDbContext;
        }

        /// <summary>
        /// Возвращает вопрос по id.
        /// </summary>
        public async Task<Question?> GetByIdAsync(Guid id)
        {
            return await _questionsDbContext.Questions
               .FirstOrDefaultAsync(q => q.Id == id);
        }


        /// <summary>
        /// Возвращает список вопросов по их id.
        /// </summary>
        public async Task<List<Question>> GetQuestionsByIdsAsync(List<Guid> ids)
        {
            return await _questionsDbContext.Questions
                .Where(q => ids.Contains(q.Id))
                .ToListAsync();
        }

        /// <summary>
        /// Возвращает список случайных вопросов по id категории.
        /// </summary>
        public async Task<List<Question>> GetRandomByCategoryIdAsync(Guid categoryId, int amount)
        {
            return await _questionsDbContext.Questions
                .Where(q => q.CategoryId == categoryId)
                .OrderBy(q => Guid.NewGuid())
                .Take(amount)
                .ToListAsync();
        }
    }
}
