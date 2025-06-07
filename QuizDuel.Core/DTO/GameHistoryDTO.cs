namespace QuizDuel.Core.DTO
{
    public class GameHistoryDTO
    {
        public DateTime EndTime { get; set; }    
        public Guid? WinnerId  { get; set; }           
        public string OpponentUsername { get; set; } = string.Empty;
    }
}
