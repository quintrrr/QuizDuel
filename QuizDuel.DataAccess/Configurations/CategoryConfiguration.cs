using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizDuel.DataAccess.Models;

namespace QuizDuel.DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация сущности категории.
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        /// <summary>
        /// Настраивает свойства и ограничения для сущности Category.
        /// </summary>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
