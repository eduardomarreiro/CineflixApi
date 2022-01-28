using CineflixApi.Domain.Models;
using System.Collections.Generic;

namespace CineflixApi.Domain.Interfaces.IRepository
{
    public interface IDirectorRepository : IRepository<Director>
    {
        List<Director> GetDirectorsByAlphabeticalOrder();
    }
}
