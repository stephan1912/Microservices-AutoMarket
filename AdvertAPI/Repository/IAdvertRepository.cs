﻿using AdvertAPI.Models;
using DalLibrary.DTO;
using DalLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertAPI.Repository
{
    public interface IAdvertRepository
    {
        Task<bool> DeleteAdvertAsync(string id);
        Task<IQueryable<Advert>> GetAllAdverts();
        Task<Advert> GetByIdAsync(string id);
        Task<IEnumerable<AdvertDTO>> GetAllAsync(string userId);
        Task<bool> CreateAdvert(CreateAdvertRequest advert);
        Task<bool> UpdateAdvert(AdvertDTO advert);
    }
}
