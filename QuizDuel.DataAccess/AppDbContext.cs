using Microsoft.EntityFrameworkCore;
using QuizDuel.DataAccess.Configurations;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess
{
    /// <summary>
    /// Контекст базы данных приложения, содержащий DbSet и конфигурации сущностей.
    /// </summary>
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
