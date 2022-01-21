using AutoMapper;
using CineflixApi.Data.Context;
using CineflixApi.Domain.Interfaces.IRepository;
using CineflixApi.Domain.Models;
using CineflixApi.Shared.Dto.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        IMapper _mapper;
        public UserRepository(CineflixContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<User> GetUsersByAlphabeticalOrder()
        {
            return _context.Users.OrderBy(x => x.UserName).ToList();
        }

        public User GetUserByCredentials(string user, string password)
        {
            return _context.Users.FirstOrDefault(x => x.UserName.Equals(user) && x.Password.Equals(password));
        }
    }
}
