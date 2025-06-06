using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizDuel.DataAccess.Models
{
    /// <summary>
    /// Сущность игры, представляющая данные из таблицы games.
    /// Хранит информацию об участниках, ходе игры и раундах.
    /// </summary>
    [Table("games")]
    public class Game
    {
        /// <summary>
        /// Уникальный идентификатор игры.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор первого игрока.
        /// </summary>
        [Column("player1Id")]
        public Guid Player1Id { get; set; }

        /// <summary>
        /// Идентификатор второго игрока.
        /// Может быть Guid.Empty, если игрок ещё не присоединился.
        /// </summary>
        [Column("player2Id")]
        public Guid Player2Id { get; set; }

        /// <summary>
        /// Текущий раунд игры.
        /// </summary>
        [Column("currentRound")]
        public int CurrentRound { get; set; }

        /// <summary>
        /// Текущий ход.
        /// </summary>
        [Column("turn")]
        public int Turn { get; set; }

        /// <summary>
        /// Дата и время создания игры.
        /// </summary>
        [Column("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();

        /// <summary>
        /// Дата и время завершения игры, если она завершена.
        /// </summary>
        [Column("finishedAt")]
        public DateTime? FinishedAt { get; set; }

        /// <summary>
        /// Список раундов, связанных с данной игрой.
        /// </summary>
        public List<Round> Rounds { get; set; } = [];
    }
}