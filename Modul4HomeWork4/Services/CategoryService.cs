using Microsoft.Extensions.Logging;
using Modul4HomeWork4.Data;
using Modul4HomeWork4.Models;
using Modul4HomeWork4.Repositories.Abstractions;
using Modul4HomeWork4.Services.Abstractions;

namespace Modul4HomeWork4.Services
{
    public class CategoryService : BaseDataService<ApplicationDbContext>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _loggerService;

        public CategoryService(
            ICategoryRepository categoryRepository, 
            ILogger<CategoryService> loggerService,
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger)
            : base (dbContextWrapper, logger)
        {
            _categoryRepository = categoryRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddCategoryAsync(string name)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _categoryRepository.AddCategoryAsync(name);
                _loggerService.LogInformation($"Create Category: Id: {id}, Category_Name {name}");
                return id;
            });
        }

        public async Task<Category?> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);

            if (category == null)
            {
                _loggerService.LogInformation($"Could not find category {id}");
                return null;
            }

            return new Category()
            {
                Id = category.Id,
                Category_Name = category.Category_Name
            };
        }

        public async Task UpdateCategoryAsync(int id, string name)
        {
            await ExecuteSafeAsync(async () =>
            {
                await _categoryRepository.UpdateCategoryAsync(id, name);
                _loggerService.LogInformation($"Category was updated: Id: {id}, Name: {name}");
            });
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                await _categoryRepository.DeleteCategoryAsync(id);
                _loggerService.LogInformation($"Category: {id} was deleted");
            });
        }

    }
}
