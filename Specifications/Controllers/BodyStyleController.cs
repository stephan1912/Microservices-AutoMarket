using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpecificationsAPI.Repository;
using System.Threading.Tasks;
using DalLibrary.DTO;
using Microsoft.AspNetCore.Authorization;

namespace SpecificationsAPI.Controllers
{
    [Route("api/v1/bodyStyle")]
    [ApiController]
    public class BodyStyleController : ControllerBase
    {
        private readonly ILogger<BodyStyleController> _logger;

        public IBodyStyleRepository BodyStyleRepository { get; }

        public BodyStyleController(ILogger<BodyStyleController> logger, IBodyStyleRepository bodyStyleRepository)
        {
            _logger = logger;
            BodyStyleRepository = bodyStyleRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await BodyStyleRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN,USER")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await BodyStyleRepository.GetById(id));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult DeleteBodyStyle(string id)
        {
            if (BodyStyleRepository.DeleteBodyStyle(id) != null)
            {
                return Ok();
            }
            else { return BadRequest(); }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CreateBodyStyle(BodyStyleDTO bodyStyleDTO)
        {
            return Ok(await BodyStyleRepository.CreateBodyStyle(bodyStyleDTO));
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult>UpdateBodyStyle(BodyStyleDTO bodyStyleDTO)
        {
            return Ok(await BodyStyleRepository.UpdateBodyStyle(bodyStyleDTO));
        }

    }
}
