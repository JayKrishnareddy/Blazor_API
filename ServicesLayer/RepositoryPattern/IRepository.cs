using DomainLayer.Models;
using System.Collections.Generic;

namespace ServicesLayer.Repositorypattern
{
   public interface IRepository<T> where T : BaseEntity
   {
        IEnumerable<T> GetAll();
        T Get(int Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
