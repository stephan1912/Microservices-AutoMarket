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
        Task<bool> DeleteBodyStyle(int id);
        Task<BodyStyle> GetById(int id);
        Task<IQueryable<BodyStyle>> GetAllAsync();
    }
}
