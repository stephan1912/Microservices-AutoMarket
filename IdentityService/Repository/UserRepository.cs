using AutoMapper;
using DalLibrary.DTO;
using DalLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.Repository
{
    public class UserRepository : IUserRepository
    {
        public AutoMarketContext DbContext { get; }
        public IMapper _mapper;
        public UserRepository(AutoMarketContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<User> GetById(string id)
        {
            return await Task.FromResult(DbContext.Users.Where(a => a.Id == id).FirstOrDefault());
        }

        public Task<User> UpdateUser(UserDTO userDTO)
        {
            var value = DbContext.Users.Where(c => c.Id == userDTO.id).FirstOrDefault();
            if (value != null)
            {
                value.UserName = string.IsNullOrEmpty(userDTO?.username) ? value.UserName : userDTO.username;
                value.FirstName = string.IsNullOrEmpty(userDTO?.firstName) ? value.FirstName : userDTO.firstName;
                value.LastName = string.IsNullOrEmpty(userDTO?.lastName) ? value.LastName : userDTO.lastName;
                value.Email = string.IsNullOrEmpty(userDTO?.email) ? value.Email : userDTO.email;
                value.Birthdate = userDTO.birthdate == null ? value.Birthdate : userDTO.birthdate;
                DbContext.SaveChanges();
                return Task.FromResult(value);
            }
            else
            {
                return Task.FromResult(new User());
            }
        }
    }
}
