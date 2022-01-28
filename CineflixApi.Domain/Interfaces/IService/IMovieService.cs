using CineflixApi.Shared.Dto.Create;
using CineflixApi.Shared.Dto.Read;
using CineflixApi.Shared.Dto.Update;
using System.Collections.Generic;

namespace CineflixApi.Domain.Interfaces.IService
{
    public interface IMovieService
    {
        void AddMovie(CreateMovieDto movieDto);
        List<ReadMovieDto> GetMovies();
        List<ReadMovieDto> GetMoviesByAlphabeticalOrder();
        ReadMovieDto GetMovieById(int id);
        void DeleteMovie(int id);
        void UpdateMovie(int id, UpdateMovieDto movieDto);
        List<ReadMovieDto> GetMovieByDirector(string director);
    }
}
