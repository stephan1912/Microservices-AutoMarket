namespace DalLibrary.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Advert Advert { get; set; }
    }
}