using IPL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace IPL.Data
{
    public class IPLDbContext : DbContext
    {
        public IPLDbContext(DbContextOptions<IPLDbContext> options): base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IPLDbContext).Assembly);
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
