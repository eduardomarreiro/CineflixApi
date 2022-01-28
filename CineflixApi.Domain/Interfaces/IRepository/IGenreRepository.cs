using CineflixApi.Domain.Models;
using System.Collections.Generic;

namespace CineflixApi.Domain.Interfaces.IRepository
{
    public interface IGenreRepository : IRepository<Genre>
    {
        List<Genre> GetGenresByAlphabeticalOrder();
    }
}
