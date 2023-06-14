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
            var categoryDogId = await _categoryService.AddCategoryAsync("Dog");
            var categoryCatId = await _categoryService.AddCategoryAsync("Cat");
            var categoryBirdId = await _categoryService.AddCategoryAsync("Bird");

            var locationIdUkraine = await _locationService.AddLocationAsync("Ukraine");
            var locationIdPoland = await _locationService.AddLocationAsync("Poland");
            
            var breedIdShepherdDog = await _breedService.AddBreedAsync("Shepherd dog", categoryDogId);
            var breedIdPoodle = await _breedService.AddBreedAsync("Poodle", categoryDogId);
            var breedIdBengalCat = await _breedService.AddBreedAsync("Bengal cat", categoryCatId);
            var breedIdBritishСat = await _breedService.AddBreedAsync("British cat", categoryCatId);
            var breedIdParrot = await _breedService.AddBreedAsync("Parrot", categoryBirdId);
            var breedIdPigeon = await _breedService.AddBreedAsync("Pigeon", categoryBirdId);

            var petId1 = await _petService.AddPetAsync("Pet1", 4f, categoryDogId, breedIdPoodle, locationIdPoland, "ImageURL", "Description");
            var petId2 = await _petService.AddPetAsync("Pet2", 10f, categoryDogId, breedIdPoodle, locationIdUkraine, "ImageURL", "Description");
            var petId3 = await _petService.AddPetAsync("Pet3", 4f, categoryCatId, breedIdBritishСat, locationIdUkraine, "ImageURL", "Description");
            var petId4 = await _petService.AddPetAsync("Pet4", 14f, categoryDogId, breedIdShepherdDog, locationIdUkraine, "ImageURL", "Description");
            var petId5 = await _petService.AddPetAsync("Pet5", 8f, categoryBirdId, breedIdParrot, locationIdPoland, "ImageURL", "Description");
            var petId6 = await _petService.AddPetAsync("Pet6", 7f, categoryBirdId, breedIdPigeon, locationIdUkraine, "ImageURL", "Description");
            var petId7 = await _petService.AddPetAsync("Pet7", 10f, categoryCatId, breedIdBengalCat, locationIdPoland, "ImageURL", "Description");


            var result = await _petService.SpecialRequestAsync();

            Console.ReadKey();
        }
    }
}
