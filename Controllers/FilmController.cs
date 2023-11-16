using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieIntroduce.Models;
using MovieIntroduce.Services;

namespace MovieIntroduce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly FilmServices _services;
        public FilmController(FilmServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<List<Films>> Get([FromQuery] int page = 1, int limit = 5)
        {
            return await _services.Get(page, limit);
        }
        [HttpGet("search")]
        public async Task<List<Films>> GetByName([FromQuery] string nameSearch = "", int page = 1, int limit = 5)
        {
            return await _services.GetFilmByName(page, limit, nameSearch);
        }
        [HttpGet("getbyid")]
        public async Task<Films> GetById([FromQuery] string id)
        {
            return await _services.GetById(id);
        }
        [HttpGet("getbygenre")]
        public async Task<List<Films>> GetByGenre([FromQuery] string genre = "", int page = 1, int limit = 5)
        {
            return await _services.GetFilmByGenre(page, limit, genre);
        }
        [HttpGet("getnewfilms")]
        public async Task<List<Films>> GetNewFilms([FromQuery] string nameSearch = "", int page = 1, int limit = 5)
        {
            return await _services.GetNewFilms(page, limit, nameSearch);
        }
        [HttpGet("getnotnewfilms")]
        public async Task<List<Films>> GetNotNewFilms([FromQuery] int page = 1, int limit = 5)
        {
            return await _services.GetNotNewFilms(page, limit);
        }
        [HttpGet("gethotfilms")]
        public async Task<List<Films>> GetHotFilms([FromQuery] string nameSearch = "", int page = 1, int limit = 5)
        {
            return await _services.GetHotFilms(page, limit, nameSearch);
        }
        [HttpGet("getnothotfilms")]
        public async Task<List<Films>> GetNotHotFilms([FromQuery] int page = 1, int limit = 5)
        {
            return await _services.GetNotHotFilms(page, limit);
        }
        [HttpGet("getshowingfilms")]
        public async Task<List<Films>> GetInTheatreFilms([FromQuery] string nameSearch = "", int page = 1, int limit = 5)
        {
            return await _services.GetInTheatreFilms(page, limit, nameSearch);
        }
        [HttpGet("getincomingfilms")]
        public async Task<List<Films>> GetIncomingFilms([FromQuery] string nameSearch = "", int page = 1, int limit = 5)
        {
            return await _services.GetIncomingFilms(page, limit, nameSearch);
        }
    }
}
