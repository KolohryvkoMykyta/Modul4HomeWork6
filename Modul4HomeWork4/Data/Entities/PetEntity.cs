namespace Modul4HomeWork4.Data.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Category_Id { get; set; }
        public int Breed_Id { get; set; }
        public float Age { get; set; }
        public int Location_Id { get; set; }
        public string? Image_url { get; set; }
        public string? Description { get; set; }
        public CategoryEntity Category { get; set; }
        public BreedEntity Breed { get; set; }
        public LocationEntity Location { get; set; }


    }
}
