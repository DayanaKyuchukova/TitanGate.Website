using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TitanGate.Website.Domain.Entities;

namespace TitanGate.Website.DAL.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="Category"/> entity.
    /// </summary>
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));

            builder.HasKey(c => c.Id);

            builder
                .HasOne(c => c.ParentCategory)
                .WithMany(pc => pc.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryId);

            builder.HasData(
                new Category[]
                {
                    new Category { Id = 1, Name = "news"},
                    new Category { Id = 2, Name = "online store"},
                    new Category { Id = 3, Name = "online jewelry", ParentCategoryId = 2}
                });
        }
    }
}
