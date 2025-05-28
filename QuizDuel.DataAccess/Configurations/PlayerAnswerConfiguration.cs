using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация сущности ответа игрока.
    /// </summary>
    public class PlayerAnswerConfiguration : IEntityTypeConfiguration<PlayerAnswer>
    {
        /// <summary>
        /// Настраивает свойства и ограничения для сущности PlayerAnswer.
        /// </summary>
        public void Configure(EntityTypeBuilder<PlayerAnswer> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .HasOne(a => a.Round)
                .WithMany(r => r.PlayerAnswers)
                .HasForeignKey(a => a.RoundId);
        }
    }
}
