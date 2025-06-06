namespace QuizDuel.Core.DTO
{
    /// <summary>
    /// Представляет вариант ответа на вопрос викторины.
    /// </summary>
    public class AnswerDTO
    {
        /// <summary>
        /// Текст ответа, отображаемый пользователю.
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Указывает, является ли данный ответ правильным.
        /// </summary>
        public bool IsCorrect { get; set; }
    }
}