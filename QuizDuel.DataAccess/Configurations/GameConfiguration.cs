using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация сущности игры.
    /// </summary>
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        /// <summary>
        /// Настраивает свойства и ограничения для сущности Game.
        /// </summary>
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.Id);

            builder
                .HasMany(g => g.Rounds)
                .WithOne(r => r.Game)
                .HasForeignKey(r => r.GameId);
        }
    }
}
