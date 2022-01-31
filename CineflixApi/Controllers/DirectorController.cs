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
    public class DirectorController : ControllerBase
    {
        public IDirectorService _service;

        public DirectorController(IDirectorService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult AddDirector(CreateDirectorDto directorDto)
        {
            _service.AddDirector(directorDto);
            return Ok();
        }

        [HttpGet("sorted")]
        [Authorize(Roles = "Manager")]
        public List<ReadDirectorDto> ReturnDirectorsByAlphabeticalOrder()
        {
            return _service.GetDirectorByAlphabeticalOrder();      
        }

        [HttpGet("all")]
        [Authorize(Roles = "Manager")]
        public List<ReadDirectorDto> ReturnAllDirectors()
        {
            return _service.GetAllDirectors();
        }

        [HttpGet("id")]
        [Authorize(Roles = "Manager")]
        public ReadDirectorDto ReturnDirectorById(int id)
        {
            return _service.GetDirectorById(id);
        }

        [HttpDelete]
        [Authorize(Roles = "Manager")]
        public IActionResult RemoveDirector(int id)
        {
            _service.DeleteDirector(id);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Manager")]
        public IActionResult UpdateDirector(int id, UpdateDirectorDto updateDirectorDto)
        {
            _service.UpdateDirector(id, updateDirectorDto);
            return Ok();
        }
    }
}
