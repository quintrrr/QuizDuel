using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizDuel.DataAccess.Models
{
    /// <summary>
    /// Сущность вопроса раунда, представляющая данные из таблицы roundQuestions.
    /// </summary>]
    [Table("roundQuestions")]
    public class RoundQuestion
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("roundId")]
        public Guid RoundId { get; set; }

        [Column("questionIndex")]
        public int QuestionIndex { get; set; }

        [Column("questionId")]
        public Guid QuestionId { get; set; }

        public Round? Round { get; set; }
    }
}
