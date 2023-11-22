using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieIntroduce.Models;
using MovieIntroduce.Services;

namespace MovieIntroduce.Controllers
{
    [Route("cinema_cluster")]
    [ApiController]
    public class CinemaClusterController : ControllerBase
    {
        private readonly CinemaClusterServices _services;
        public CinemaClusterController(CinemaClusterServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IEnumerable<CinemaClusters>> Get()
        {
            return await _services.Get();
        }
        [HttpGet("{id}")]
        public async Task<IEnumerable<CinemaClusters>> GetById(string id)
        {
            return await _services.GetById(id);
        }
        [HttpGet("search")]
        public async Task<List<CinemaClusters>> GetByName([FromQuery] string nameSearch = "", int page = 1, int limit = 5)
        {
            return await _services.GetByName(nameSearch, page, limit);
        }
    }
}
