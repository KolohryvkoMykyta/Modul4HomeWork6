using Modul4HomeWork4.Models;

namespace Modul4HomeWork4.Services.Abstractions
{
    public interface ILocationService
    {
        Task<int> AddLocationAsync(string name);
        Task<Location?> GetLocationAsync(int id);
        Task UpdateLocationAsync(int id, string name);
        Task DeleteLocationAsync(int id);
    }
}
