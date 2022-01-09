using AutoMapper;
using DalLibrary.DTO;
using DalLibrary.Models;
using System;
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
            if (DbContext.Brands.Add(_mapper.Map<Brand>(BrandDTO)) != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteBrand(int id)
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

        public async Task<IQueryable<Brand>> GetAllAsync()
        {
            return await Task.FromResult(DbContext.Brands.AsQueryable());
        }

        public async Task<Brand> GetById(int id)
        {
            return await Task.FromResult(DbContext.Brands.Where(a => a.Id == id).FirstOrDefault());
        }

        public Task<bool> UpdateBrand(BrandDTO BrandDTO)
        {
            var value = DbContext.Brands.Where(c => c.Id == BrandDTO.brand_id).FirstOrDefault();
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

        //public async Task<IQueryable<Model>> GetAllModel(int id)
        //{

        //    return await Task.FromResult(DbContext.Model.);
        //}
    }
}
