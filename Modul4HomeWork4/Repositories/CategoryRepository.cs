using Microsoft.EntityFrameworkCore;
using Modul4HomeWork4.Data;
using Modul4HomeWork4.Data.Entities;
using Modul4HomeWork4.Repositories.Abstractions;
using Modul4HomeWork4.Services.Abstractions;

namespace Modul4HomeWork4.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddCategoryAsync(string name)
        {
            var category = new CategoryEntity()
            {
                Category_Name = name,
            };

            var result = await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<CategoryEntity?> GetCategoryAsync(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateCategoryAsync(int id, string name)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category != null)
            {
                category.Category_Name = name;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
