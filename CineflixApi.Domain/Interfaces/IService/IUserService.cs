using CineflixApi.Shared.Dto.Create;
using CineflixApi.Shared.Dto.Read;
using CineflixApi.Shared.Dto.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
