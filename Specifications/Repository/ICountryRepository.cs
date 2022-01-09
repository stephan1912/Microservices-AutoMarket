using DalLibrary.DTO;
using DalLibrary.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationsAPI.Repository
{
    public interface ICountryRepository
    {
        Task<bool> CreateCountry(CountryDTO CountryDTO);
        Task<bool> UpdateCountry(CountryDTO CountryDTO);
        Task<bool> DeleteCountry(string id);
        Task<Country> GetById(string id);
        Task<IQueryable<Country>> GetAllAsync();
    }
}
