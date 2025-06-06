namespace QuizDuel.Core.DTO
{
    /// <summary>
    /// DTO, представляющий вопрос с перемешанными вариантами ответов.
    /// Используется при передаче вопроса игроку в раунде.
    /// </summary>
    public class ShuffledQuestionDTO
    {
        /// <summary>
        /// Уникальный идентификатор вопроса.
        /// </summary>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Текст вопроса.
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Список вариантов ответов.
        /// </summary>
        public List<string> Answers { get; set; } = [];

        /// <summary>
        /// Индекс правильного ответа в списке.
        /// </summary>
        public int CorrectAnswerIndex { get; set; }
    }
}