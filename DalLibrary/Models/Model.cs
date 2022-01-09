using System;
using System.Collections.Generic;



namespace DalLibrary.Models
{
    public partial class Model
    {
        public string Id { get; set; }
        public int FinalYear { get; set; }
        public string Generation { get; set; }
        public int LaunchYear { get; set; }
        public string Name { get; set; }
        public string BrandId { get; set; }
    }
}
