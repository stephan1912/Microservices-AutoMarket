using AutoMapper;
using DalLibrary.DTO;
using DalLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IQueryable<Advert>> GetAllAsync(string userId)
        {
            return await Task.FromResult(DbContext.Adverts.AsQueryable().Where(a=>a.Id == userId));
        }

        public  async Task<IQueryable<Advert>> GetAllAdverts()
        {
            return await Task.FromResult(DbContext.Adverts.AsQueryable());
        }

        public Task<IQueryable<Advert>> GetAllUserAdvertsAsync(CustomUserDetails userDetails)
        {
            return Task.FromResult(DbContext.Adverts.Where(a => a.Id == userDetails.Id));
        }

        public async Task<Advert> GetByIdAsync(string id)
        {
            return await Task.FromResult(DbContext.Adverts.Where(a => a.Id == id).FirstOrDefault());

        }

        public Task<bool> CreateAdvert(AdvertDTO advert)
        {
            if (DbContext.Adverts.Add(_mapper.Map<Advert>(advert)) != null)
            {
                return Task.FromResult(true);
            }
            else
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
                value.CountryId = advert.countryDTO.country_id;
                value.Km = advert.km;
                value.Price = advert.price;
                value.Registered = advert.registered;
                value.ServiceDocs = advert.serviceDocs;
                value.Year = advert.year;
                value.UserId = advert.user_id;
                value.HorsePower = advert.horsePower;
                value.BodyStyleId = advert.bodyStyleDTO.bs_Id;
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
