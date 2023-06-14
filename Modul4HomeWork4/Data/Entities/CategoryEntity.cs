namespace Modul4HomeWork4.Data.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string? Category_Name { get; set; }
        public IEnumerable<BreedEntity> Breeds { get; set; }
        public IEnumerable<PetEntity> Pets { get; set; }
    }
}
