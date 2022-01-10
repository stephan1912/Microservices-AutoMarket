using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpecificationsAPI.Repository;
using System.Threading.Tasks;
using DalLibrary.DTO;

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
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await BodyStyleRepository.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBodyStyle(string id)
        {
            if (BodyStyleRepository.DeleteBodyStyle(id) != null)
            {
                return Ok();
            }
            else { return BadRequest(); }
        }
        [HttpPost]
        public async Task<IActionResult> CreateBodyStyle(BodyStyleDTO bodyStyleDTO)
        {
            return Ok(await BodyStyleRepository.CreateBodyStyle(bodyStyleDTO));
        }

        [HttpPut]
        public async Task<IActionResult>UpdateBodyStyle(BodyStyleDTO bodyStyleDTO)
        {
            return Ok(await BodyStyleRepository.UpdateBodyStyle(bodyStyleDTO));
        }

    }
}
