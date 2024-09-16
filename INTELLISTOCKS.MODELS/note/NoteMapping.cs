using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INTELLISTOCKS.MODELS.note;

public class NoteMapping : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.ToTable("INTELLISTOCKS_NOTES");

        builder.HasKey(n => n.ID);
        
        builder.Property(n => n.Title).IsRequired().HasMaxLength(100);
        
        builder.Property(n => n.Content).IsRequired().HasMaxLength(500);
        
        builder.Property(n => n.CreatedDate).IsRequired();
    }
}