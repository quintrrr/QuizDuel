namespace QuizDuel.Core.DTO
{
    public class SubmittedAnswerDTO
    {
        public Guid Id { get; set; }
        public List<string> Answers { get; set; } = [];
        public int SelectedIndex { get; set; }
    }
}
