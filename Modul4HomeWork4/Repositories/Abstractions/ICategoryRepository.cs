using Modul4HomeWork4.Data.Entities;

namespace Modul4HomeWork4.Repositories.Abstractions
{
    public interface ICategoryRepository
    {
        Task<int> AddCategoryAsync(string name);
        Task<CategoryEntity?> GetCategoryAsync(int id);
        Task UpdateCategoryAsync(int id, string name);
        Task DeleteCategoryAsync(int id);
    }
}
