using AutoMapper;
using DalLibrary.DTO;
using DalLibrary.Models;

namespace AdvertAPI.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Advert, AdvertDTO>();
        }
    }
}
