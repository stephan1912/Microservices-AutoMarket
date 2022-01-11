using DalLibrary.DTO;
using DalLibrary.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationsAPI.Repository
{
    public interface IModelRepository
    {
        Task<bool> CreateModel(Model ModelDTO);
        Task<bool> UpdateModel(Model ModelDTO);
        Task<bool> DeleteModel(string id);
        Task<Model> GetById(string id);
        Task<IQueryable<Model>> GetAllAsync();
    }
}
