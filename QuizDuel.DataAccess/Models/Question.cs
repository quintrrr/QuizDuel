using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizDuel.DataAccess.Models
{
    /// <summary>
    /// Сущность вопроса, представляющая данные из таблицы questions.
    /// Содержит текст вопроса, правильный и неправильные варианты ответа.
    /// </summary>
    [Table("questions")]
    public class Question
    {
        /// <summary>
        /// Уникальный идентификатор вопроса.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор категории, к которой относится вопрос.
        /// </summary>
        [Column("categoryId")]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Текст вопроса, отображаемый пользователю.
        /// </summary>
        [Column("text")]
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Правильный вариант ответа.
        /// </summary>
        [Column("correctAnswer")]
        public string CorrectAnswer { get; set; } = string.Empty;

        /// <summary>
        /// Первый неправильный вариант ответа.
        /// </summary>
        [Column("incorrect1")]
        public string Incorrect1 { get; set; } = string.Empty;

        /// <summary>
        /// Второй неправильный вариант ответа.
        /// </summary>
        [Column("incorrect2")]
        public string Incorrect2 { get; set; } = string.Empty;

        /// <summary>
        /// Третий неправильный вариант ответа.
        /// </summary>
        [Column("incorrect3")]
        public string Incorrect3 { get; set; } = string.Empty;

        /// <summary>
        /// Навигационное свойство для доступа к категории вопроса.
        /// </summary>
        public Category? Category { get; set; }
    }
}