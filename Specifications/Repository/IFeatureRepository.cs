using DalLibrary.DTO;
using DalLibrary.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationsAPI.Repository
{
    public interface IFeatureRepository
    {
        Task<bool> CreateFeature(FeatureDTO FeatureDTO);
        Task<bool> UpdateFeature(FeatureDTO FeatureDTO);
        Task<bool> DeleteFeature(string id);
        Task<Feature> GetById(string id);
        Task<IQueryable<Feature>> GetAllAsync();
    }
}
