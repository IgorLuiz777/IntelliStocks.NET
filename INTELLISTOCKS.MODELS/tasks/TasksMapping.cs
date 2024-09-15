using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INTELLISTOCKS.MODELS.task;

public class TasksMapping : IEntityTypeConfiguration<Tasks>
{
    public void Configure(EntityTypeBuilder<Tasks> builder)
    {
        builder.ToTable("INTELLISTOCKS_TASKS");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
        
        builder.Property(x => x.Description).HasMaxLength(255);
        
        builder.Property(x => x.Priority).IsRequired();
        
        builder.Property(x => x.DueTo);

        builder.Property(x => x.Status).IsRequired();
    }
}