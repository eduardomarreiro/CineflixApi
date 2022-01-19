using CineflixApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Domain.Interfaces
{
    public interface IRepository <T> where T : Entity 
    {
        void Add(T entity);
        void Delete(T entity);
        T GetById(int id);
        List<T> GetAll();
        void Update(T newEntity);    
    }
}
