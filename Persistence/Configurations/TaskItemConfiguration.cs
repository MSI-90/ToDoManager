using Entities.Enums;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.HasData(
            new TaskItem
            {
                Id = new Guid("60abbca8-664d-4b20-b5de-024705497d4a"),
                Title = "Попить кофе",
                Description = "Пить кофе весело, пить кофе хорошо)",
                PriorityTask = Priority.low,
                CreatedAt = DateTime.UtcNow,
                ExpirationDate = new DateTime(2024, 7, 6, 23, 34, 42, 361, DateTimeKind.Utc),
                CategoryId = new Guid("c3d4c014-49b6-410c-bc78-1d54a9991870")
            });
    }
}
