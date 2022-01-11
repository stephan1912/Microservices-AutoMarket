using DalLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertAPI.Models
{
    public class CreateAdvertRequest
    {
        public string advert_id { get; set; }
        public string contry_id { get; set; }
        public string bodyStyle_id { get; set; }
        public string user_id { get; set; }
        public List<string> features { get; set; }

        public string title { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }

        public int km { get; set; }
        public int year { get; set; }
        public bool registered { get; set; }
        public bool serviceDocs { get; set; }
        public string vin { get; set; }
        public int horsePower { get; set; }
        public int engineCap { get; set; }
        public int price { get; set; }

        public GearboxType gearboxType { get; set; }
        public Drivetrain drivetrain { get; set; }
        public Fuel fuel { get; set; }
        public List<AdvertImage> pictures { get; set; }
    }

    public class AdvertImage
    {
        public string id { get; set; }
        public byte[] imagedata { get; set; }
    }
}
