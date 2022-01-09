﻿using DalLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpecificationsAPI.Repository;
using System.Threading.Tasks;

namespace SpecificationsAPI.Controllers
{
    [Route("brand")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly ILogger<BrandController> _logger;

        public IBrandRepository BrandRepository { get; }

        public BrandController(ILogger<BrandController> logger, IBrandRepository brandRepository)
        {
            _logger = logger;
            BrandRepository = brandRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await BrandRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await BrandRepository.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBrand(int id)
        {
            if (BrandRepository.DeleteBrand(id) != null)
            {
                return Ok();
            }
            else { return BadRequest(); }
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(BrandDTO BrandDTO)
        {
            return Ok(await BrandRepository.CreateBrand(BrandDTO));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(BrandDTO BrandDTO)
        {
            return Ok(await BrandRepository.UpdateBrand(BrandDTO));
        }
    }
}