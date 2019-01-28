using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipWinFormsEFCore.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace InternshipWinFormsEFCore.Data.Entities
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["BloggingContext"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(new Blog { BlogId = 1, Url = "http://sample.com" });
            modelBuilder.Entity<Post>().HasData(new { BlogId = 1, PostId = 1, Title = "First post", Content = "Test 1" });
        }
    }
}
