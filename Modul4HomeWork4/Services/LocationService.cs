using Microsoft.Extensions.Logging;
using Modul4HomeWork4.Data;
using Modul4HomeWork4.Models;
using Modul4HomeWork4.Repositories.Abstractions;
using Modul4HomeWork4.Services.Abstractions;
using System.Runtime.InteropServices;

namespace Modul4HomeWork4.Services
{
    public class LocationService : BaseDataService<ApplicationDbContext>, ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILogger<LocationService> _loggerService;

        public LocationService(
            ILocationRepository locationRepository,
            ILogger<LocationService> loggerService,
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger)
            : base(dbContextWrapper, logger)
        {
            _locationRepository = locationRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddLocationAsync(string name)
        {
            return await ExecuteSafeAsync(async () =>
                {
                    var result = await _locationRepository.AddLocationAsync(name);
                    _loggerService.LogInformation($"Created location: Id: {result} Name: {name}");
                    return result;
                });
        }

        public async Task<Location?> GetLocationAsync(int id)
        {
            var location = await _locationRepository.GetLocationAsync(id);

            if (location == null) 
            {
                _loggerService.LogInformation($"Location {id} not found");
                return null;
            }

            return new Location()
            {
                Id = location.Id,
                Location_Name = location.Location_Name
            };
        }

        public async Task UpdateLocationAsync(int id, string name)
        {
            await ExecuteSafeAsync(async () =>
            {
                await _locationRepository.UpdateLocationAsync(id, name);
                _loggerService.LogInformation($"Location Id: {id} Name: {name} was updated");
            });
        }

        public async Task DeleteLocationAsync(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                await _locationRepository.DeleteLocationAsync(id);
                _loggerService.LogInformation($"Location Id: {id} was deleted");
            });
        }
    }
}
