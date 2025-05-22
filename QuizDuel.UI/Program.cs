using Microsoft.EntityFrameworkCore;
using QuizDuel.DataAccess;

namespace QuizDuel.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(CreateConnectionString());
            var db = new AppDbContext(optionsBuilder.Options);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(db));
        }

        private static string CreateConnectionString()
        {
            try
            {
                EnvReader.TryLoad("../../../../.env");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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