using System;
using System.Collections.Generic;
using System.Text;

namespace DalLibrary.DTO
{
    public class ModelResponse
    {

        public string id { get; set; }
        public string name { get; set; }
        public string generation { get; set; }
        public int launchYear { get; set; }
        public int finalYear { get; set; }
        public BrandDTO brand { get; set; }
        public string brandName { get; set; }
    }
}
