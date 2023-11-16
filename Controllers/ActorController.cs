using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieIntroduce.Models;
using MovieIntroduce.Services;

namespace MovieIntroduce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly ActorServices _services;
        public ActorController(ActorServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<List<Actors>> Get([FromQuery] int page = 1, int limit = 5)
        {
            return await _services.Get(page, limit);
        }
        [HttpGet("search")]
        public async Task<List<Actors>> GetByName([FromQuery] string nameSearch = "", int page = 1, int limit = 5)
        {
            return await _services.GetByName(nameSearch, page, limit);
        }
    }
}
