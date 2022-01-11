using AdvertAPI.Models;
using AdvertAPI.Repository;
using DalLibrary.DTO;
using DalLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertAPI.Controllers
{
    [Route("api/v1/advert")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly ILogger<AdvertController> _logger;

        public IAdvertRepository AdvertRepository  { get; }

        public AdvertController(ILogger<AdvertController> logger, IAdvertRepository advertRepository)
        {
            _logger = logger;
            AdvertRepository = advertRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAdverts()
        {
            return Ok(await AdvertRepository.GetAllAdverts());
        }

        [HttpGet("/all/{userId}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAll(string userId)
        {
            return Ok(await AdvertRepository.GetAllAsync(userId));
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await AdvertRepository.GetByIdAsync(id));
        }

        [HttpGet("/admin/all")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await AdvertRepository.GetAllAdverts());
        }

        [HttpGet("/all/me")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> GetAllUserAdverts(CustomUserDetails userDetails)
        {
            return Ok(await AdvertRepository.GetAllUserAdvertsAsync(userDetails));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult DeleteAdvert(string id)
        {
            if (AdvertRepository.DeleteAdvertAsync(id)!=null)
            {
                return Ok();
            }
            else { return BadRequest(); }
        }

        [HttpGet("image/{filePath}")]
        public  IActionResult getImage(string filePath)
        {
            try
            {
                var image = System.IO.File.OpenRead("C:\\Users\\Ionut Valentin\\Desktop\\" + filePath);
                return File(image, "image/jpeg");
            }
            catch (FileNotFoundException)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> CreateAdvert(AdvertDTO advert)
        {
            return Ok(await AdvertRepository.CreateAdvert(advert));
        }

        [HttpPut]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> UpdateAdvert(AdvertDTO advert)
        {
            return Ok(await AdvertRepository.UpdateAdvert(advert));
        }
    }
}

