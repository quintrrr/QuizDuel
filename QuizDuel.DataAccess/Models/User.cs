using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizDuel.DataAccess.Models
{
    /// <summary>
    /// Сущность пользователя, представляющая данные из таблицы users.
    /// Содержит данные, необходимые для идентификации и аутентификации игрока.
    /// </summary>
    [Table("users")]
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя.
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Column("username", TypeName = "varchar(50)")]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Хэш пароля пользователя.
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("passwordHash", TypeName = "varchar(255)")]
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// Соль, использованная при хэшировании пароля.
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("salt", TypeName = "varchar(255)")]
        public string Salt { get; set; } = string.Empty;

        /// <summary>
        /// Путь к изображению профиля пользователя.
        /// </summary>
        [Column("picture", TypeName = "varchar(255)")]
        public string Picture { get; set; } = string.Empty;

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        [Column("birthdate")]
        public DateTime? Birthdate { get; set; }
    }
}