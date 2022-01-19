using CineflixApi.Domain.Interfaces.IService;
using CineflixApi.Domain.Models;
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
    public class MovieController : ControllerBase
    {
        public IMovieService _service;
        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddMovie(CreateMovieDto movieDto)
        {
            _service.AddMovie(movieDto);
            return Ok();
        }

        [HttpGet("ordered")]
        public List<ReadMovieDto> ReturntMoviesByAlphabeticalOrder()
        {
            return _service.GetMoviesByAlphabeticalOrder();
        }
        
        [HttpGet("all")]
        public List<ReadMovieDto> ReturnAllMovies()
        {
            return _service.GetMovies();
        }

        [HttpGet("id")]
        public ReadMovieDto ReturnMovieById(int id)
        {
            return _service.GetMovieById(id);
        }

        [HttpDelete]
        public IActionResult RemoveMovie(int id)
        {
            _service.DeleteMovie(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMovie(int id, UpdateMovieDto updateMovieDto)
        {
            _service.UpdateMovie(id, updateMovieDto);
            return Ok();
        }
    }
}
