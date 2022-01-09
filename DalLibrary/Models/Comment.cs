using System;
using System.Collections.Generic;



namespace DalLibrary.Models
{
    public partial class Comment
    {
        public string Id { get; set; }
        public string Comment1 { get; set; }
        public int? AdvertId { get; set; }
        public int? UserId { get; set; }
    }
}
