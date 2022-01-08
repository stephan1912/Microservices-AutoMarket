using System.Collections.Generic;

namespace DalLibrary.Entities
{
    public class BodyStyle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Advert> Adverts { get; set; }
    }
}