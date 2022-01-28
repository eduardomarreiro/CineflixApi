using CineflixApi.Domain.Models;
using CineflixApi.Shared.Dto.Create;
using CineflixApi.Shared.Dto.Read;
using CineflixApi.Shared.Dto.Update;
using System.Collections.Generic;

namespace CineflixApi.Domain.Interfaces.IService
{
    public interface IUserService 
    {
        void AddUser(CreateUserDto userDto);
        List<ReadUserDto> GetAllUsers();
        List<ReadUserDto> GetUsersByAlphabeticalOrder();
        ReadUserDto GetUserById(int id);
        void DeleteUser(int id);
        void UpdateUser(int id, UpdateUserDto userDto);
        User GetUser(string username, string password);
    }
}
