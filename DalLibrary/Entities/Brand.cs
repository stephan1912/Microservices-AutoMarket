using System.Collections.Generic;

namespace DalLibrary.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Model> Models { get; set; }
    }
}