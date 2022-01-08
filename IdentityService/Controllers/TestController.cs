using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DalLibrary.Models;
using Microsoft.AspNetCore.Mvc;


namespace IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {

        public AutoMarketContext DbContext { get; }
        public TestController(AutoMarketContext dbContext)
        {
            DbContext = dbContext;
        }


        public async Task<IActionResult> TestDB()
        {
            return Ok(DbContext.Adverts.Select(a => a.Title).ToArray());
        }
    }
}
