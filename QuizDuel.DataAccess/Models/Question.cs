using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizDuel.DataAccess.Models
{
    /// <summary>
    /// Сущность вопроса, представляющая данные из таблицы questions.
    /// </summary>]
    [Table("questions")]
    public class Question
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("categoryId")]
        public Guid CategoryId { get; set; }

        [Column("text")]
        public string Text { get; set; } = string.Empty;

        [Column("correctAnswer")]
        public string CorrectAnswer { get; set; } = string.Empty;
        
        [Column("incorrect1")]
        public string Incorrect1 { get; set; } = string.Empty;
        
        [Column("incorrect2")]
        public string Incorrect2 { get; set; } = string.Empty;   
       
        [Column("incorrect3")]
        public string Incorrect3 { get; set; } = string.Empty;

        public Category? Category { get; set; } 
    }
}
