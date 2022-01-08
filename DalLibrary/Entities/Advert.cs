using System;
using System.Collections.Generic;

namespace DalLibrary.Entities
{
    public class Advert
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Km { get; set; }
        public int Year { get; set; }
        public bool Registered { get; set; }
        public bool ServiceDocs { get; set; }
        public string Vin { get; set; }
        public int HorsePower { get; set; }
        public int Price { get; set; }
        public int EngineCap { get; set; }

        public GearboxType GearboxType { get; set; }
        public Drivetrain Drivetrain { get; set; }
        public Fuel Fuel { get; set; }
        public Model Model { get; set; }
        public Country Country { get; set; }
        public BodyStyle BodyStyle { get; set; }
        public User User { get; set; }
        public List<Image> Images { get; set; }

    }
}
