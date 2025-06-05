namespace QuizDuel.Core.DTO
{
    /// <summary>
    /// Объект передачи статуса игры
    /// </summary>
    public class GameStateDTO
    {
        public int CurrentRound { get; set; }

        public Guid CurrentTurnPlayerId { get; set; }

        public bool IsStarted { get; set; }

        public bool IsFinished { get; set; }
    }
}
