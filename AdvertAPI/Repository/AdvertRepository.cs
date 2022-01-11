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
                var bs = DbContext.BodyStyles.FirstOrDefault(bs => bs.Id == a.BodyStyleId);
                var country = DbContext.Countries.FirstOrDefault(bs => bs.Id == a.CountryId);
                var fs = DbContext.Features.Where(f => DbContext.AdvertFeatures.
                                    Where(af => af.AdvertId == a.Id).Select(af => af.FeatureId).ToList().
                                    Contains(f.Id)).Select(f => new FeatureDTO
                                    {
                                        id = f.Id,
                                        Name = f.Name
                                    }).ToList();
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
                resp.Add(r);
            }
            return await Task.FromResult(resp);
        }

        public  async Task<IQueryable<Advert>> GetAllAdverts()
        {
            return await Task.FromResult(DbContext.Adverts.AsQueryable());
        }

        public async Task<Advert> GetByIdAsync(string id)
        {
            return await Task.FromResult(DbContext.Adverts.Where(a => a.Id == id).FirstOrDefault());

        }

        public Task<bool> CreateAdvert(CreateAdvertRequest advert)
        {
            try
            {
                var value = new Advert();
                value.Id = Guid.NewGuid().ToString();
                value.Vin = advert.vin;
                value.CountryId = advert.contry_id;
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

        public Task<bool> UpdateAdvert(AdvertDTO advert)
        {
            var value = DbContext.Adverts.Where(c => c.Id == advert.advert_id).FirstOrDefault();
            if (value != null)
            {
                value.Vin = advert.vin;
                value.CountryId = advert.countryDTO.id;
                value.Km = advert.km;
                value.Price = advert.price;
                value.Registered = advert.registered;
                value.ServiceDocs = advert.serviceDocs;
                value.Year = advert.year;
                value.UserId = advert.user_id;
                value.HorsePower = advert.horsePower;
                value.BodyStyleId = advert.bodyStyleDTO.id;
                value.Description = advert.description;
                value.Drivetrain = advert.drivetrain.ToString();
                value.EngineCap = advert.engineCap;
                value.Fuel = advert.fuel.ToString();
                value.GearboxType = advert.gearboxType.ToString();
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
