using AutoMapper;
using DalLibrary.DTO;
using DalLibrary.Models;
using System.Linq;

namespace AdvertAPI.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<BodyStyle, BodyStyleDTO>();
            CreateMap<BodyStyleDTO, BodyStyle>();
            CreateMap<Brand, BrandDTO>().ForMember(a => a.id, b => b.MapFrom(src => src.Id));
            CreateMap<BrandDTO, Brand>().ForMember(a => a.Id, b => b.MapFrom(src=>src.id));
            CreateMap<Model, ModelDTO>().ForMember(a => a.id, b => b.MapFrom(src => src.Id));
            CreateMap<ModelDTO, Model>().ForMember(a => a.Id, b => b.MapFrom(src => src.id));
            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();
            CreateMap<Feature, FeatureDTO>();
            CreateMap<FeatureDTO, Feature>();
        }
    }
}
