using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INTELLISTOCKS.MODELS.events;

public class EventsMapping : IEntityTypeConfiguration<Events>
{
    public void Configure(EntityTypeBuilder<Events> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Title).HasMaxLength(100).IsRequired();
        
        builder.Property(e => e.Description).HasMaxLength(500).IsRequired();
        
        builder.Property(e => e.StartDate).HasColumnType("date");
        
        builder.Property(e => e.EndDate).HasColumnType("date");
        
        builder.Property(e => e.Location).HasMaxLength(100).IsRequired();
    }
}