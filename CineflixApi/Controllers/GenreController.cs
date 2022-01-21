using CineflixApi.Domain.Interfaces.IService;
using CineflixApi.Shared.Dto.Create;
using CineflixApi.Shared.Dto.Read;
using CineflixApi.Shared.Dto.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CineflixApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        public IGenreService _service;

        public GenreController(IGenreService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddGenre(CreateGenreDto GenreDto)
        {
            _service.AddGenre(GenreDto);
            return Ok();
        }

        [HttpGet("ordered")]
        public List<ReadGenreDto> ReturnGenresByAlphabeticalOrder()
        {
            return _service.GetGenresByAlphabeticalOrder();
        }

        [HttpGet("all")]
        public List<ReadGenreDto> ReturnAllGenres()
        {
            return _service.GetAllGenres();
        }

        [HttpGet("id")]
        public ReadGenreDto ReturnGenreById(int id)
        {
            return _service.GetGenreById(id);
        }

        [HttpDelete]
        public IActionResult RemoveGenre(int id)
        {
            _service.DeleteGenre(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateGenreDto(int id, UpdateGenreDto genreDto)
        {
            _service.UpdateGenre(id, genreDto);
            return Ok();
        }
    }
}
