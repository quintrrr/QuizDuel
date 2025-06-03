using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizDuel.DataAccess.Models
{
    /// <summary>
    /// Сущность игры, представляющая данные из таблицы games.
    /// </summary>]
    [Table("games")]
    public class Game
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("player1Id")]
        public Guid Player1Id { get; set; }

        [Column("player2Id")]
        public Guid Player2Id { get; set; }

        [Column("currentRound")]
        public int CurrentRound { get; set; } 

        [Column("turn")]
        public int Turn { get; set; }

        [Column("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();

        [Column("finishedAt")]
        public DateTime? FinishedAt { get; set; }

        public List<Round> Rounds { get; set; } = [];
    }
}
