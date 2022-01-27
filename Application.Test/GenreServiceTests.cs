using AutoMapper;
using CineflixApi.Application.Services;
using CineflixApi.Domain.Interfaces.IRepository;
using CineflixApi.Domain.Interfaces.IService;
using CineflixApi.Domain.Models;
using CineflixApi.Shared.Dto.Create;
using CineflixApi.Shared.Dto.Read;
using CineflixApi.Shared.Dto.Update;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Test
{
    public class GenreServiceTests
    {
        private readonly GenreService _sut;
        private readonly Mock<IGenreRepository> _genreRepo;
        private readonly Mock<IMapper> _mapper;

        public GenreServiceTests()
        {
            _genreRepo = new Mock<IGenreRepository>();
            _mapper = new Mock<IMapper>();
            _sut = new GenreService(_genreRepo.Object, _mapper.Object);
        }

        [Fact]
        public void GetAllGenresVerifyIfMethodWasCalled()
        {
            //Arrange
            Genre genre = new Genre();
            genre.Name = "Ação";
            genre.Id = 1;
            genre.Movies = null;

            ReadGenreDto genreDto = new ReadGenreDto();
            genreDto.Name = "Ação";

            List<Genre> genresList = new List<Genre>();
            genresList.Add(genre);

            List<ReadGenreDto> genreDtosList = new List<ReadGenreDto>();
            genreDtosList.Add(genreDto);

            _mapper.Setup(x => x.Map<List<ReadGenreDto>>(genresList)).Returns(genreDtosList);
            _genreRepo.Setup(x => x.GetAll()).Returns(genresList);

            //Act
            var result = _sut.GetAllGenres();

            //Assert
            Assert.IsType<List<ReadGenreDto>>(result);
            _genreRepo.Verify(x => x.GetAll(), Times.Once());
        }
        [Fact]
        public void addGenreVerifyIfMethodWasCalled()
        {
            //Arrange
            CreateGenreDto genreDto = new CreateGenreDto();
            genreDto.Name = "Comédia";

            Genre genre = new Genre();
            genre.Id = 1;
            genre.Name = "Comédia";

            _mapper.Setup(x => x.Map<Genre>(genreDto)).Returns(genre);

            //Act
            _sut.AddGenre(genreDto);

            //Assert
            _genreRepo.Verify(x => x.Add(genre), Times.Once());
        }

        [Fact]
        public void GetGenreByIdReturnReadGenreDto()
        {
            //Arrange 
            ReadGenreDto genreDto = new ReadGenreDto();
            genreDto.Name = "Ação";

            Genre genre = new Genre();
            genre.Id = 1;
            genre.Name = "Ação";
            genre.Movies = null;

            _mapper.Setup(x => x.Map<ReadGenreDto>(genre)).Returns(genreDto);
            _genreRepo.Setup(x => x.GetById(1));

            //Act
            var result = _sut.GetGenreById(1);

            //Assert
            Assert.IsType<ReadGenreDto>(result);
            _genreRepo.Verify(x => x.GetById(1), Times.Once());
        }
        [Fact]
        public void DeleteGenreVerifyIfMethodWasCalled()
        {
            //Arrange
            Genre genre = new Genre();
            genre.Id = 1;
            genre.Name = "Terror";
            _genreRepo.Setup(x => x.GetById(1)).Returns(genre);

            //Act
            _sut.DeleteGenre(1);

            //Assert
            _genreRepo.Verify(x => x.Delete(genre), Times.Once());
        }

        [Fact]
        public void UpdateGenreVerifyIfMethodWasCalled()
        {
            //Arrange
            Genre genre = new Genre();
            genre.Name = "suspense";
            genre.Id = 1;
            genre.Movies = null;

            UpdateGenreDto genreDto = new UpdateGenreDto();
            genreDto.Name = "suspense";

            _mapper.Setup(x => x.Map<UpdateGenreDto>(genre)).Returns(genreDto);
            _genreRepo.Setup(x => x.GetById(1)).Returns(genre);

            //Act
            _sut.UpdateGenre(1, genreDto);

            //Assert
            _genreRepo.Verify(x => x.Update(genre), Times.Once());
        }
    }
}
