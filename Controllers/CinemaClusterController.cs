using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieIntroduce.Models;
using MovieIntroduce.Services;

namespace MovieIntroduce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaClusterController : ControllerBase
    {
        private readonly CinemaClusterServices _services;
        public CinemaClusterController(CinemaClusterServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<List<CinemaClusters>> Get([FromQuery] int page = 1, int limit = 5)
        {
            return await _services.Get(page, limit);
        }
        [HttpGet("get")]
        public async Task<CinemaClusters> GetById([FromQuery] string id)
        {
            var model = await _services.GetById(id);
            return model;
        }
        [HttpGet("search")]
        public async Task<List<CinemaClusters>> GetByName([FromQuery] string nameSearch = "", int page = 1, int limit = 5)
        {
            return await _services.GetByName(nameSearch, page, limit);
        }
    }
}
