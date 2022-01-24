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
    public class DirectorRepository : Repository<Director>, IDirectorRepository
    {
        public IMapper _mapper;

        public DirectorRepository(CineflixContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public override List<Director> GetAll()
        {
            return _context.Directors.Include(x => x.Movies).ThenInclude(z => z.Genre).ToList();
        }

        public override Director GetById(int id)
        {
            return _context.Directors.Include(x => x.Movies).ThenInclude(y => y.Genre).FirstOrDefault(z => z.Id == id);
        }

        public List<Director> GetDirectorsByAlphabeticalOrder()
        {
            return _context.Directors.Include(x => x.Movies).ThenInclude(z => z.Genre).OrderBy(x => x.Name).ToList();
        }
    }
}
