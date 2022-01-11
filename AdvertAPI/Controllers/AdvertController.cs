using AdvertAPI.Models;
using AdvertAPI.Repository;
using DalLibrary.DTO;
using DalLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertAPI.Controllers
{
    [Route("api/v1/advert")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly ILogger<AdvertController> _logger;

        public IAdvertRepository AdvertRepository  { get; }
        public AutoMarketContext AutoMarketContext { get; }

        public AdvertController(ILogger<AdvertController> logger, IAdvertRepository advertRepository, AutoMarketContext autoMarketContext)
        {
            _logger = logger;
            AdvertRepository = advertRepository;
            AutoMarketContext = autoMarketContext;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAdverts([FromQuery] string filter, [FromQuery] int page)
        {
            AdvertFilter advFitler = null;
            if (!string.IsNullOrEmpty(filter)) { 
                advFitler = JsonConvert.DeserializeObject<AdvertFilter>(Encoding.UTF8.GetString(Convert.FromBase64String(filter)));
            }
            return Ok(await AdvertRepository.GetAllAdverts(advFitler, page));
        }

        [HttpGet("all/{userId}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAll(string userId)
        {
            return Ok(await AdvertRepository.GetAllAsync(userId));
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await AdvertRepository.GetByIdAsync(id));
        }

        [HttpGet("admin/all")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await AdvertRepository.GetAllAdverts(null, 0));
        }

        [HttpGet("all/me")]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> GetAllUserAdverts()
        {
            return Ok(await AdvertRepository.GetAllAsync(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult DeleteAdvert(string id)
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
                var img = AutoMarketContext.Images.FirstOrDefault(i => i.Id == filePath);

                Stream fs = new MemoryStream(img.ImageData);

                return File(fs, "image/jpeg");
            }
            catch (FileNotFoundException)
            {
                return BadRequest();
            }
        }
        public class AdvertRequest
        {
            public List<IFormFile> files { get; set; }
            public string JsonObject { get; set; }
        }

        [HttpPost]
        //[Authorize(Roles = "USER")]
        public async Task<IActionResult> CreateAdvert([FromForm] AdvertRequest advertReq)
        {
            try
            {
                var advert = JsonConvert.DeserializeObject<CreateAdvertRequest>(advertReq.JsonObject);
                advert.pictures = new List<AdvertImage>();
                foreach (var file in advertReq.files)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        advert.pictures.Add(new AdvertImage
                        {
                            imagedata = fileBytes
                        });
                    }
                }
                advert.user_id = User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value;
                return Ok(await AdvertRepository.CreateAdvert(advert));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize(Roles = "USER")]
        public async Task<IActionResult> UpdateAdvert([FromBody] CreateAdvertRequest advert)
        {
            advert.user_id = User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value;
            return Ok(await AdvertRepository.UpdateAdvert(advert));
        }
    }
}

