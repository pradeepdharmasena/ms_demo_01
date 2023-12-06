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
        
        //protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
       // {
       //     optionsBuilder.UseInMemoryDatabase(databaseName: "PlatformDb");
       // }

        
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Platform> Platforms { get; set; }

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
