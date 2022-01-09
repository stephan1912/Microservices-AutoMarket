using System;
using System.Collections.Generic;

#nullable disable

namespace DalLibrary.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AdvertId { get; set; }
    }
}
