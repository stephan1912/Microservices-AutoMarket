using DalLibrary.DTO;
using DalLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationsAPI.Repository
{
    public interface IBodyStyleRepository
    {
        Task<bool> CreateBodyStyle(BodyStyleDTO bodyStyleDTO);
        Task<bool> UpdateBodyStyle(BodyStyleDTO bodyStyleDTO);
        Task<bool> DeleteBodyStyle(string id);
        Task<BodyStyle> GetById(string id);
        Task<IQueryable<BodyStyle>> GetAllAsync();
    }
}
