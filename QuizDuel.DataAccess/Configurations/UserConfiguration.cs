using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация сущности пользователя.
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Настраивает свойства и ограничения для сущности User.
        /// </summary>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            
        }
    }
}
