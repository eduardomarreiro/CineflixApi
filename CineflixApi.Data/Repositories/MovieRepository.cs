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
    public class MovieRepository : Repository<Movie>, IMovieRepository 
    {
        public IMapper _mapper;

        public MovieRepository(CineflixContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper; 
        }

        public override List<Movie> GetAll()
        {
            return _context.Movies.Include(x => x.Director)
                .Include(x => x.Genre).ToList();
        }

        public List<Movie> GetMoviesByAlphabeticalOrder()
        {
            return _context.Movies.Include(x => x.Director)
                .Include(x => x.Genre)
                .OrderBy(x => x.Title).ToList();           
        }

        public override Movie GetById(int id)
        {
            return _context.Movies.Include(x => x.Director)
                .Include(x => x.Genre)
                .FirstOrDefault(z => z.Id == id);
        }

        public List<Movie> GetMovieByDirector(string director)
        {
            return _context.Movies.Include(x => x.Director)
                .Include(x => x.Genre)
                .Where(x => x.Director.Name.Equals(director)).ToList();
        }
    }
}
