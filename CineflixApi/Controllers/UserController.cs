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
    public class UserController : ControllerBase
    {
        public IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddUser(CreateUserDto userDto)
        {
            _service.AddUser(userDto);
            return Ok();
        }

        [HttpGet("sorted")]
        public List<ReadUserDto> ReturnUsersByAlphabeticalOrder()
        {
            return _service.GetUsersByAlphabeticalOrder();
        }

        [HttpGet("all")]
        public List<ReadUserDto> ReturnAllUsers()
        {
            return _service.GetAllUsers();
        }

        [HttpGet("id")]
        public ReadUserDto ReturnUserById(int id)
        {
            return _service.GetUserById(id);
        }

        [HttpDelete]
        public IActionResult RemoveUser(int id)
        {
            _service.DeleteUser(id);
            return Ok(0);
        }

        [HttpPut]
        public IActionResult UpdateUser(int id, UpdateUserDto userDto)
        {
            _service.UpdateUser(id, userDto);
            return Ok();
        }
    }
}
