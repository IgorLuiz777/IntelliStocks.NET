using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INTELLISTOCKS.MODELS.note;

public class NoteMapping : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.ToTable("INTELLISTOCKS_NOTES");

        builder.HasKey(x => x.ID);
        
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
        
        builder.Property(x => x.Content).IsRequired().HasMaxLength(500);
        
        builder.Property(x => x.CreatedDate).IsRequired();
    }
}