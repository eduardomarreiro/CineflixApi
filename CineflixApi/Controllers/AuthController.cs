using CineflixApi.Domain.Interfaces.IService;
using CineflixApi.Domain.Models;
using CineflixApi.Services;
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
    public class AuthController : ControllerBase
    {
        public IUserService _service;
        public TokenService _token;

        public AuthController(TokenService token, IUserService service)
        {
            _token = token;
            _service = service;
        }

        [HttpPost]
        [Authorize (Roles = "Manager")]
        public IActionResult AddUser(CreateUserDto userDto)
        {
            _service.AddUser(userDto);
            return Ok();
        }

        [HttpGet("sorted")]
        [Authorize(Roles = "Manager")]
        public List<ReadUserDto> ReturnUsersByAlphabeticalOrder()
        {
            return _service.GetUsersByAlphabeticalOrder();
        }

        [HttpGet("all")]
        [Authorize]
        public List<ReadUserDto> ReturnAllUsers()
        {
            var userList = _service.GetAllUsers();
            if (User.IsInRole("Manager"))
                return userList;
            else
            {
                List<ReadUserDto> userDtosList = new List<ReadUserDto>();
                foreach (var user in userList)
                {
                    user.Password = "Unauthorized";
                    user.Role = "Unauthorized";
                    userDtosList.Add(user);
                }
                return userDtosList;
            }
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

        [HttpPost("Authentication")]
        public string AuthUser(string username, string password)
        {
            return _token.GenerateToken(_service.GetUser(username, password));
        }
    }
}
