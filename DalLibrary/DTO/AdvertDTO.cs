using DalLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DalLibrary.DTO
{
    public class AdvertDTO
    {
        public string advert_id { get; set; }
        public CountryDTO countryDTO { get; set; }
        public BodyStyleDTO bodyStyleDTO { get; set; }
        public string user_id { get; set; }
        public List<FeatureDTO> features { get; set; }

        public String title { get; set; }
        public String description { get; set; }
        public DateTime createdAt { get; set; }

        public int km { get; set; }
        public int year { get; set; }
        public bool registered { get; set; }
        public bool serviceDocs { get; set; }
        public String vin { get; set; }
        public int horsePower { get; set; }
        public int engineCap { get; set; }
        public int price { get; set; }

        public GearboxType gearboxType { get; set; }
        public Drivetrain drivetrain { get; set; }
        public Fuel fuel { get; set; }
        public List<String> pictures { get; set; }
    }
}
