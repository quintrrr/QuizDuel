namespace QuizDuel.Core.DTO
{
    /// <summary>
    /// DTO, представляющий отправленный игроком ответ на вопрос.
    /// Используется для проверки выбранного варианта.
    /// </summary>
    public class SubmittedAnswerDTO
    {
        /// <summary>
        /// Уникальный идентификатор вопроса, на который дан ответ.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Список всех вариантов ответов, отображённых игроку.
        /// </summary>
        public List<string> Answers { get; set; } = [];

        /// <summary>
        /// Индекс выбранного игроком варианта ответа.
        /// </summary>
        public int SelectedIndex { get; set; }
    }
}