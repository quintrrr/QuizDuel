using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizDuel.DataAccess.Models
{
    /// <summary>
    /// Сущность ответа игрока, представляющая данные из таблицы playerAnswers.
    /// </summary>]
    [Table("playerAnswers")]
    public class PlayerAnswers
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("roundId")]
        public Guid RoundId { get; set; }

        [Column("userId")]
        public Guid UserId { get; set; }

        [Column("questionId")]
        public Guid QuestionId { get; set; }

        [Column("selected")]
        public int Selected { get; set; }

        [Column("isCorrect")]
        public bool IsCorrect { get; set; }

        public Round? Round { get; set; }
    }
}
