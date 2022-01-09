using AutoMapper;
using DalLibrary.DTO;
using DalLibrary.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationsAPI.Repository
{
    public class FeatureRepository:IFeatureRepository
    {
        public AutoMarketContext DbContext { get; }
        public IMapper _mapper;
        public FeatureRepository(AutoMarketContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            _mapper = mapper;
        }

        public Task<bool> CreateFeature(FeatureDTO FeatureDTO)
        {
            if (DbContext.Features.Add(_mapper.Map<Feature>(FeatureDTO)) != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> UpdateFeature(FeatureDTO FeatureDTO)
        {
            var value = DbContext.Features.Where(c => c.Id == FeatureDTO.fe_Id).FirstOrDefault();
            if (value != null)
            {
                value.Name = FeatureDTO.Name;
                DbContext.SaveChanges();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(true);
            }
        }

        public Task<bool> DeleteFeature(string id)
        {
            try
            {
                var adverts = DbContext.Features.Where(a => id == a.Id).FirstOrDefault();
                DbContext.Remove(adverts);
                DbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                return Task.FromResult(true);
            }
        }

        public async Task<Feature> GetById(string id)
        {
            return await Task.FromResult(DbContext.Features.Where(a => a.Id == id).FirstOrDefault());
        }

        public async Task<IQueryable<Feature>> GetAllAsync()
        {
            return await Task.FromResult(DbContext.Features.AsQueryable());
        }
    }
}
