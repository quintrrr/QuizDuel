namespace QuizDuel.Core.DTO
{
    /// <summary>
    /// Объект передачи открытой игры.
    /// </summary>
    public class OpenedGameDTO
    {
        public Guid GameId { get; set; }

        public string HostUsername { get; set; } = string.Empty;
    }
}
