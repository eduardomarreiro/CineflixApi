using AutoMapper;
using CineflixApi.Data.Context;
using CineflixApi.Domain.Interfaces.IRepository;
using CineflixApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Data.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public IMapper _mapper;

        public GenreRepository(CineflixContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;           
        }

        public List<Genre> GetGenresByAlphabeticalOrder()
        {
            return (List<Genre>)_context.Genres.ToList().OrderBy(x => x.Name);
        }
    }
}
