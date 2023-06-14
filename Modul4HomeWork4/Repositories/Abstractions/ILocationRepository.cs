using Modul4HomeWork4.Data.Entities;

namespace Modul4HomeWork4.Repositories.Abstractions
{
    public interface ILocationRepository
    {
        Task<int> AddLocationAsync(string name);
        Task<LocationEntity?> GetLocationAsync(int id);
        Task UpdateLocationAsync(int id, string name);
        Task DeleteLocationAsync(int id);
    }
}
