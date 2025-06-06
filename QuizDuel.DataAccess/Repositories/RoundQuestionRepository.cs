using QuizDuel.DataAccess.Interfaces;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Repositories
{
    public class RoundQuestionRepository : IRoundQuestionRepository
    {
        private readonly GameDbContext _gameDbContext;

        public RoundQuestionRepository(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        public async Task AddAsync(RoundQuestion roundQuestion)
        {
            await _gameDbContext.AddAsync(roundQuestion);
            await _gameDbContext.SaveChangesAsync();
        }
    }
}
