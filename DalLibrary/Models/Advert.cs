using System;
using System.Collections.Generic;


namespace DalLibrary.Models
{
    public partial class Advert
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Description { get; set; }
        public string Drivetrain { get; set; }
        public int EngineCap { get; set; }
        public string Fuel { get; set; }
        public string GearboxType { get; set; }
        public int HorsePower { get; set; }
        public int Km { get; set; }
        public int Price { get; set; }
        public bool Registered { get; set; }
        public bool ServiceDocs { get; set; }
        public string Title { get; set; }
        public string Vin { get; set; }
        public int Year { get; set; }
        public int? BodyStyleId { get; set; }
        public int? CountryId { get; set; }
        public int? ModelId { get; set; }
        public int? UserId { get; set; }
    }
}
