using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Interfaces
{
    public interface IRoundQuestionRepository
    {
        Task AddAsync(RoundQuestion roundQuestion);
    }
}
