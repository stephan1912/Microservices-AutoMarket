using DalLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertAPI.Models
{
    public class AdvertFilter
    {
        public string brand { get; set; }
        public string model { get; set; }
        public string bs { get; set; }
        public GearboxType gearbox { get; set; }
        public int yearMin { get; set; }
        public int yearMax { get; set; }
        public int horsePowerMin { get; set; }
        public int horsePowerMax { get; set; }
        public int kmMin { get; set; }
        public int kmMax { get; set; }
        public int priceMin { get; set; }
        public int priceMax { get; set; }
    }
}
