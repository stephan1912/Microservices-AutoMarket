using DalLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertAPI.Models
{
    public class AdvertResponse
    {
        public int totalCount { get; set; }
        public IEnumerable<AdvertDTO> adverts {get;set;}
    }
}
