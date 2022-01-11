using AutoMapper;
using DalLibrary.DTO;
using DalLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationsAPI.Repository
{
    public class CountryRepository : ICountryRepository
    {
        public AutoMarketContext DbContext { get; }
        public IMapper _mapper;
        public CountryRepository(AutoMarketContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            _mapper = mapper;
        }
        public Task<bool> CreateCountry(CountryDTO CountryDTO)
        {
            var rand = new Random();
            CountryDTO.id = rand.Next().ToString();
            if (DbContext.Countries.Add(_mapper.Map<Country>(CountryDTO)) != null)
            {
                DbContext.SaveChanges();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteCountry(string id)
        {
            try
            {
                var adverts = DbContext.Countries.Where(a => id == a.Id).FirstOrDefault();
                DbContext.Remove(adverts);
                DbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                return Task.FromResult(true);
            }
        }

        public async Task<IQueryable<Country>> GetAllAsync()
        {
            return await Task.FromResult(DbContext.Countries.AsQueryable());
        }

        public async Task<Country> GetById(string id)
        {
            return await Task.FromResult(DbContext.Countries.Where(a => a.Id == id).FirstOrDefault());
        }

        public Task<bool> UpdateCountry(CountryDTO CountryDTO)
        {
            var value = DbContext.Countries.Where(c => c.Id == CountryDTO.id).FirstOrDefault();
            if (value != null)
            {
                value.Name = CountryDTO.Name;
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
