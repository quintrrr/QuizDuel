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

        /// <summary>
        /// Свойство текущего пользователя
        /// </summary>
        public Guid UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
                _logger.Info($"Установлен ID текущего пользователя: {value}");
            }
        }

        public UserSessionService(ILogger logger)
        {
            _logger = logger;
        }
    }
}
