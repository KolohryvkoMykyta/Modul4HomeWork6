using Microsoft.Extensions.Logging;
using Modul4HomeWork4.Data;
using Modul4HomeWork4.Models;
using Modul4HomeWork4.Repositories.Abstractions;
using Modul4HomeWork4.Services.Abstractions;

namespace Modul4HomeWork4.Services
{
    public class PetService : BaseDataService<ApplicationDbContext>, IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly ILogger<PetService> _loggerService;

        public PetService(
            IPetRepository petRepository,
            ILogger<PetService> loggerService,
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger)
            : base(dbContextWrapper, logger)
        {
            _petRepository = petRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddPetAsync(
            string name,
            float age,
            int categoryId,
            int breedId,
            int locationId,
            string imageUrl,
            string description)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _petRepository.AddPetAsync(name, age, categoryId, breedId, locationId, imageUrl, description);
                _loggerService.LogInformation($"Created pet id: {result} name {name}");
                return result;
            });
        }
        public async Task<Pet?> GetPetAsync(int id)
        {
            var pet = await _petRepository.GetPetAsync(id);

            if (pet == null) 
            {
                _loggerService.LogInformation($"Could not found Pet id: {id}");
                return null;
            }

            var result = new Pet()
            {
                Id = pet.Id,
                Name = pet.Name,
                Age = pet.Age,
                Location_Id = pet.Location_Id,
                Category_Id = pet.Category_Id,
                Description = pet.Description,
                Image_url = pet.Image_url,
            };

            return result;
        }
        public async Task UpdatePetAsync(
            int id,
            string name,
            float age,
            int categoryId,
            int breedId,
            int locationId,
            string imageUrl,
            string description)
        {
            await ExecuteSafeAsync(async () =>
            {
                await _petRepository.UpdatePetAsync(id, name, age, categoryId, breedId, locationId, imageUrl, description);
                _loggerService.LogInformation($"Updated pet id: {id} name: {name}");
            });
        }
        public async Task DeletePetAsync(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                await _petRepository.DeletePetAsync(id);
                _loggerService.LogInformation($"Deleted pet id: {id}");
            });
        }

        public async Task<IReadOnlyList<SpecialModel>> SpecialRequestAsync()
        {
            return (await _petRepository.SpecialRequestAsync())
                .Select(item => new SpecialModel()
                {
                    CategoryName = item.CategoryName,
                    CountBreed = item.CountBreed
                }).ToList();
        }
    }
}
