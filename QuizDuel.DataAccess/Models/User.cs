using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizDuel.DataAccess.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        [Column("username", TypeName = "varchar(50)")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("passwordHash", TypeName = "varchar(255)")]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("salt", TypeName = "varchar(255)")]
        public string Salt { get; set; } = string.Empty;

        [Column("picture", TypeName = "varchar(255)")]
        public string? Picture { get; set; }

        [Column("birthdate")]
        public DateTime? BirthDate { get; set; }
    }
}
