namespace Modul4HomeWork4.Data.Entities
{
    public class LocationEntity
    {
        public int Id { get; set; }
        public string? Location_Name { get; set; }
        public IEnumerable<PetEntity> Pets { get; set; }
    }
}
