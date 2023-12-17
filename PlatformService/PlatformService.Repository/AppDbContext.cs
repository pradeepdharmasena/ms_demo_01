using Microsoft.EntityFrameworkCore;
using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PlatformService.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=mssql-cluster-ip-service,1433;Initial Catalog=platformdb; User ID=sa; Password=Yatipasgama#1;Encrypt=True;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Platform>().HasData(
                new Platform {Id = 1, Name = "Kubanetes", Publisher = "Google", Version = "1.0.0" },
                new Platform {Id = 2, Name = "Docker", Publisher = "Google", Version = "1.0.0" },
                new Platform {Id = 3, Name = "Asure", Publisher = "Microsoft", Version = "1.0.0" },
                new Platform {Id = 4, Name = "AWS", Publisher = "Amason", Version = "1.0.0" }
                );
        }

       
    }
}
