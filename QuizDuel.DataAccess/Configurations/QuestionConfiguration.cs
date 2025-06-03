using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация сущности вопроса.
    /// </summary>
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        /// <summary>
        /// Настраивает свойства и ограничения для сущности Question.
        /// </summary>
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.Id);
        }
    }
}
