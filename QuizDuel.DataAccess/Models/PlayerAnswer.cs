using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizDuel.DataAccess.Models
{
    /// <summary>
    /// Сущность ответа игрока, представляющая данные из таблицы playerAnswers.
    /// Сохраняет информацию о выборе игрока на конкретный вопрос в раунде.
    /// </summary>
    [Table("playerAnswers")]
    public class PlayerAnswer
    {
        /// <summary>
        /// Уникальный идентификатор записи.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор раунда, в котором был дан ответ.
        /// </summary>
        [Column("roundId")]
        public Guid RoundId { get; set; }

        /// <summary>
        /// Идентификатор пользователя, который дал ответ.
        /// </summary>
        [Column("userId")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор вопроса, на который был дан ответ.
        /// </summary>
        [Column("questionId")]
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Индекс выбранного варианта ответа.
        /// </summary>
        [Column("selected")]
        public int Selected { get; set; }

        /// <summary>
        /// Указывает, был ли выбранный вариант правильным.
        /// </summary>
        [Column("isCorrect")]
        public bool IsCorrect { get; set; }

        /// <summary>
        /// Навигационное свойство для доступа к связанному раунду.
        /// </summary>
        public Round? Round { get; set; }
    }
}