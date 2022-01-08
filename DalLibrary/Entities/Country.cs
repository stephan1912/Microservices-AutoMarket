using System.Collections.Generic;

namespace DalLibrary.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Advert> Adverts { get; set; }
    }
}