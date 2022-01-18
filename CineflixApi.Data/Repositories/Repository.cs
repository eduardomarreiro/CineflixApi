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
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetByAlphabeticalOrder()
        {
            var sorterdList = _context.Set<T>().ToList();
            sorterdList.Sort();
            return sorterdList;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Update(T newEntity)
        {
            _context.Set<T>().Update(newEntity);
            _context.SaveChanges();
        }
    }
}
