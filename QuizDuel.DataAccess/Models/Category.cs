using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizDuel.DataAccess.Models
{
    /// <summary>
    /// Сущность категории, представляющая данные из таблицы categories.
    /// Категория объединяет связанные вопросы.
    /// </summary>
    [Table("categories")]
    public class Category
    {
        /// <summary>
        /// Уникальный идентификатор категории.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Название категории.
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Список вопросов, относящихся к данной категории.
        /// </summary>
        public List<Question> Questions { get; set; } = [];
    }
}