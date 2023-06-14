namespace Modul4HomeWork4.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Category_Id { get; set; }
        public int Breed_Id { get; }
        public float Age { get; set; }
        public int Location_Id { get; set; }
        public string? Image_url { get; set; }
        public string? Description { get; set; }
    }
}
