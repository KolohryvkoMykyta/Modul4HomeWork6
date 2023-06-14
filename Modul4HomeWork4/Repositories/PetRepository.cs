using Microsoft.EntityFrameworkCore;
using Modul4HomeWork4.Data;
using Modul4HomeWork4.Data.Entities;
using Modul4HomeWork4.Repositories.Abstractions;
using Modul4HomeWork4.Services.Abstractions;

namespace Modul4HomeWork4.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PetRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddPetAsync(
            string name,
            float age,
            int categoryId,
            int breedId,
            int locationId,
            string imageUrl,
            string description)
        {
            var pet = new PetEntity()
            {
                Name = name,
                Age = age,
                Category_Id = categoryId,
                Breed_Id = breedId,
                Location_Id = locationId,
                Image_url = imageUrl,
                Description = description
            };

            var result = await _dbContext.Pets.AddAsync(pet);
            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }
        public async Task<PetEntity?> GetPetAsync(int id)
        {
            return await _dbContext.Pets.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task UpdatePetAsync(
            int id,
            string name,
            float age,
            int categoryId,
            int breedId,
            int locationId,
            string imageUrl,
            string description)
        {
            var pet = await _dbContext.Pets.FirstOrDefaultAsync(pet => pet.Id == id);

            if (pet != null)
            {
                pet.Name = name;
                pet.Age = age;
                pet.Category_Id = categoryId;
                pet.Breed_Id = breedId;
                pet.Location_Id = locationId;
                pet.Image_url = imageUrl;
                pet.Description = description;

                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task DeletePetAsync(int id)
        {
            var pet = await _dbContext.Pets.FirstOrDefaultAsync(pet => pet.Id == id);

            if (pet != null)
            {
                _dbContext.Pets.Remove(pet);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<IReadOnlyList<SpecialEntity>> SpecialRequestAsync()
        {
            return await _dbContext.Pets.Include(p => p.Breed)
                .Include(p => p.Category)
                .Include(p => p.Location)
                .Where(p => p.Age > 3 && p.Location.Location_Name == "Ukraine")
                .Select(p => new
                {
                    CategoryName = p.Category.Category_Name,
                    BreedName = p.Breed.Breed_Name
                })
                .GroupBy(p => p.CategoryName)
                .Select(p => new SpecialEntity()
                {
                    CategoryName = p.Key,
                    CountBreed = p.Distinct().Count()
                }).ToListAsync();
        }
    }
}
