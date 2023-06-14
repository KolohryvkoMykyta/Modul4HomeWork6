using Microsoft.Extensions.Logging;
using Modul4HomeWork4.Data;
using Modul4HomeWork4.Models;
using Modul4HomeWork4.Repositories.Abstractions;
using Modul4HomeWork4.Services.Abstractions;

namespace Modul4HomeWork4.Services
{
    public class BreedService : BaseDataService<ApplicationDbContext>, IBreedService
    {
        private readonly IBreedRepository _breedRepository;
        private readonly ILogger<BreedService> _loggerService;

        public BreedService(
            IBreedRepository breedRepository,
            ILogger<BreedService> loggerService,
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger)
            : base (dbContextWrapper, logger)
        {
            _breedRepository = breedRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddBreedAsync(string name, int categoryId)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _breedRepository.AddBreedAsync(name, categoryId);
                _loggerService.LogInformation($"Breed Id: {id} Name: {name} was created");
                return id;
            });
        }
        public async Task<Breed?> GetBreedAsync(int id)
        {
            var breed = await _breedRepository.GetBreedAsync(id);
            
            if (breed == null)
            {
                _loggerService.LogInformation($"Could not find breed Id: {id}");
                return null;
            }

            return new Breed()
            {
                Id = breed.Id,
                Breed_Name = breed.Breed_Name,
                Category_Id = breed.Category_Id,
            };
            
        }
        public async Task UpdateBreedAsync(int id, string name, int categoryId)
        {
            await ExecuteSafeAsync(async () =>
            {
                await _breedRepository.UpdateBreedAsync(id, name, categoryId);
                _loggerService.LogInformation($"Updated breed id: {id} name: {name}");
            });
        }
        public async Task DeleteBreedAsync(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                await _breedRepository.DeleteBreedAsync(id);
                _loggerService.LogInformation($"Deleted breed id: {id}");
            });
        }

    }
}
