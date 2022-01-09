﻿using AdvertAPI.Models;
using AdvertAPI.Repository;
using DalLibrary.DTO;
using DalLibrary.Models;
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
    [Route("advert")]
    [ApiController]
    public class AdvertController : Controller
    {
        private readonly ILogger<AdvertController> _logger;

        public IAdvertRepository AdvertRepository  { get; }

        public AdvertController(ILogger<AdvertController> logger, IAdvertRepository advertRepository)
        {
            _logger = logger;
            AdvertRepository = advertRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet("/all/{userId}")]
        public async Task<IActionResult> GetAll(int userId)
        {
            return Ok(await AdvertRepository.GetAllAsync(userId));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await AdvertRepository.GetByIdAsync(id));
        }

        [HttpGet("/admin/all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await AdvertRepository.GetAllAdminAsync());
        }

        [HttpGet("/all/me")]
        public async Task<IActionResult> GetAllUserAdverts(CustomUserDetails userDetails)
        {
            return Ok(await AdvertRepository.GetAllUserAdvertsAsync(userDetails));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdvert(int id)
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
        public async Task<IActionResult> CreateAdvert(AdvertDTO advert)
        {
            return Ok(await AdvertRepository.CreateAdvert(advert));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdvert(AdvertDTO advert)
        {
            return Ok(await AdvertRepository.UpdateAdvert(advert));
        }
    }
}
