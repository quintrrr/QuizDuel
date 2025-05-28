using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация сущности раунда ответа.
    /// </summary>
    public class RoundQuestionConfiguration : IEntityTypeConfiguration<RoundQuestion>
    {
        /// <summary>
        /// Настраивает свойства и ограничения для сущности RoundQuestion.
        /// </summary>
        public void Configure(EntityTypeBuilder<RoundQuestion> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .HasOne(q => q.Round)
                .WithMany(r => r.RoundQuestions)
                .HasForeignKey(q => q.RoundId);
        }
    }
}
