using CineflixApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Domain.Interfaces.IRepository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        List<Movie> GetMoviesByAlphabeticalOrder();
    }
}
