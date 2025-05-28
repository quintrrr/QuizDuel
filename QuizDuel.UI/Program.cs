using System.Diagnostics;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;
using QuizDuel.Core.Interfaces;
using QuizDuel.Core.Services;
using QuizDuel.DataAccess;
using QuizDuel.DataAccess.Classes;
using QuizDuel.DataAccess.Interfaces;
using QuizDuel.DataAccess.Repositories;
using QuizDuel.UI.Classes;

namespace QuizDuel.UI
{
    /// <summary>
    /// Главная точка входа в -приложение.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Точка входа приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var container = new WindsorContainer();
            ConfigureContainer(container);
            var form = container.Resolve<Form1>();

            Application.Run(form);
        }

        /// <summary>
        /// Регистрирует все зависимости в контейнере Castle Windsor.
        /// </summary>
        private static void ConfigureContainer(IWindsorContainer container)
        {
            container.AddFacility<LoggingFacility>(f => 
                f.LogUsing<NLogFactory>()
            );

            container.Register(
                Component.For<IConnectionStringBuilder>()
                .ImplementedBy<ConnectionStringBuilder>()
                .LifestyleSingleton(),

                Component.For<IEnvReader>()
                .ImplementedBy<EnvReader>()
                .LifestyleSingleton(),

                Component.For<IPasswordService>()
                .ImplementedBy<PasswordService>()
                .LifestyleSingleton(),
                
                Component.For<INotificationService>()
                .ImplementedBy<WinFormsNotificationService>()
                .LifestyleSingleton(),
                
                Component.For<IRegisterValidator>()
                .ImplementedBy<RegisterValidator>()
                .LifestyleSingleton(),
                
                Component.For<IPasswordValidator>()
                .ImplementedBy<PasswordValidator>()
                .LifestyleSingleton()
            );

            var connectionStringBuilder = container.Resolve<IConnectionStringBuilder>();

            try
            {
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseNpgsql(connectionStringBuilder.CreateConnectionString()).Options;

                container.Register(
                    Component.For<DbContextOptions<AppDbContext>>()
                    .Instance(options)
                    .LifestyleSingleton(),

                    Component.For<AppDbContext>().LifestyleSingleton()
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Process.GetCurrentProcess().Kill();
            }

            container.Register(
                Component.For<IUserRepository>()
                .ImplementedBy<UserRepository>()
                .LifestyleTransient(),

                Component.For<IAuthService>()
                .ImplementedBy<AuthService>()
                .LifestyleTransient(),

                Component.For<Form1>()
                .LifestyleTransient()
            );
        }
    }
}