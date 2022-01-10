using DalLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpecificationsAPI.Repository;
using System.Threading.Tasks;

namespace SpecificationsAPI.Controllers
{
    [Route("api/v1/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;

        public ICountryRepository CountryRepository { get; }

        public CountryController(ILogger<CountryController> logger, ICountryRepository countryRepository)
        {
            _logger = logger;
            CountryRepository = countryRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await CountryRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await CountryRepository.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(string id)
        {
            if (CountryRepository.DeleteCountry(id) != null)
            {
                return Ok();
            }
            else { return BadRequest(); }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCountry(CountryDTO CountryDTO)
        {
            return Ok(await CountryRepository.CreateCountry(CountryDTO));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountry(CountryDTO CountryDTO)
        {
            return Ok(await CountryRepository.UpdateCountry(CountryDTO));
        }
    }
}
