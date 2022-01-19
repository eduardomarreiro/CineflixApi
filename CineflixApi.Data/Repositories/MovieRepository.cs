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
    public class MovieRepository : Repository<Movie>, IMovieRepository 
    {
        public IMapper _mapper;

        public MovieRepository(CineflixContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper; 
        }

        public List<Movie> GetMoviesByAlphabeticalOrder()
        {
            return (List<Movie>)_context.Movies.ToList().OrderBy(x => x.Title);           
        }
    }
}
