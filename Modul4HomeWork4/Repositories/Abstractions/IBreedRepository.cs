using Modul4HomeWork4.Data.Entities;

namespace Modul4HomeWork4.Repositories.Abstractions
{
    public interface IBreedRepository
    {
        Task<int> AddBreedAsync(string name, int categoryId);
        Task<BreedEntity?> GetBreedAsync(int id);
        Task UpdateBreedAsync(int id, string name, int categoryId);
        Task DeleteBreedAsync(int id);
    }
}
