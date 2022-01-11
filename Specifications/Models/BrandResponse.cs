using DalLibrary.DTO;
using DalLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationsAPI.Models
{
    public class BrandResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public List<ModelDTO> models { get; set; }
    }
}
