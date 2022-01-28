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
    public class DirectorServiceTests
    {
        private readonly DirectorService _sut;
        private readonly Mock<IDirectorRepository> _directorRepo;
        private readonly Mock<IMapper> _mapper;

        public DirectorServiceTests()
        {
            _directorRepo = new Mock<IDirectorRepository>();
            _mapper = new Mock<IMapper>();
            _sut = new DirectorService(_directorRepo.Object, _mapper.Object);
        }

        [Fact]
        public void GetAllDirectorsVerifyIfMethodWasCalled()
        {
            Director director = new Director();
            director.Name = "Steven Spielberg";
            director.Id = 1;
            director.Movies = null;

            ReadDirectorDto directorDto = new ReadDirectorDto();
            directorDto.Name = "Steven Spielberg";
            directorDto.Movies = null;

            List<Director> directorsList = new List<Director>();
            directorsList.Add(director); 

            List<ReadDirectorDto> directorDtosList = new List<ReadDirectorDto>();
            directorDtosList.Add(directorDto);

            _mapper.Setup(x => x.Map<List<ReadDirectorDto>>(directorsList)).Returns(directorDtosList);
            _directorRepo.Setup(x => x.GetAll()).Returns(directorsList);

            //Act
            var result = _sut.GetAllDirectors();

            //Assert
            Assert.IsType<List<ReadDirectorDto>>(result);
            _directorRepo.Verify(x => x.GetAll(), Times.Once());
        }
        [Fact]
        public void addDirectorVerifyIfMethodWasCalled()
        {
            //Arrange 
            CreateDirectorDto directorDto = new CreateDirectorDto();
            directorDto.Name = "Steven Spielberg";

            Director director = new Director();
            director.Id = 1;
            director.Name = "Steven Spielberg";
            director.Movies = null;

            _mapper.Setup(x => x.Map<Director>(directorDto)).Returns(director);

            //Act
            _sut.AddDirector(directorDto);

            //Assert
            _directorRepo.Verify(x => x.Add(director), Times.Once());
        }

        [Fact]
        public void GetDirectorByIdReturnAReadMovieDto()
        {
            //Arrange
            ReadDirectorDto directorDto = new ReadDirectorDto();
            directorDto.Name = "Eduardo";

            Director director = new Director();
            director.Id = 1;
            director.Name = "Eduardo";
            director.Movies = null;

            _mapper.Setup(x => x.Map<ReadDirectorDto>(director)).Returns(directorDto);
            _directorRepo.Setup(x => x.GetById(1));

            //Act
            var result = _sut.GetDirectorById(1);

            //Assert
            Assert.IsType<ReadDirectorDto>(result);
            _directorRepo.Verify(x => x.GetById(1), Times.Once());
        }

        [Fact]
        public void DeleteDirectorVerifyIfMethodWasCalled()
        {
            //Arrange
            Director director = new Director();
            director.Id = 1;
            director.Name = "Edu";
            director.Movies = null;
            _directorRepo.Setup(x => x.GetById(1)).Returns(director);

            //Act
            _sut.DeleteDirector(1);

            //Assert
            _directorRepo.Verify(x => x.Delete(director), Times.Once());
        }

        [Fact]
        public void UpdateDirectorVerifyIfMethodWasCalled()
        {
            //Arrange
            Director director = new Director();
            UpdateDirectorDto directorDto = new UpdateDirectorDto();

            director.Id = 1;
            director.Name = "Eduardo Marreiro";
            director.Movies = null;

            directorDto.Name = "Eduardo Marreiro";

            _mapper.Setup(x => x.Map<UpdateDirectorDto>(director)).Returns(directorDto);
            _directorRepo.Setup(x => x.GetById(1)).Returns(director);

            //Act
            _sut.UpdateDirector(1, directorDto);

            //
            _directorRepo.Verify(x => x.Update(director), Times.Once());
        }
    }
}
