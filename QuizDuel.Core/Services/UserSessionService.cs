using Castle.Core.Logging;
using QuizDuel.Core.Interfaces;

namespace QuizDuel.Core.Services
{
    /// <summary>
    /// Сервис для хранения подключенного пользователя.
    /// </summary>
    public class UserSessionService : IUserSessionService
    {
        private Guid _userID;
        private readonly ILogger _logger;

        public Guid UserID => _userID;

        public UserSessionService(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Устанавливает текущего пользователя
        /// </summary>
        public void SetUser(Guid userID)
        {
            _userID = userID;
            _logger.Info($"Установлен ID текущего пользователя: {userID}");
        }
    }
}
