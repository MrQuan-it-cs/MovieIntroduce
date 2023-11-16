using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieIntroduce.Models;
using MovieIntroduce.Services;

namespace MovieIntroduce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly CinemaServices _services;
        public CinemaController(CinemaServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<List<Cinemas>> Get([FromQuery] int page = 1, int limit = 5)
        {
            return await _services.Get(page, limit);
        }
        [HttpGet("search")]
        public async Task<List<Cinemas>> GetByName([FromQuery] string nameSearch ="", int page = 1, int limit = 5)
        {
            return await _services.GetByName(nameSearch, page, limit);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cinemas cinemas)
        {
            await _services.CreateCinema(cinemas);
            return CreatedAtAction(nameof(Get), new {id =  cinemas.Id}, cinemas);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _services.DeleteCinema(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Cinemas cinemas)
        {
            await _services.UpdateCinema(id, cinemas);
            return NoContent();
        }
    }
}
