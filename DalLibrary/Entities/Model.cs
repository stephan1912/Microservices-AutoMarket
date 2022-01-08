namespace DalLibrary.Entities
{
    public class Model
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Generation { get; set; }
        public int LaunchYear { get; set; }
        public int FinalYear { get; set; }
        public Brand Brand { get; set; }
    }
}