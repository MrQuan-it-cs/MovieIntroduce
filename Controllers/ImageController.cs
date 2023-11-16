using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieIntroduce.Models;
using MovieIntroduce.Services;

namespace MovieIntroduce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImageServices _services;
        public ImageController(ImageServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<List<Images>> Get([FromQuery] int page = 1, int limit = 5)
        {
            return await _services.Get(page, limit);
        }
    }
}
