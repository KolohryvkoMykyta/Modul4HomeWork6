using Modul4HomeWork4.Models;

namespace Modul4HomeWork4.Services.Abstractions
{
    public interface IBreedService
    {
        Task<int> AddBreedAsync(string name, int categoryId);
        Task<Breed?> GetBreedAsync(int id);
        Task UpdateBreedAsync(int id, string name, int categoryId);
        Task DeleteBreedAsync(int id);
    }
}
