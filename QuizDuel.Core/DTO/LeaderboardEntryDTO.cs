namespace QuizDuel.Core.DTO
{
    public class LeaderboardEntryDTO
    {
        public string Username { get; set; } = string.Empty;
        public int CorrectAnswers { get; set; }
    }
}
