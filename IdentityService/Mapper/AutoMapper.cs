using AutoMapper;
using DalLibrary.DTO;
using DalLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
