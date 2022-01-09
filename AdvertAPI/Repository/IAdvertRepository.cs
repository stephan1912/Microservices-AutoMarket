using DalLibrary.DTO;
using DalLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertAPI.Repository
{
    public interface IAdvertRepository
    {
        Task<bool> DeleteAdvertAsync(string id);
        Task<IQueryable<Advert>> GetAllUserAdvertsAsync(CustomUserDetails userDetails);
        Task<IQueryable<Advert>> GetAllAdminAsync();
        Task<Advert> GetByIdAsync(string id);
        Task<IQueryable<Advert>> GetAllAsync(string userId);
        Task<bool> CreateAdvert(AdvertDTO advert);
        Task<bool> UpdateAdvert(AdvertDTO advert);
    }
}
