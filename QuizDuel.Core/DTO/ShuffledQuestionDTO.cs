namespace QuizDuel.Core.DTO
{
    public class ShuffledQuestionDTO
    {
        public Guid QuestionId { get; set; }

        public string Text { get; set; } = string.Empty;

        public List<string> Answers { get; set; } = [];

        public int CorrectAnswerIndex { get; set; }
    }
}
