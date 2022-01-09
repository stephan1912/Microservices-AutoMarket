using DalLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpecificationsAPI.Repository;
using System.Threading.Tasks;

namespace SpecificationsAPI.Controllers
{
    [Route("model")]
    [ApiController]
    public class ModelController : Controller
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
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await ModelRepository.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteModel(int id)
        {
            if (ModelRepository.DeleteModel(id) != null)
            {
                return Ok();
            }
            else { return BadRequest(); }
        }
        [HttpPost]
        public async Task<IActionResult> CreateModel(ModelDTO ModelDTO)
        {
            return Ok(await ModelRepository.CreateModel(ModelDTO));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateModel(ModelDTO ModelDTO)
        {
            return Ok(await ModelRepository.UpdateModel(ModelDTO));
        }
    }
}
