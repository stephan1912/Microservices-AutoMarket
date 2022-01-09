using DalLibrary.DTO;
using DalLibrary.Models;
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
        Task<IQueryable<Brand>> GetAllAsync();
        //toDo
        //Task<bool> CreateBrandModel(ModelDTO BrandDTO);
        //Task<bool> UpdateBrandModel(ModelDTO BrandDTO);
        //Task<bool> DeleteBrandModel(int id);
        //Task<Brand> GetByIdModel(int id);
        //Task<IQueryable<Brand>> GetAllModel();

    }
}
