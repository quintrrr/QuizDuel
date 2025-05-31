using Microsoft.EntityFrameworkCore;
using QuizDuel.DataAccess.Configurations;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess
{
    /// <summary>
    /// Контекст базы данных приложения, содержащий DbSet и конфигурации сущностей.
    /// </summary>
    public class GameDbContext(DbContextOptions<GameDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<RoundQuestion> RoundQuestions { get; set; }
        public DbSet<PlayerAnswer> PlayerAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new RoundConfiguration());
            modelBuilder.ApplyConfiguration(new RoundQuestionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
