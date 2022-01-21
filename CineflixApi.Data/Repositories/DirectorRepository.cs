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
    public class DirectorRepository : Repository<Director>, IDirectorRepository
    {
        public IMapper _mapper;

        public DirectorRepository(CineflixContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Director> GetDirectorsByAlphabeticalOrder()
        {
            return _context.Directors.OrderBy(x => x.Name).ToList();
        }
    }
}
