namespace QuizDuel.Core.DTO
{
    /// <summary>
    /// Представляет результат ответа игрока на вопрос.
    /// </summary>
    public class AnswerResultDTO
    {
        /// <summary>
        /// Указывает, был ли ответ игрока правильным.
        /// </summary>
        public bool IsCorrect { get; set; }

        /// <summary>
        /// Индекс правильного варианта ответа.
        /// </summary>
        public int CorrectOptionIndex { get; set; }
    }
}