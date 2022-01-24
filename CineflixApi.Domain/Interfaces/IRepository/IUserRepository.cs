using CineflixApi.Domain.Models;
using CineflixApi.Shared.Dto.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Domain.Interfaces.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        List<User> GetUsersByAlphabeticalOrder();
        User GetUserByCredentials(string user, string password);
    }
}
