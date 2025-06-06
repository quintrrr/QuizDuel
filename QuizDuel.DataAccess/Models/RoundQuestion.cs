using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizDuel.DataAccess.Models
{
    /// <summary>
    /// Сущность вопроса раунда, представляющая данные из таблицы roundQuestions.
    /// Связывает конкретный вопрос с раундом и его порядком отображения.
    /// </summary>
    [Table("roundQuestions")]
    public class RoundQuestion
    {
        /// <summary>
        /// Уникальный идентификатор записи.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор раунда, к которому относится вопрос.
        /// </summary>
        [Column("roundId")]
        public Guid RoundId { get; set; }

        /// <summary>
        /// Порядковый номер вопроса в раунде.
        /// </summary>
        [Column("questionIndex")]
        public int QuestionIndex { get; set; }

        /// <summary>
        /// Идентификатор вопроса из таблицы questions.
        /// </summary>
        [Column("questionId")]
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Навигационное свойство для доступа к родительскому раунду.
        /// </summary>
        public Round? Round { get; set; }
    }
}