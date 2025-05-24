using Microsoft.EntityFrameworkCore;
using QuizDuel.DataAccess.Configurations;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess
{
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
