using FA.JustBlog.Core.Configs;
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.DataContext
{
    public class JustBlogContext : DbContext
    {
        public JustBlogContext() { }

        public JustBlogContext(DbContextOptions<JustBlogContext> options) : base(options) { }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<PostTagMap> PostTagMap { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectString = @"server=.;database=JustBlog_DuongVanCong;Trusted_Connection=Yes;TrustServerCertificate=True";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoriesConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostsConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TagsConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostTagMapConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Comment).Assembly);

            modelBuilder.Seed();
        }
    }
}
