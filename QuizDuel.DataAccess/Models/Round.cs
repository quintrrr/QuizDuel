using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizDuel.DataAccess.Models
{
    /// <summary>
    /// Сущность раунда, представляющая данные из таблицы rounds.
    /// Раунд содержит вопросы и ответы игроков в рамках одной категории.
    /// </summary>
    [Table("rounds")]
    public class Round
    {
        /// <summary>
        /// Уникальный идентификатор раунда.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор игры, к которой принадлежит раунд.
        /// </summary>
        [Column("gameId")]
        public Guid GameId { get; set; }

        /// <summary>
        /// Порядковый номер раунда в игре.
        /// </summary>
        [Column("index")]
        public int Index { get; set; }

        /// <summary>
        /// Идентификатор категории, выбранной для раунда.
        /// </summary>
        [Column("categoryId")]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Навигационное свойство для доступа к игре, в которой проходит раунд.
        /// </summary>
        public Game? Game { get; set; }

        /// <summary>
        /// Список вопросов, включённых в этот раунд.
        /// </summary>
        public List<RoundQuestion> RoundQuestions { get; set; } = [];

        /// <summary>
        /// Список ответов игроков, данных в этом раунде.
        /// </summary>
        public List<PlayerAnswer> PlayerAnswers { get; set; } = [];
    }
}