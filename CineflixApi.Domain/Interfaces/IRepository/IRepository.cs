using CineflixApi.Domain.Models;
using System.Collections.Generic;

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
