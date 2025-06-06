namespace QuizDuel.Core.DTO
{
    /// <summary>
    /// DTO, представляющий текущее состояние игры.
    /// Используется для обновления данных на клиенте.
    /// </summary>
    public class GameStateDTO
    {
        /// <summary>
        /// Номер текущего раунда.
        /// </summary>
        public int CurrentRound { get; set; }

        /// <summary>
        /// Идентификатор игрока, который сейчас должен сделать ход.
        /// </summary>
        public Guid CurrentTurnPlayerId { get; set; }

        /// <summary>
        /// Номер текущего хода внутри раунда.
        /// </summary>
        public int Turn { get; set; }

        /// <summary>
        /// Признак того, что игра уже началась.
        /// </summary>
        public bool IsStarted { get; set; }

        /// <summary>
        /// Признак того, что игра завершена.
        /// </summary>
        public bool IsFinished { get; set; }
    }
}