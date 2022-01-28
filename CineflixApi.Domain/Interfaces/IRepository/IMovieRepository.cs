using CineflixApi.Domain.Models;
using System.Collections.Generic;

namespace CineflixApi.Domain.Interfaces.IRepository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        List<Movie> GetMoviesByAlphabeticalOrder();
        List<Movie> GetMovieByDirector(string director);
    }
}
