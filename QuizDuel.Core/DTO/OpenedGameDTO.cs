namespace QuizDuel.Core.DTO
{
    /// <summary>
    /// DTO, представляющий открытую (ожидающую второго игрока) игру.
    /// Используется для отображения списка доступных игр для подключения.
    /// </summary>
    public class OpenedGameDTO
    {
        /// <summary>
        /// Уникальный идентификатор игры.
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// Имя пользователя, создавшего игру.
        /// </summary>
        public string HostUsername { get; set; } = string.Empty;
    }
}