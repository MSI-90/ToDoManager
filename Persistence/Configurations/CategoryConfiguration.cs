using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category
            {
                Id = new Guid("c3d4c014-49b6-410c-bc78-1d54a9991870"),
                Title = "Досуг",
                Description = "Здесь как правило нет каких то значимых дел"
            });
    }
}
