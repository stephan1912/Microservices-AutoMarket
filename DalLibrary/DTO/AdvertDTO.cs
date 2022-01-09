using DalLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DalLibrary.DTO
{
    public class AdvertDTO
    {
        public string advert_id;
        public CountryDTO countryDTO;
        public BodyStyleDTO bodyStyleDTO;
        public string user_id;
        public List<FeatureDTO> features;

        public String title;
        public String description;
        public DateTime createdAt;

        public int km;
        public int year;
        public bool registered;
        public bool serviceDocs;
        public String vin;
        public int horsePower;
        public int engineCap;
        public int price;

        public GearboxType gearboxType;
        public Drivetrain drivetrain;
        public Fuel fuel;
        public List<String> pictures;
    }
}
