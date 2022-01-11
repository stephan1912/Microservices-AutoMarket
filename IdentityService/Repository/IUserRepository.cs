using DalLibrary.DTO;
using DalLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.Repository
{
    public interface IUserRepository
    {
        Task<User> UpdateUser(UserDTO BrandDTO);
        Task<User> GetById(string id);
    }
}
