using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация сущности раунда.
    /// </summary>
    public class RoundConfiguration : IEntityTypeConfiguration<Round>
    {
        /// <summary>
        /// Настраивает свойства и ограничения для сущности Round.
        /// </summary>
        public void Configure(EntityTypeBuilder<Round> builder)
        {
            builder.HasKey(r => r.Id);

            builder
                .HasOne(r => r.Game)
                .WithMany(g => g.Rounds)
                .HasForeignKey(r => r.GameId);

            builder
                .HasMany(r => r.RoundQuestions)
                .WithOne(rq => rq.Round)
                .HasForeignKey(rq => rq.RoundId);

            builder
                .HasMany(r => r.PlayerAnswers)
                .WithOne(a => a.Round)
                .HasForeignKey(a => a.RoundId);
        }
    }
}
