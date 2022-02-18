using DapperDemo.API.Configurations;
using DapperDemo.API.Entities;
using DapperDemo.API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DapperDemo.API.EF
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());


            //Data seeding
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
    }
}
