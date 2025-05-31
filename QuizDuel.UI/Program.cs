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
            var navigation = container.Resolve<INavigationService>();
            navigation.NavigateTo<MainForm>();

            Application.Run();
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
                .LifestyleSingleton(),
                
                Component.For<IUserSessionService>()
                .ImplementedBy<UserSessionService>()
                .LifestyleSingleton(),
                
                Component.For<IGameService>()
                .ImplementedBy<GameService>()
                .LifestyleSingleton(),
                
                Component.For<INavigationService>()
                .ImplementedBy<NavigationService>()
                .LifestyleSingleton()
            );

            var connectionStringBuilder = container.Resolve<IConnectionStringBuilder>();

            try
            {
                var gameOptions = new DbContextOptionsBuilder<GameDbContext>()
                    .UseNpgsql(connectionStringBuilder.CreateGameConnectionString()).Options;
                
                var questionsOptions = new DbContextOptionsBuilder<QuestionsDbContext>()
                    .UseNpgsql(connectionStringBuilder.CreateQuestionsConnectionString()).Options;

                container.Register(
                    Component.For<DbContextOptions<GameDbContext>>()
                    .Instance(gameOptions)
                    .LifestyleSingleton(),

                    Component.For<DbContextOptions<QuestionsDbContext>>()
                    .Instance(questionsOptions)
                    .LifestyleSingleton(),

                    Component.For<GameDbContext>().LifestyleSingleton(),

                    Component.For<QuestionsDbContext>().LifestyleSingleton()
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Process.GetCurrentProcess().Kill();
            }

            container.Register(
                Component.For<IWindsorContainer>().Instance(container),

                Component.For<IUserRepository>()
                .ImplementedBy<UserRepository>()
                .LifestyleTransient(),

                Component.For<IGameRepository>()
                .ImplementedBy<GameRepository>()
                .LifestyleTransient(),

                Component.For<IAuthService>()
                .ImplementedBy<AuthService>()
                .LifestyleTransient(),

                Component.For<Form1>()
                .LifestyleTransient(),

                Component.For<LoginForm>()
                .LifestyleTransient(),

                Component.For<MainForm>()
                .LifestyleTransient(),

                Component.For<WaitingForm>()
                .LifestyleTransient()
            );
        }
    }
}