using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizDuel.DataAccess.Models
{
    /// <summary>
    /// Сущность категории, представляющая данные из таблицы categories.
    /// </summary>]
    [Table("categories")]
    public class Category
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        public List<Question> Questions { get; set; } = [];
    }
}
