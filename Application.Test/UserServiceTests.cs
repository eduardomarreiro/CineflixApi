using AutoMapper;
using CineflixApi.Application.Services;
using CineflixApi.Domain.Interfaces.IRepository;
using CineflixApi.Domain.Models;
using CineflixApi.Shared.Dto.Create;
using CineflixApi.Shared.Dto.Read;
using CineflixApi.Shared.Dto.Update;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Application.Test
{
    public class UserServiceTests
    {
        private readonly UserService _sut;
        private readonly Mock<IUserRepository> _userRepo;
        private readonly Mock<IMapper> _mapper;

        public UserServiceTests()
        {
            _userRepo = new Mock<IUserRepository>();
            _mapper = new Mock<IMapper>();
            _sut = new UserService(_userRepo.Object, _mapper.Object);
        }
        [Fact]
        public void GetAllGenreVerifyIfMethodWasCalled()
        {
            //Arrange
            List<User> usersList = new List<User>();
            User user = new User();
            user.Id = 1;
            user.UserName = "Eduardo Marreiro";
            user.Password = "!Senha123";
            user.Role = "Manager";
            user.Email = "eduardo@gmail.com";
            usersList.Add(user);

            List<ReadUserDto> userDtosList = new List<ReadUserDto>();
            ReadUserDto userDto = new ReadUserDto();
            
            userDto.UserName = "Eduardo Marreiro";
            userDto.Password = "!Senha123";
            userDto.Role = "Manager";
            userDto.Email = "eduardo@gmail.com";
            userDtosList.Add(userDto);

            _mapper.Setup(x => x.Map<List<ReadUserDto>>(usersList)).Returns(userDtosList);
            _userRepo.Setup(x => x.GetAll()).Returns(usersList);

            //Act
            var result = _sut.GetAllUsers();

            //Assert
            Assert.IsType<List<ReadUserDto>>(result);
            _userRepo.Verify(x => x.GetAll(), Times.Once());
        }
        [Fact]
        public void addUserVerifyIfMethodWasCalled()
        {
            //Arrange
            CreateUserDto userDto = new CreateUserDto();
            userDto.UserName = "Eduardo Marreiro";
            userDto.Password = "!Senha123";
            userDto.Email = "eduardo@gmail.com";
            userDto.Role = "Employee";

            User user = new User();
            user.UserName = "Eduardo Marreiro";
            user.Password = "!Senha123";
            user.Email = "eduardo@gmail.com";
            user.Role = "Employee";

            _mapper.Setup(x => x.Map<User>(userDto)).Returns(user);

            //Act
            _sut.AddUser(userDto);

            //Assert
            _userRepo.Verify(x => x.Add(user), Times.Once());
        }
        [Fact]
        public void GetUserByIdReturnReadGenreDto()
        {
            //Arrange
            ReadUserDto userDto = new ReadUserDto();
            userDto.UserName = "Eduardo Marreiro";
            userDto.Password = "!Senha123";
            userDto.Email = "eduardo@gmail.com";
            userDto.Role = "Employee";

            User user = new User();
            user.UserName = "Eduardo Marreiro";
            user.Password = "!Senha123";
            user.Email = "eduardo@gmail.com";
            user.Role = "Employee";

            _mapper.Setup(x => x.Map<ReadUserDto>(user)).Returns(userDto);
            _userRepo.Setup(x => x.GetById(1));

            //Act
            var result = _sut.GetUserById(1);

            //Assert
            _userRepo.Verify(x => x.GetById(1), Times.Once());
        }
        [Fact]
        public void DeleteUserVerifyIfMethodWasCalled()
        {
            //Arrange
            User user = new User();
            user.Id = 1;
            user.UserName = "Eduardo Marreiro";
            user.Password = "!Senha123";
            user.Email = "eduardo@gmail.com";
            user.Role = "Employee";

            _userRepo.Setup(x => x.GetById(1)).Returns(user);

            //Act
            _sut.DeleteUser(1);

            //Assert
            _userRepo.Verify(x => x.Delete(user), Times.Once());
        }
        [Fact]
        public void UpdateUserVerifyIfMethodWasCalled()
        {
            //Arrange
            User user = new User();
            user.Id = 1;
            user.UserName = "Eduardo Marreiro";
            user.Password = "!Senha123";
            user.Email = "eduardo@gmail.com";
            user.Role = "Employee";

            UpdateUserDto userDto = new UpdateUserDto();
            userDto.UserName = "Eduardo Marreiro";
            userDto.Password = "!Senha123";
            userDto.Email = "eduardo@gmail.com";
            userDto.Role = "Employee";

            _mapper.Setup(x => x.Map<UpdateUserDto>(user)).Returns(userDto);
            _userRepo.Setup(x => x.GetById(1)).Returns(user);

            //Act
            _sut.UpdateUser(1, userDto);

            //Assert
            _userRepo.Verify(x => x.Update(user), Times.Once());
        }
    }
}
