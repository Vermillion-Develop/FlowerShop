using FlowerShopSharedModels.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FlowerShopBackground.Data
{
    public class AppDataContext: DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Datalogs> DatalogsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().ToTable("roles");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Street>().ToTable("streets");
            modelBuilder.Entity<Datalogs>().ToTable("datalogs");
            

        }
    }
}
