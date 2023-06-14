using Modul4HomeWork4.Data.Entities;

namespace Modul4HomeWork4.Repositories.Abstractions
{
    public interface IPetRepository
    {
        Task<int> AddPetAsync(
            string name,
            float age,
            int categoryId,
            int breedId,
            int locationId,
            string imageUrl,
            string description);
        Task<PetEntity?> GetPetAsync(int id);
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
        Task<IReadOnlyList<SpecialEntity>> SpecialRequestAsync();
    }
}
