using CineflixApi.Domain.Interfaces.IService;
using CineflixApi.Shared.Dto.Create;
using CineflixApi.Shared.Dto.Read;
using CineflixApi.Shared.Dto.Update;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Manager")]
        public IActionResult AddGenre(CreateGenreDto GenreDto)
        {
            _service.AddGenre(GenreDto);
            return Ok();
        }

        [HttpGet("ordered")]
        [Authorize(Roles = "Manager")]
        public List<ReadGenreDto> ReturnGenresByAlphabeticalOrder()
        {
            return _service.GetGenresByAlphabeticalOrder();
        }

        [HttpGet("all")]
        [Authorize(Roles = "Manager")]
        public List<ReadGenreDto> ReturnAllGenres()
        {
            return _service.GetAllGenres();
        }

        [HttpGet("id")]
        [Authorize(Roles = "Manager")]
        public ReadGenreDto ReturnGenreById(int id)
        {
            return _service.GetGenreById(id);
        }

        [HttpDelete]
        [Authorize(Roles = "Manager")]
        public IActionResult RemoveGenre(int id)
        {
            _service.DeleteGenre(id);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Manager")]
        public IActionResult UpdateGenreDto(int id, UpdateGenreDto genreDto)
        {
            _service.UpdateGenre(id, genreDto);
            return Ok();
        }
    }
}
