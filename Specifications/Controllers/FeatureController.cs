using DalLibrary.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpecificationsAPI.Repository;
using System.Threading.Tasks;

namespace SpecificationsAPI.Controllers
{
    [Route("api/v1/feature")]
    [ApiController]
    public class FeatureController : ControllerBase
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
        [Authorize(Roles = "ADMIN,USER")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await FeatureRepository.GetById(id));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult DeleteFeature(string id)
        {
            if (FeatureRepository.DeleteFeature(id) != null)
            {
                return Ok();
            }
            else { return BadRequest(); }
        }
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CreateFeature(FeatureDTO FeatureDTO)
        {
            return Ok(await FeatureRepository.CreateFeature(FeatureDTO));
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateFeature(FeatureDTO FeatureDTO)
        {
            return Ok(await FeatureRepository.UpdateFeature(FeatureDTO));
        }
    }
}
