using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul4HomeWork4.Data.Entities;

namespace Modul4HomeWork4.Data.EntityConfigurations
{
    public class PetConfiguration : IEntityTypeConfiguration<PetEntity>
    {
        public void Configure(EntityTypeBuilder<PetEntity> builder)
        {
            builder.HasKey(h => h.Id);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Pets)
                .HasForeignKey(p => p.Category_Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Breed)
                .WithMany(b => b.Pets)
                .HasForeignKey(p => p.Breed_Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Location)
                .WithMany(l => l.Pets)
                .HasForeignKey(p => p.Location_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
