using CineflixApi.Domain.Models;
using System.Collections.Generic;

namespace CineflixApi.Domain.Interfaces.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        List<User> GetUsersByAlphabeticalOrder();
        User GetUserByCredentials(string user, string password);
    }
}
