﻿using DalLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpecificationsAPI.Repository;
using System.Threading.Tasks;

namespace SpecificationsAPI.Controllers
{
    [Route("feature")]
    [ApiController]
    public class FeatureController : Controller
    {
        private readonly ILogger<FeatureController> _logger;

        public IFeatureRepository FeatureRepository { get; }

        public FeatureController(ILogger<FeatureController> logger, IFeatureRepository featureRepository)
        {
            _logger = logger;
            FeatureRepository = featureRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await FeatureRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await FeatureRepository.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            if (FeatureRepository.DeleteFeature(id) != null)
            {
                return Ok();
            }
            else { return BadRequest(); }
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(FeatureDTO FeatureDTO)
        {
            return Ok(await FeatureRepository.CreateFeature(FeatureDTO));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(FeatureDTO FeatureDTO)
        {
            return Ok(await FeatureRepository.UpdateFeature(FeatureDTO));
        }
    }
}