using IPL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IPL.Data.configurations
{
    public class PlayerConfiguration: IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .ToTable("Players")
                .ToTable(p => p.HasComment("Players table"));

            builder.HasKey(p => p.Id);

            builder
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(t => t.TeamId)
                .HasConstraintName("FK_Playey_Team_teamId");

            builder
                .Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("nvarchar(50)")
                .HasDefaultValue("FirstName")
                .IsRequired();

            builder
                .Property(p => p.LastName)
                .HasColumnName("LastName")
                .HasColumnType("nvarchar(50)")
                .HasDefaultValue("LastName")
                .IsRequired();

            builder
                .Property(p => p.JerseyNumber)
                .IsRequired()
                .HasColumnName("ShirtNumber")
                .HasColumnType("int")
                .HasDefaultValue("0");

            builder
                .Property(p => p.TotalRunsScored)
                .HasColumnName("TotalRuns")
                .HasColumnType("int")
                .HasDefaultValue("0");

            builder.HasIndex(p => new { p.FirstName, p.LastName })
                .HasDatabaseName("IX_Players_name")
                .IsClustered(false)
                .IsUnique(false);

        }
    }
}
