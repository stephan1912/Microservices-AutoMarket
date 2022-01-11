using AutoMapper;
using DalLibrary.DTO;
using DalLibrary.Models;
using SpecificationsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationsAPI.Repository
{
    public class BrandRepository: IBrandRepository
    {
        public AutoMarketContext DbContext { get; }
        public IMapper _mapper;
        public BrandRepository(AutoMarketContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            _mapper = mapper;
        }
        public Task<bool> CreateBrand(BrandDTO BrandDTO)
        {
            var rand = new Random();
            BrandDTO.id = rand.Next().ToString();

            if (DbContext.Brands.Add(_mapper.Map<Brand>(BrandDTO)) != null)
            {
                DbContext.SaveChanges(); 
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteBrand(string id)
        {
            try
            {
                var adverts = DbContext.Brands.Where(a => id == a.Id).FirstOrDefault();
                DbContext.Remove(adverts);
                DbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                return Task.FromResult(true);
            }
        }

        public async Task<IEnumerable<BrandResponse>> GetAllAsync()
        {
            var result = DbContext.Brands.Select(b => new BrandResponse
            {
                id = b.Id,
                code = b.Code,
                name = b.Name,
            }).ToList();
            for(int i = 0; i < result.Count; i++)
            {
                result[i].models = (await getAllModels(result[i].id)).Select(m => new ModelDTO
                {
                    finalYear = m.FinalYear,
                    generation = m.Generation,
                    launchYear = m.LaunchYear,
                    id = m.Id,
                    name = m.Name
                }).ToList();
            }
            return await Task.FromResult(result);
        }

        public async Task<Brand> GetById(string id)
        {
            return await Task.FromResult(DbContext.Brands.Where(a => a.Id == id).FirstOrDefault());
        }

        public Task<bool> UpdateBrand(BrandDTO BrandDTO)
        {
            var value = DbContext.Brands.Where(c => c.Id == BrandDTO.id).FirstOrDefault();
            if (value != null)
            {
                value.Code = BrandDTO?.code;
                value.Name = BrandDTO?.name;
                DbContext.SaveChanges();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(true);
            }

        }
        //toDo
        //public Task<bool> CreateBrandModel(ModelDTO BrandDTO)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> UpdateBrandModel(ModelDTO BrandDTO)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> DeleteBrandModel(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Brand> GetByIdModel(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<IQueryable<Model>> getAllModels(string id)
        {
            return await Task.FromResult(DbContext.Models.Where(a=>a.BrandId ==id).AsQueryable());
        }
    }
}
