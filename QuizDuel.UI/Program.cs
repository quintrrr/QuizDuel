using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuizDuel.Core.Services;
using QuizDuel.DataAccess;
using QuizDuel.DataAccess.Classes;
using QuizDuel.DataAccess.Repositories;
using QuizDuel.UI.Classes;

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
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();
            var form = host.Services.GetRequiredService<Form1>();
            
            Application.Run(form);
        }


        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((provider, services) =>
                {
                    services.AddSingleton<IConnectionStringBuilder, ConnectionStringBuilder>();
                    services.AddSingleton<IEnvReader, EnvReader>();
                    services.AddSingleton<IPasswordService, PasswordService>();
                    services.AddSingleton<IErrorService, WinFormsErrorService>();

                    services.AddDbContext<AppDbContext>((provider, options) =>
                    {
                        var connectionStringBuilder = provider.GetRequiredService<IConnectionStringBuilder>();
                        options.UseNpgsql(connectionStringBuilder.CreateConnectionString());
                    });

                    services.AddTransient<IUserRepository, UserRepository>();
                    services.AddTransient<Form1>();
                });
        }
    }
}