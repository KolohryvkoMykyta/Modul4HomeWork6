using Microsoft.EntityFrameworkCore;
using Modul4HomeWork4.Data.Entities;
using Modul4HomeWork4.Data.EntityConfigurations;

namespace Modul4HomeWork4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BreedEntity> Breeds { get; set; } = null!;
        public DbSet<CategoryEntity> Categories { get; set; } = null!;
        public DbSet<LocationEntity> Locations { get; set; } = null!;
        public DbSet<PetEntity> Pets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BreedConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new PetConfiguration());
            modelBuilder.UseHiLo();
        }
    }
}
