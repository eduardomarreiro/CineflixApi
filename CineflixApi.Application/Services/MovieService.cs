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
    public class MovieService : IMovieService
    {
        public IMovieRepository _movieRepo;
        public IMapper _mapper;

        public MovieService(IMovieRepository movieRepo, IMapper mapper)
        {
            _movieRepo = movieRepo;
            _mapper = mapper;
        }

        public void AddMovie(CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);
            _movieRepo.Add(movie);
        }

        public List<ReadMovieDto> GetMovies()
        {
            List<Movie> AllMovies = _movieRepo.GetAll();
            List<ReadMovieDto> movieDtosList = new List<ReadMovieDto>();
            foreach (Movie movies in AllMovies)
            {
                ReadMovieDto readMovieDto = new ReadMovieDto();
                readMovieDto = _mapper.Map<ReadMovieDto>(movies);
                movieDtosList.Add(readMovieDto);
            }
            return movieDtosList;
        }
        public List<ReadMovieDto> GetMoviesByAlphabeticalOrder()
        {
            return _mapper.Map<List<ReadMovieDto>>(_movieRepo.GetMoviesByAlphabeticalOrder());
        }

        public ReadMovieDto GetMovieById(int id)
        {
            ReadMovieDto movieDto = _mapper.Map<ReadMovieDto>(id);
            _movieRepo.GetById(id);
            return movieDto;
        }

        public void DeleteMovie(int id)
        {
            Movie movie = _movieRepo.GetById(id);
            if(movie != null)
            {
                _movieRepo.Delete(movie);
            }
        }
        public void UpdateMovie(int id, UpdateMovieDto movieDto)
        {
            Movie movie = _movieRepo.GetById(id);
            if( movie != null)
            {
                movie.Id = id;
                movie.Title = movieDto.Title;
                movie.Year = movieDto.Year;
                movie.DirectorId = movieDto.DirectorId;
                movie.GenreId = movieDto.GenreId;
                movie.Runtime = movieDto.Runtime;
                _movieRepo.Update(movie);
            }
        }
    }
}
