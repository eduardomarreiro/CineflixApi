using CineflixApi.Data.Context;
using CineflixApi.Domain.Interfaces;
using CineflixApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public CineflixContext _context;

        public Repository(CineflixContext context)
        {
            _context = context;
        }

        public Repository()
        {

        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<T> GetByAlphabeticalOrder()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
