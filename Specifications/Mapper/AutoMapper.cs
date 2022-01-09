using AutoMapper;
using DalLibrary.DTO;
using DalLibrary.Models;

namespace AdvertAPI.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<BodyStyle, BodyStyleDTO>();
            CreateMap<Brand, BrandDTO>();
            CreateMap<Model, ModelDTO>();
            CreateMap<Country, CountryDTO>();
            CreateMap<Feature, FeatureDTO>();
        }
    }
}
