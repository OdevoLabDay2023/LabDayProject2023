using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorkOrderManager.Database;

public class WorkOrderEntityConfiguration : IEntityTypeConfiguration<WorkOrderEntity>
{

    public void Configure(EntityTypeBuilder<WorkOrderEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasAlternateKey(x => x.OrderNumber);

        builder.Property(x => x.OrderNumber)
            .HasMaxLength(20);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.Reference)
            .HasMaxLength(100);

        builder.Property(x => x.Type)
            .HasMaxLength(10);

    }
}