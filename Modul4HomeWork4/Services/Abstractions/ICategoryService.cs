using Modul4HomeWork4.Models;

namespace Modul4HomeWork4.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<int> AddCategoryAsync(string name);
        Task<Category?> GetCategoryAsync(int id);
        Task UpdateCategoryAsync(int id, string name);
        Task DeleteCategoryAsync(int id);
    }
}
