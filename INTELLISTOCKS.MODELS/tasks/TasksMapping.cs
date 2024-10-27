using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INTELLISTOCKS.MODELS.task;

public class TasksMapping : IEntityTypeConfiguration<Tasks>
{
    public void Configure(EntityTypeBuilder<Tasks> builder)
    {
        builder.ToTable("INTELLISTOCKS_TASKS");

        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.Title).IsRequired().HasMaxLength(100);
        
        builder.Property(t => t.Description).HasMaxLength(255);
        
        builder.Property(t => t.Priority).IsRequired();
        
        builder.Property(t => t.DueTo);

        builder.Property(t => t.Status).IsRequired();

        builder.HasOne(t => t.ResponsiblesUser)
            .WithMany() 
            .HasForeignKey(t => t.ResponsiblesUserId) 
            .OnDelete(DeleteBehavior.Restrict);
    }
}