using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Pieski.Entities;

namespace Pieski
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Breed> Breeds { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breed>().HasKey(b => b.Id);
            modelBuilder.Entity<Dog>().HasKey(d => d.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
