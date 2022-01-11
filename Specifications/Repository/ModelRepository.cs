using AutoMapper;
using DalLibrary.DTO;
using DalLibrary.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationsAPI.Repository
{
    public class ModelRepository :IModelRepository
    {
        public AutoMarketContext DbContext { get; }
        public IMapper _mapper;
        public ModelRepository(AutoMarketContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            _mapper = mapper;
        }

        public Task<bool> CreateModel(Model model)
        {
            var rand = new Random();
            model.Id = rand.Next().ToString();
            if (DbContext.Models.Add(model) != null)
            {
                DbContext.SaveChanges();   
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> UpdateModel(Model model)
        {
            var value = DbContext.Models.Where(c => c.Id == model.Id).FirstOrDefault();
            if (value != null)
            {
                value.Name = model.Name;
                value.Generation = model.Generation;
                value.FinalYear = model.FinalYear;
                value.LaunchYear = model.LaunchYear;
                DbContext.SaveChanges();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(true);
            }
        }

        public Task<bool> DeleteModel(string id)
        {
            try
            {
                var adverts = DbContext.Models.Where(a => id == a.Id).FirstOrDefault();
                DbContext.Remove(adverts);
                DbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                return Task.FromResult(true);
            }
        }

        public async Task<Model> GetById(string id)
        {
            return await Task.FromResult(DbContext.Models.Where(a => a.Id == id).FirstOrDefault());
        }

        public async Task<IQueryable<Model>> GetAllAsync()
        {
            return await Task.FromResult(DbContext.Models.AsQueryable());
        }
    }
}
