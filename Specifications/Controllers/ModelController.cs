using DalLibrary.DTO;
using DalLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpecificationsAPI.Repository;
using System.Threading.Tasks;

namespace SpecificationsAPI.Controllers
{
    [Route("api/v1/model")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly ILogger<ModelController> _logger;

        public IModelRepository ModelRepository { get; }

        public ModelController(ILogger<ModelController> logger, IModelRepository modelRepository)
        {
            _logger = logger;
            ModelRepository = modelRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await ModelRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN,USER")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await ModelRepository.GetById(id));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult DeleteModel(string id)
        {
            if (ModelRepository.DeleteModel(id) != null)
            {
                return Ok();
            }
            else { return BadRequest(); }
        }
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CreateModel(Model model)
        {
            return Ok(await ModelRepository.CreateModel(model));
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateModel(Model model)
        {
            return Ok(await ModelRepository.UpdateModel(model));
        }
    }
}
