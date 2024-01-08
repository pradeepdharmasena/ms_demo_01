using CommandService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandService.Repository
{
    public class AppDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=mssql-cluster-ip-service,1433;Initial Catalog=commanddb; User ID=sa; Password=Yatipasgama#1;Encrypt=True;TrustServerCertificate=True;";
            //mssql-cluster-ip-service
            //localhost
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Platform> Platforms { get; set; }

        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Platform>()
                .HasMany(p => p.Commands)
                .WithOne(p => p.Platform!)
                .HasForeignKey(p => p.PlatformId);

            modelBuilder
                .Entity<Command>()
                .HasOne(p => p.Platform)
                .WithMany(p => p.Commands)
                .HasForeignKey(p => p.PlatformId);
        }



    }
}