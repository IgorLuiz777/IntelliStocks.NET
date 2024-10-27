using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTELLISTOCKS.MODELS.user;
public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("INTELLISTOCKS_USER");
        
        builder.HasKey(u => u.ID);

        builder.Property(u => u.Name);

        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.Password);
    }
}
