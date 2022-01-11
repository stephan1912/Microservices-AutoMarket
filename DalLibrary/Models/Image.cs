using System;
using System.Collections.Generic;



namespace DalLibrary.Models
{
    public partial class Image
    {
        public string Id { get; set; }
        public byte[] ImageData { get; set; }
        public string AdvertId { get; set; }
    }
}
