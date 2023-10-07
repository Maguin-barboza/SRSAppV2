using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SRSAppV2.Domain.Entities;

namespace SRSAppV2.Infra.Context.Maps;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).HasMaxLength(50);
        builder.Property(x => x.LastName).HasMaxLength(150);
        builder.Property(x => x.Email).HasMaxLength(50);
        builder.Property(x => x.Password).HasMaxLength(32);
    }
}
