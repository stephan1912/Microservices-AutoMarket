using AutoMapper;
using DalLibrary.DTO;
using DalLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationsAPI.Repository
{
    public class BodyStyleRepository : IBodyStyleRepository
    {
        public AutoMarketContext DbContext { get; }
        public IMapper _mapper;
        public BodyStyleRepository(AutoMarketContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            _mapper = mapper;
        }
        Task<bool> IBodyStyleRepository.CreateBodyStyle(BodyStyleDTO bodyStyleDTO)
        {
            var rand = new Random();
            bodyStyleDTO.id = rand.Next().ToString();
            if (DbContext.BodyStyles.Add(_mapper.Map<BodyStyle>(bodyStyleDTO))!=null)
            {
                DbContext.SaveChanges();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        Task<bool> IBodyStyleRepository.DeleteBodyStyle(string id)
        {
            try
            {
                var adverts = DbContext.BodyStyles.Where(a => id == a.Id).FirstOrDefault();
                DbContext.Remove(adverts);
                DbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                return Task.FromResult(true);
            }
        }

        async Task<IQueryable<BodyStyle>> IBodyStyleRepository.GetAllAsync()
        {
            return await Task.FromResult(DbContext.BodyStyles.AsQueryable());
        }

        async Task<BodyStyle> IBodyStyleRepository.GetById(string id)
        {
            return await Task.FromResult(DbContext.BodyStyles.Where(a => a.Id == id).FirstOrDefault());
        }

        Task<bool> IBodyStyleRepository.UpdateBodyStyle(BodyStyleDTO bodyStyleDTO)
        {
            var value = DbContext.BodyStyles.Where(c => c.Id == bodyStyleDTO.id).FirstOrDefault();
            if (value!= null)
            {
                value.Description = bodyStyleDTO?.Description;
                value.Name = bodyStyleDTO?.Name;
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
