using AutoMapper;
using CineflixApi.Application.Services;
using CineflixApi.Domain.Interfaces.IRepository;
using CineflixApi.Domain.Models;
using CineflixApi.Shared.Dto.Create;
using CineflixApi.Shared.Dto.Read;
using CineflixApi.Shared.Dto.Update;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Application.Test
{
    public class MovieServiceTests
    {
        private readonly MovieService _sut;
        private readonly Mock<IMovieRepository> _movieRepo;
        private readonly Mock<IMapper> _mapper;

        public MovieServiceTests()
        {
            _movieRepo = new Mock<IMovieRepository>();
            _mapper = new Mock<IMapper>();
            _sut = new MovieService(_movieRepo.Object, _mapper.Object);
        }

        [Fact]
        public void GetAllMoviesVerifyIfMethodWasCalled()
        {
            //Arrange
            List<ReadMovieDto> movieDtosList = new List<ReadMovieDto>();
            List<Movie> moviesList = new List<Movie>();
            ReadMovieDto movieDto = new ReadMovieDto();
        
            movieDto.Director = "Quentin Tarantino";
            movieDto.Title = "Bastardos Inglórios";
            movieDto.Genre = "Guerra";
            movieDto.Runtime = 153;
            movieDtosList.Add(movieDto);

            Movie movie = new Movie();
            movie.DirectorId = 1;
            movie.Title = "Bastardos Inglórios";
            movie.GenreId = 1;
            movie.Runtime = 153;
            moviesList.Add(movie);

            _movieRepo.Setup(x => x.GetAll()).Returns(moviesList);
            _mapper.Setup(x => x.Map<List<ReadMovieDto>>(moviesList)).Returns(movieDtosList);

            //Act
            var result = _sut.GetMovies();

            //Assert
            _movieRepo.Verify(x => x.GetAll(), Times.Once());
            Assert.IsType<List<ReadMovieDto>>(result);
            Assert.Equal(movieDto.Title, result.First().Title);
        }

         [Fact]
        public void AddMovieVerifyIfMethodWasCalled()
        {
            //Arrange
            CreateMovieDto movieDto = new CreateMovieDto();
            movieDto.Title = "Sinais";
            movieDto.GenreId = 1;
            movieDto.Runtime = 144;
            movieDto.DirectorId = 2;
            movieDto.Year = 2006;

            Movie movie = new Movie();
            movie.Title = "Sinais";
            movie.GenreId = 1;
            movie.Runtime = 144;
            movie.DirectorId = 2;
            movie.Year = 2006;

            _mapper.Setup(x => x.Map<Movie>(movieDto)).Returns(movie);

            //Act
            _sut.AddMovie(movieDto);

            //Assert

            _movieRepo.Verify(x => x.Add(movie), Times.Once());
        }
        [Fact]
        public void GetMovieByIdReturnAReadMovieDto()
        {
            //Arrange
            ReadMovieDto movieDto = new ReadMovieDto();
            Movie movie = new Movie();

            movieDto.Title = "Sinais";
            movieDto.Genre = "Alienigena";
            movieDto.Runtime = 144;
            movieDto.Director = "Steven Spielberg";
            movieDto.Year = 2006;

            movie.Title = "Sinais";
            movie.GenreId = 2;
            movie.Runtime = 144;
            movie.DirectorId = 1;
            movie.Year = 2006;

            _mapper.Setup(x => x.Map<ReadMovieDto>(movie)).Returns(movieDto);
            _movieRepo.Setup(x => x.GetById(1));

            //Act
            var result = _sut.GetMovieById(1);

            //Assert
            _movieRepo.Verify(x => x.GetById(1), Times.Once());
            Assert.IsType<ReadMovieDto>(result);
        }


        [Fact]
        public void DeleteMovieVerifyIfMethodWasCalled()
        {
            //Arrange

            Movie movie = new Movie();
            movie.Title = "Os infratores";
            movie.GenreId= 1;
            movie.DirectorId = 1;
            movie.Runtime = 116;
            movie.Year = 2012;
            _movieRepo.Setup(x => x.GetById(1)).Returns(movie);

            //Act
            _sut.DeleteMovie(1);

            //Assert
            _movieRepo.Verify(x => x.Delete(movie), Times.Once());
        }
        [Fact]
        public void UpdateMovieVerifyIfMethodWasCalled()
        {
            //Arrange
            Movie movie = new Movie();
            UpdateMovieDto movieDto = new UpdateMovieDto();

            movie.Title = "Os infratores";
            movie.GenreId = 1;
            movie.DirectorId = 1;
            movie.Runtime = 116;
            movie.Year = 2012;

            movieDto.Title = "Os infratores";
            movieDto.GenreId = 1;
            movieDto.DirectorId = 1;
            movieDto.Runtime = 116;
            movieDto.Year = 2012;

            _mapper.Setup(x => x.Map<UpdateMovieDto>(movie)).Returns(movieDto);
            _movieRepo.Setup(x => x.GetById(1)).Returns(movie);

            //Act
            _sut.UpdateMovie(1, movieDto);

            //
            _movieRepo.Verify(x => x.Update(movie), Times.Once());
        }
    }
}