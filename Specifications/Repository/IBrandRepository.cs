using DalLibrary.DTO;
using DalLibrary.Models;
using SpecificationsAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationsAPI.Repository
{
    public interface IBrandRepository
    {
        Task<bool> CreateBrand(BrandDTO BrandDTO);
        Task<bool> UpdateBrand(BrandDTO BrandDTO);
        Task<bool> DeleteBrand(string id);
        Task<Brand> GetById(string id);
        Task<IEnumerable<BrandResponse>> GetAllAsync();
        Task<IQueryable<Model>> getAllModels(string id);
        //toDo
        //Task<bool> CreateBrandModel(ModelDTO BrandDTO);
        //Task<bool> UpdateBrandModel(ModelDTO BrandDTO);
        //Task<bool> DeleteBrandModel(int id);
        //Task<Brand> GetByIdModel(int id);
        //Task<IQueryable<Brand>> GetAllModel();

    }
}
