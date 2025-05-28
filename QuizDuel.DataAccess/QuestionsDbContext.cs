using Microsoft.EntityFrameworkCore;
using QuizDuel.DataAccess.Configurations;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess
{
    /// <summary>
    /// Контекст базы данных вопросов, содержащий DbSet и конфигурации сущностей.
    /// </summary>
    public class QuestionsDbContext(DbContextOptions<QuestionsDbContext> options) : DbContext(options)
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
