using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizDuel.DataAccess.Models
{
    /// <summary>
    /// Сущность раунда, представляющая данные из таблицы rounds.
    /// </summary>]
    [Table("rounds")]
    public class Round
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("gameId")]
        public Guid GameId { get; set; }

        [Column("index")]
        public int Index { get; set; }

        [Column("categoryId")]
        public Guid CategoryId { get; set; }

        public Game? Game { get; set; }

        public List<RoundQuestion> RoundQuestions { get; set; } = [];

        public List<PlayerAnswer> PlayerAnswers { get; set; } = [];
    }
}
