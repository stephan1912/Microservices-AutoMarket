using AdvertAPI.Models;
using AutoMapper;
using DalLibrary.DTO;
using DalLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertAPI.Repository
{
    public class AdvertRepository : IAdvertRepository
    {
        public AutoMarketContext DbContext { get; }
        IMapper _mapper;
        public AdvertRepository(AutoMarketContext dbContext,IMapper mapper)
        {
            DbContext = dbContext;
            _mapper = mapper;
        }
        public Task<bool> DeleteAdvertAsync(string id)
        {
            try
            {
                var adverts = DbContext.Adverts.Where(a => id == a.Id).FirstOrDefault();
                DbContext.Remove(adverts);
                DbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                return Task.FromResult(false);
            }
            
        }
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        public async Task<IEnumerable<AdvertDTO>> GetAllAsync(string userId)
        {
            var all = DbContext.Adverts.AsQueryable().Where(a => a.UserId == userId).ToList();
            var resp = new List<AdvertDTO>();
            foreach(var a in all)
            {
                resp.Add(convertToDto(a));
            }
            return await Task.FromResult(resp);
        }

        private AdvertDTO convertToDto(Advert a)
        {
            var bs = DbContext.BodyStyles.FirstOrDefault(bs => bs.Id == a.BodyStyleId);
            var country = DbContext.Countries.FirstOrDefault(bs => bs.Id == a.CountryId);
            var fs = DbContext.Features.Where(f => DbContext.AdvertFeatures.
                                Where(af => af.AdvertId == a.Id).Select(af => af.FeatureId).ToList().
                                Contains(f.Id)).Select(f => new FeatureDTO
                                {
                                    id = f.Id,
                                    Name = f.Name
                                }).ToList();
            var model = DbContext.Models.FirstOrDefault(bs => bs.Id == a.ModelId);
            Brand brand = model == null ? null : DbContext.Brands.FirstOrDefault(bs => bs.Id == model.BrandId);
            var r = new AdvertDTO
            {
                advert_id = a.Id,
                bodyStyleDTO = new BodyStyleDTO
                {
                    Description = bs.Description,
                    id = bs.Id,
                    Name = bs.Name
                },
                countryDTO = country == null ? null : new CountryDTO
                {
                    id = country.Id,
                    Name = country.Name
                },
                model = model == null || brand == null ? new ModelResponse() : new ModelResponse
                {
                    brand = new BrandDTO
                    {
                        code = brand.Code,
                        id = brand.Id,
                        name = brand.Name
                    },
                    brandName = brand.Name,
                    finalYear = model.FinalYear,
                    generation = model.Generation,
                    launchYear = model.LaunchYear,
                    id = model.Id,
                    name = model.Name
                },
                model_id = model == null ? null : model.Id,
                description = a.Description,
                drivetrain = ParseEnum<Drivetrain>(a.Drivetrain),
                engineCap = a.EngineCap,
                features = fs,
                fuel = ParseEnum<Fuel>(a.Fuel),
                gearboxType = ParseEnum<GearboxType>(a.GearboxType),
                horsePower = a.HorsePower,
                km = a.Km,
                pictures = DbContext.Images.Where(p => p.AdvertId == a.Id).Select(i => i.Id).ToList(),
                price = a.Price,
                registered = a.Registered,
                serviceDocs = a.ServiceDocs,
                title = a.Title,
                user_id = a.UserId,
                vin = a.Vin,
                year = a.Year
            };
            return r;
        }

        public  async Task<AdvertResponse> GetAllAdverts(AdvertFilter filter, int page)
        {
            var all = DbContext.Adverts.AsQueryable();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.brand) && filter.brand != "-1")
                {
                    var allModels = DbContext.Models.Where(m => m.BrandId == filter.brand).Select(m => m.Id).ToList();
                    all = all.Where(a => allModels.Contains(a.ModelId));
                }
                if (!string.IsNullOrEmpty(filter.model) && filter.model != "-1")
                {
                    all = all.Where(a => a.ModelId == filter.model);
                }
                if (!string.IsNullOrEmpty(filter.bs) && filter.bs != "-1")
                {
                    all = all.Where(a => a.BodyStyleId == filter.bs);
                }
                if (filter.gearbox != GearboxType.EMPTY)
                {
                    all = all.Where(a => ParseEnum<GearboxType>(a.GearboxType) == filter.gearbox);
                }
                if (filter.yearMin != -1)
                {
                    all = all.Where(a => a.Year >= filter.yearMin);
                }
                if (filter.yearMax != -1)
                {
                    all = all.Where(a => a.Year <= filter.yearMax);
                }
                if (filter.horsePowerMin != -1)
                {
                    all = all.Where(a => a.HorsePower >= filter.horsePowerMin);
                }
                if (filter.horsePowerMax != -1)
                {
                    all = all.Where(a => a.HorsePower <= filter.horsePowerMax);
                }
                if (filter.kmMin != -1)
                {
                    all = all.Where(a => a.Km >= filter.kmMin);
                }
                if (filter.kmMax != -1)
                {
                    all = all.Where(a => a.Km <= filter.kmMax);
                }
                if (filter.priceMin != -1)
                {
                    all = all.Where(a => a.Price >= filter.priceMin);
                }
                if (filter.priceMax != -1)
                {
                    all = all.Where(a => a.Price <= filter.priceMax);
                }
            }
            int totalCount = all.Count();
            if(page > 0)
            {
                all = all.Skip(1 * (page - 1)).Take(1);
            }
            return await Task.FromResult(new AdvertResponse
            {
                totalCount = totalCount,
                adverts = all.ToList().Select(a => convertToDto(a))
            });
        }

        public async Task<AdvertDTO> GetByIdAsync(string id)
        {
            return await Task.FromResult(convertToDto(DbContext.Adverts.Where(a => a.Id == id).FirstOrDefault()));

        }

        public Task<bool> CreateAdvert(CreateAdvertRequest advert)
        {
            try
            {
                var value = new Advert();
                value.Id = Guid.NewGuid().ToString();
                value.Vin = advert.vin;
                value.CountryId = advert.country_id;
                value.Km = advert.km;
                value.Price = advert.price;
                value.Registered = advert.registered;
                value.ServiceDocs = advert.serviceDocs;
                value.Year = advert.year;
                value.UserId = advert.user_id;
                value.HorsePower = advert.horsePower;
                value.BodyStyleId = advert.bodyStyle_id;
                value.Description = advert.description;
                value.Title = advert.title;
                value.Drivetrain = advert.drivetrain.ToString();
                value.EngineCap = advert.engineCap;
                value.Fuel = advert.fuel.ToString();
                value.GearboxType = advert.gearboxType.ToString();
                value.ModelId = advert.model_id;
                DbContext.Adverts.Add(value);

                foreach (var f in advert.features)
                {
                    var feature = new AdvertFeature()
                    {
                        AdvertId = value.Id,
                        FeatureId = f
                    };
                    DbContext.AdvertFeatures.Add(feature);
                }
                foreach (var p in advert.pictures)
                {
                    var img = new Image()
                    {
                        Id = Guid.NewGuid().ToString(),
                        AdvertId = value.Id,
                        ImageData = p.imagedata
                    };
                    DbContext.Images.Add(img);
                }

                DbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {

                return Task.FromResult(false);
            }
        }

        public Task<bool> UpdateAdvert(CreateAdvertRequest advert)
        {
            var value = DbContext.Adverts.Where(c => c.Id == advert.advert_id).FirstOrDefault();
            if (value != null)
            {
                value.Vin = advert.vin;
                value.CountryId = string.IsNullOrEmpty(advert.country_id) ? value.CountryId : advert.country_id;
                value.Km = advert.km;
                value.Price = advert.price;
                value.Registered = advert.registered;
                value.ServiceDocs = advert.serviceDocs;
                value.Year = advert.year;
                value.UserId = advert.user_id;
                value.HorsePower = advert.horsePower;
                value.BodyStyleId = string.IsNullOrEmpty(advert.bodyStyle_id) ? value.BodyStyleId : advert.bodyStyle_id;
                value.Description = advert.description;
                value.Drivetrain = advert.drivetrain.ToString();
                value.EngineCap = advert.engineCap;
                value.Fuel = advert.fuel.ToString();
                value.GearboxType = advert.gearboxType.ToString();
                value.ModelId = string.IsNullOrEmpty(advert.model_id) ? value.ModelId : advert.model_id;
                if(advert.features != null && advert.features.Count > 0)
                {
                    var features = DbContext.AdvertFeatures.Where(a => a.AdvertId == value.Id).ToList();
                    DbContext.AdvertFeatures.RemoveRange(features);
                    foreach(var f in advert.features)
                    {
                        DbContext.AdvertFeatures.Add(new AdvertFeature()
                        {
                            AdvertId = value.Id,
                            FeatureId = f
                        });
                    }
                }
                DbContext.SaveChanges();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(true);
            }
        }


    }
}
