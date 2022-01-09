using DalLibrary.DTO;
using DalLibrary.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationsAPI.Repository
{
    public interface IModelRepository
    {
        Task<bool> CreateModel(ModelDTO ModelDTO);
        Task<bool> UpdateModel(ModelDTO ModelDTO);
        Task<bool> DeleteModel(int id);
        Task<Model> GetById(int id);
        Task<IQueryable<Model>> GetAllAsync();
    }
}
