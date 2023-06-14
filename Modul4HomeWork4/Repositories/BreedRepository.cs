using Microsoft.EntityFrameworkCore;
using Modul4HomeWork4.Data;
using Modul4HomeWork4.Data.Entities;
using Modul4HomeWork4.Repositories.Abstractions;
using Modul4HomeWork4.Services.Abstractions;

namespace Modul4HomeWork4.Repositories
{
    public class BreedRepository : IBreedRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public BreedRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _DbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddBreedAsync(string name, int categoryId)
        {
            var result = await _DbContext.Breeds.AddAsync(new BreedEntity()
            {
                Breed_Name = name,
                Category_Id = categoryId
            });

            await _DbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<BreedEntity?> GetBreedAsync(int id)
        {
            return await _DbContext.Breeds.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateBreedAsync(int id, string name,  int categoryId)
        {
            var breed = await _DbContext.Breeds.FirstOrDefaultAsync(b => b.Id == id);
            
            if (breed != null)
            {
                breed.Breed_Name = name;
                breed.Category_Id = categoryId;
                await _DbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteBreedAsync(int id)
        {
            var breed = await _DbContext.Breeds.FirstOrDefaultAsync(b => b.Id == id);

            if (breed != null)
            {
                _DbContext.Breeds.Remove(breed);
                await _DbContext.SaveChangesAsync();
            }
        }

    }
}
