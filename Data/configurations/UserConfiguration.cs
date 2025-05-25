using IPL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IPL.Data.configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Email)
                .IsRequired();

            builder.HasIndex(s => s.Email).IsUnique();

            builder.Property(s => s.Name).IsRequired();

            builder.HasIndex(s => new { s.Name, s.Email });
        }
    }
}
