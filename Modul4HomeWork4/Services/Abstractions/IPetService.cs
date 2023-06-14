using Modul4HomeWork4.Models;

namespace Modul4HomeWork4.Services.Abstractions
{
    public interface IPetService
    {
        Task<int> AddPetAsync(
            string name,
            float age,
            int categoryId,
            int breedId,
            int locationId,
            string imageUrl,
            string description);
        Task<Pet?> GetPetAsync(int id);
        Task UpdatePetAsync(
            int id,
            string name,
            float age,
            int categoryId,
            int breedId,
            int locationId,
            string imageUrl,
            string description);
        Task DeletePetAsync(int id);
    }
}
