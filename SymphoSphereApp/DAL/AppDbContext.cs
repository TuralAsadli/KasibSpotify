using Microsoft.EntityFrameworkCore;
using SymphoSphereApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.DAL
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 4. Configure Connection String
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Spotify11;Trusted_Connection=True;");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Song> Songs { get; set; }

    }
}
