namespace Modul4HomeWork4.Data.Entities
{
    public class BreedEntity
    {
        public int Id { get; set; }
        public string? Breed_Name { get; set; }
        public int Category_Id { get; set; }
        public CategoryEntity Category { get; set; }
        public IEnumerable<PetEntity> Pets { get; set; }
    }
}
