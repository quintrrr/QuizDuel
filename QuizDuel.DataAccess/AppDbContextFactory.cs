using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using QuizDuel.DataAccess.Classes;

namespace QuizDuel.DataAccess
{
    class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(CreateConnectionString());
            return new AppDbContext(optionsBuilder.Options);
        }

        
        private static string CreateConnectionString()
        {
            var envReader = new EnvReader();
            envReader.TryLoad("../../../../.env");
            var host = Environment.GetEnvironmentVariable("DB_HOST");
            var port = Environment.GetEnvironmentVariable("DB_PORT");
            var username = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var database = Environment.GetEnvironmentVariable("DB_NAME");
            return $"Host={host};Port={port};Username={username};" +
                                    $"Password={password};Database={database}";
        }
    }
}
