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
            return _mapper.Map<List<ReadMovieDto>>(_movieRepo.GetAll());
        }
        public List<ReadMovieDto> GetMoviesByAlphabeticalOrder()
        {
            return _mapper.Map<List<ReadMovieDto>>(_movieRepo.GetMoviesByAlphabeticalOrder());
        }

        public ReadMovieDto GetMovieById(int id)
        {
            Movie movie = _movieRepo.GetById(id);
            if (movie != null)
            {
                ReadMovieDto movieDto = _mapper.Map<ReadMovieDto>(movie);
                return movieDto;
            }
            else
                return new ReadMovieDto();
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
