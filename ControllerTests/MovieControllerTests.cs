using CineflixApi.Controllers;
using CineflixApi.Domain.Interfaces.IService;
using CineflixApi.Shared.Dto.Read;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ControllerTests
{
    public class MovieControllerTests
    {
        private readonly MovieController _sut;
        private readonly Mock<IMovieService> _movieService;

        [Fact]
        public void GetAllMoviesSortedRetunAListReadMovieDto()
        {
            //arrange
            List<ReadMovieDto> movieDtosList = new List<ReadMovieDto>();
            ReadMovieDto movieDto = new ReadMovieDto();
            movieDto.Title = "Sinais";
            movieDto.Genre = "Alienigena";
            movieDto.Runtime = 102;
            movieDto.Director = "M. Night Shyamalan";
            movieDto.Year = 2002;
            movieDtosList.Add(movieDto);

            _movieService.Setup(x => x.GetMoviesByAlphabeticalOrder()).Returns(movieDtosList);
            //act

            var result = _sut.ReturntMoviesByAlphabeticalOrder();

            //assert
            Assert.IsType<List<ReadMovieDto>>(result);
        }
    }
}
