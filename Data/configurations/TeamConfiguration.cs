using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using IPL.Entities;
using static IPL.Models.Enums;

namespace IPL.Data.configurations
{
    public class TeamConfiguration: IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            //table name and comments
            builder
                .ToTable("Teams")
                .ToTable(t => t.HasComment("Teams Data Table"));

            //primary key
            builder.HasKey(t => t.Id);
            //alternate key: uniqueue key other than primary key
            builder.HasAlternateKey(t => t.Name);

            //make column not null
            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.ShortName)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(t => t.FanBaseType)
                .HasColumnType("int")
                .HasDefaultValue(FanBaseType.None)
                .IsRequired();
            builder.Property(t => t.Trophies)
                .HasColumnType("int")
                .HasColumnName("Total trophies")
                .IsRequired(false);

            builder.Property(t => t.FancyName).
                HasComputedColumnSql("CONCAT(ShortName, ' : ', Name)");

            //relation ships
            builder.HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(t => t.Name)
                .IsUnique(true);

        }
    }
}
