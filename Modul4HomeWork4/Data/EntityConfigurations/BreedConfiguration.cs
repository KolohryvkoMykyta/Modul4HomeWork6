using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul4HomeWork4.Data.Entities;

namespace Modul4HomeWork4.Data.EntityConfigurations
{
    public class BreedConfiguration : IEntityTypeConfiguration<BreedEntity>
    {
        public void Configure(EntityTypeBuilder<BreedEntity> builder)
        {
            builder.HasKey(h => h.Id);

            builder.HasOne(b => b.Category)
                .WithMany(c => c.Breeds)
                .HasForeignKey(b => b.Category_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
