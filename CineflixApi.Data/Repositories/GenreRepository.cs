using AutoMapper;
using CineflixApi.Data.Context;
using CineflixApi.Domain.Interfaces.IRepository;
using CineflixApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
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

        public override List<Genre> GetAll()
        {
            return _context.Genres.Include(x => x.Movies).ToList();
        }
        public override Genre GetById(int id)
        {
            return _context.Genres.Include(x => x.Movies).FirstOrDefault(x => x.Id == id);
        }

        public List<Genre> GetGenresByAlphabeticalOrder()
        {
            return _context.Genres.OrderBy(x => x.Name).ToList();
        }
    }
}
