using AutoMapper;
using CineflixApi.Domain.Interfaces.IRepository;
using CineflixApi.Domain.Interfaces.IService;
using CineflixApi.Domain.Models;
using CineflixApi.Shared.Dto.Create;
using CineflixApi.Shared.Dto.Read;
using CineflixApi.Shared.Dto.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Application.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepo;
        public IMapper _mapper;

        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public void AddUser(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            _userRepo.Add(user);
        }

        public List<ReadUserDto> GetAllUsers()
        {
            return _mapper.Map<List<ReadUserDto>>(_userRepo.GetAll());
        }

        public List<ReadUserDto> GetUsersByAlphabeticalOrder()
        {
            return _mapper.Map<List<ReadUserDto>>(_userRepo.GetUsersByAlphabeticalOrder());
        }

        public ReadUserDto GetUserById(int id)
        {
            User user = _userRepo.GetById(id);
            if(user != null)
            {
                ReadUserDto userDto =_mapper.Map<ReadUserDto>(user);
                return userDto;
            }
            else
                return new ReadUserDto();
        }

        public void DeleteUser(int id)
        {
            User user = _userRepo.GetById(id);
            if(user != null)
            {
                _userRepo.Delete(user);
            }
        }

        public void UpdateUser(int id, UpdateUserDto userDto)
        {
            User user = _userRepo.GetById(id);
            if( user != null)
            {
                user.Id = id;
                user.UserName = userDto.UserName;
                user.Password = userDto.Password;
                user.Email = userDto.Email;
                user.Role = userDto.Role;
                _userRepo.Update(user);
            }
        }
    }
}
