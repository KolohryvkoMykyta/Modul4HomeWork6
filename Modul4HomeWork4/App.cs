using Modul4HomeWork4.Models;
using Modul4HomeWork4.Services.Abstractions;

namespace Modul4HomeWork4
{
    public class App
    {
        private readonly ICategoryService _categoryService;
        private readonly IBreedService _breedService;
        private readonly ILocationService _locationService;
        private readonly IPetService _petService;

        public App(
            ICategoryService categoryService, 
            IBreedService breedService, 
            ILocationService locationService, 
            IPetService petService)
        {
            _categoryService = categoryService;
            _breedService = breedService;
            _locationService = locationService;
            _petService = petService;
        }
        public async Task StartAsync()
        {
            var categoryid = await _categoryService.AddCategoryAsync("Category");

            var breedId = await _breedService.AddBreedAsync("Breed", categoryid);

            var locationId = await _locationService.AddLocationAsync("Location");
           
            var petId = await _petService.AddPetAsync("Pet", 3f, categoryid, breedId, locationId, "no", "no");

            var pet = await _petService.GetPetAsync(petId);

            await _petService.UpdatePetAsync(petId, "Update", 3, categoryid, breedId, locationId, "no", "no");

            await _petService.DeletePetAsync(petId);

            

            await _breedService.DeleteBreedAsync(breedId);

            await _categoryService.DeleteCategoryAsync(categoryid);

            await _locationService.DeleteLocationAsync(locationId);

            await Console.Out.WriteLineAsync("Win!!!");

        }
    }
}
